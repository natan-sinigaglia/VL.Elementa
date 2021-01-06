using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VL.Core;
using VL.Lang;
using VL.Lang.Symbols;
using VL.Model;
using VL.TestLib;
using VVVV.NuGetAssemblyLoader;
using static System.QueryAPI;

namespace MyTests
{
    enum SaveDocCondition { Never, WhenGreen, Always };

    [TestFixture]
    public class PatchTests
    {
        static IEnumerable<string> GetPacks()
        {
            var vlExecutable = AssocQueryString(AssocStr.Executable, ".vl");
            var vlExePath = Path.GetDirectoryName(vlExecutable);
            yield return Path.Combine(vlExePath, @"lib\packs");
        }

        // DO YOU WANT TO SAVE THE VL DOCS TO DISK? 
        static SaveDocCondition SaveDocCondition = SaveDocCondition.WhenGreen;

        /// <summary>
        /// Yield all vl documents of your library, including those that have tests
        /// </summary>
        public static IEnumerable<string> AllVLDocuments()
        {
            // Yield all your VL docs
            foreach (var file in Directory.GetFiles(MainLibPath, "*.vl", SearchOption.AllDirectories))
                yield return file;
        }

        /// <summary>
        /// Yield all test patches that shall be executed and shall be checked for assertions
        /// </summary>
        static IEnumerable<string> AllVLDocumentsThatHaveTests()
        {
            // Yield all your VL docs that contain tests
            foreach (var file in Directory.GetFiles(LibTestsPath, "*.vl", SearchOption.AllDirectories))
                yield return file;
        }


        public static readonly VLSession Session;
        public static string MainLibPath; 
        public static string LibTestsPath;
        public static string RepositoriesPath;

        static PatchTests()
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            MainLibPath = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\..\..\..\.."));
            LibTestsPath = Path.Combine(MainLibPath, "tests");
            RepositoriesPath = Path.GetFullPath(Path.Combine(MainLibPath, @".."));

            foreach (var pack in GetPacks())
                AssemblyLoader.AddPackageRepositories(pack);

            // Also add the "vl-libs" folder. The folder that contains our library.
            AssemblyLoader.AddPackageRepositories(RepositoriesPath);


            if (SynchronizationContext.Current == null)
                SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());


            Session = new VLSession("gamma", SynchronizationContext.Current, includeUserPackages: false)
            {
                CheckSolution = false,
                IgnoreDynamicEnumErrors = true,
                NoCache = true,
                KeepTargetCode = false
            };
        }





        static Solution FCompiledSolution;


        /// <summary>
        /// Checks if the document comes with compile time errors (e.g. red nodes). Doesn't actually run the patches.
        /// </summary>
        /// <param name="filePath"></param>
        [TestCaseSource(nameof(AllVLDocuments))]
        public static void IsntRed(string filePath)
        {
            var solution = FCompiledSolution ?? (FCompiledSolution = Compile(AllVLDocuments()));
            var document = solution.GetOrAddDocument(filePath);

            // Check document structure
            Assert.True(document.IsValid);

            // Check dependenices
            foreach (var dep in document.GetDocSymbols().Dependencies)
                Assert.IsFalse(dep.RemoteSymbolSource is Dummy, $"Couldn't find dependency {dep}");

            // Check all containers and process node definitions, including application entry point
            CheckNodes(document.AllTopLevelDefinitions);

            if (SaveDocCondition == SaveDocCondition.Always || (SaveDocCondition == SaveDocCondition.WhenGreen && Success()))
                document.Save(isTrusted: false); // TODO: discuss when this can be turned on.
        }

        private static bool Success()
        {
            var thisTest = TestExecutionContext.CurrentContext.CurrentTest;
            var testResult = thisTest.MakeTestResult();
            var resultState = testResult.ResultState;
            return resultState == ResultState.Success || resultState == ResultState.Inconclusive;
        }

        static Solution Compile(IEnumerable<string> docs)
        {
            var solution = Session.CurrentSolution;
            foreach (var f in docs)
                solution = solution.GetOrAddDocument(f).Solution;
            return solution.WithFreshCompilation();
        }

        public static void CheckNodes(IEnumerable<Node> nodes)
        {
            Parallel.ForEach(nodes, definition =>
            {
                var definitionSymbol = definition.GetSymbol() as IDefinitionSymbol;
                Assert.IsNotNull(definitionSymbol, $"No symbol for {definition}.");
                var errorMessages = definitionSymbol.Messages.Where(m => m.Severity == MessageSeverity.Error);
                Assert.That(errorMessages.None(), () => $"{definition}: {string.Join(Environment.NewLine, errorMessages)}");
                Assert.IsFalse(definitionSymbol.IsUnused, $"The symbol of {definition} is marked as unused.");
            });
        }





        [TestCaseSource(nameof(TestNodes))]
        public async Task ActualTestPatches(Node testNode)
        {
            await LanguageTests.RunTest(testNode);
        }

        /// <summary>
        /// Yield all test patches that shall run
        /// </summary>
        static IEnumerable<Node> TestNodes()
        {
            var solution = FCompiledSolution ?? (FCompiledSolution = Compile(AllVLDocuments()));
            foreach (var file in Directory.GetFiles(LibTestsPath, "*.vl", SearchOption.AllDirectories))
            {
                var document = solution.GetOrAddDocument(file, createNew: false, loadDependencies: false);
                foreach (var definition in document.AllTopLevelDefinitions.Where(n => !n.IsGeneric && n.IsNodeDefinition))
                {
                    var name = definition.Name.NamePart;
                    if (name.EndsWith("Test") || name.EndsWith("Tests"))
                        yield return definition;
                }
            }
        }
    }
}
