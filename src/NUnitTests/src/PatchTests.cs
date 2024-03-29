﻿using NUnit.Framework;
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

namespace MyTests
{
    enum SaveDocCondition { Never, WhenGreen, Always };

    [TestFixture]
    public class PatchTests
    {
        static string[] Packs = new string[]{
            @"C:\Program Files\vvvv\vvvv_gamma_2021.4.0\lib\packs",
        };



        // ------------------------------------------------------------
        // Troubleshooting red tests that shouldn't be red:
        //
        // - use "Release" build
        //
        // - The vvvv gamma version mentioned above should be the same as the NuGet versions of all VL packages.
        //  So either
        //  * install the vvvv gamma version specified above
        //  OR
        //  * fix this line to match your installed vvvv gamma version and
        //    fix the package references in Elementa.csproj and NUnitTests.csproj to match the version
        //
        // - build Solution
        //
        // - run tests
        // ------------------------------------------------------------



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

            foreach (var pack in Packs)
                AssemblyLoader.AddPackageRepositories(pack);

            // Also add the "vl-libs" folder. The folder that contains our library.
            AssemblyLoader.AddPackageRepositories(RepositoriesPath);


            if (SynchronizationContext.Current == null)
                SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());


            Session = new VLSession("gamma", includeUserPackages: false)
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
            CompileTimeTests.CheckNodes(solution.Compilation, document.AllTopLevelDefinitions);

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
            Session.TaskFactory.Run(() => Session.LoadDocuments(docs));
            return Session.CurrentSolution;
        }



        [TestCaseSource(nameof(TestNodes))]
        public void ActualTestPatches(Node testNode)
        {
            RuntimeTests.RunTest(Session, testNode);
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
