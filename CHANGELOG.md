# Changelog

### 5.0.10

- Various fixes and improvements

### 5.0.9

- Fixes bang's boolean output acting like a toggle

### 5.0.8

- Added FUNDING.yml file

### 5.0.7

- Fixes wrong assignment of two nodes inside Dropdown node - bug surfaces in new vvvv preview builds

### 5.0.5

#### New

- Added enable option for default stroke for selected widgets in the selectableProcessorSettings

### 5.0.3

#### New

- Added MinResizeableSize setting in Transformation component

#### Fixes

- Fixed selection by single click over selectable widget
- Renamed ForceStartSelectionFunc in SelectableComponentProcessorSettings to EnableSelectionCondition
- Quick fix for label being clipped

### 5.0.2

#### Fixes

- added Flexibility Input pin in MenuEntry and MenuFolder

### 5.0.1

#### New

- Panel widget has a new optional pin for space transformation

#### Fixes

- fixes in `Panel` widget (got rid of the internal group elementum)
- fix in `TextWithBackground` not updating text when output assigned to create

### 5.0.0

#### New

- `AnyEditing` node in the `Getters` category
- Layout operators' helper now also shows widget's bounds
- Elementa node now has a `Viewport` input
- `ScrollableValue` component allowing to modify a widget's value using mouse scroll. Comes with help patches

#### Changed

- The first widget connected to the Elementa node can use Flexibility to stretch to the viewport
- All nodes now live under the `Elementa` category, instead of `VL.Elementa`
- Layout operator widget alignment option is now "Widgets self alignment" (no more horizontal/vertical)
- All widgets and layout operators are now fragmented
- Default style is now more wireframe-ish
- Default font is now SegoeUI
- Panel now only allows for vertical and horizontal scrolls
- Tooltip is now using Tasks internally and can be drawn anywhere around the widget it's connected to
- Padding is now expressed as a spread of floats instead of a string
- Overlay system total revamp. Any number of overlays can now be opened on top of each other

#### Fixed

- Polar widgets got added to `Widgets In Action` and `Widget Overview` help patches
- Dropdown widgets now behave correctly

### 4.0.5

#### Fixes

- NUnit project builds again

### 4.0.4

#### New
- Massive documentation update : many new help patches, pin and nodes descriptions
- New widgets :
	- DropdownGrid
	- DropdownGridEnum
	- IntegerPolar
	- ValuePolar
	- IntegerPolarUpDown
- New StylePresets : readymade stylesheets you can plug to your Elementa graph. Contribute your own!
- AnyHovered : tells you if any widget of your graph is hovered. Comes with its help patch

#### Changed/Updated
- Changed pin names in Layout nodes. `Inherit Size From Children` and all similar names are now `Auto Size`
- Masked irrelevant pins for some Layout nodes
- Layout nodes now have an optionnal pin to that draws a helper stroke to visualize them more easily
- Boolean widgets (bang, toggle, press) now have a new default drawer making it more obvious if they're true or not

#### Fixed

- Layer Objects are now stroked when selected

### 3.0.0

- NEW Style system. there's no StyleSheet property anymore in IElementum interface (everything gets managed by the Styleable component, already implemented within every widget)
- NEW "Selector" utility library to validate conditions within an entity-component tree graph (used for the style system)
- NEW css file parser (builds an Elementa StyleSheet)
- NEW ClientBounds, ElementaContextReceiver and UndoRedo utility widget nodes
- NEW DisplayText optional input pin for Toggle, Bang, Press widgets
- NEW sticky behaviour for slider widget (and all widgets that internally use slider behaviour)
- NEW Formattable component
- NEW Grid layout node
- NEW Root architecture with pluggable component processors
- NEW EditBehaviour options for some widgets: AbsoluteEditing/RelativeEditing/StickyEditing
- FIX in ToSkiaLayer (in Root): disabled skia rendering in the first frame to avoid UI flickering (due to frame delays in retrieving the bounds from renderer)
- FIX in IntegerUpDown behaviour (wasn't updating Min and Max values in idle)
- Refactoring of Layour nodes: proper cached mechanism that improves a lot performances and better modularization of the internal components.
- Layout nodes come just with a Spectral version (no pingroup version anymore)
- All widgets now come with a Spectral version (that expect a component spread as input, not using pingroup)
- Styleable component now as advanced, not meant to be plugged to the widgets to customize their style
- Taggable component reworked: now it simply contains an `HashSet<Object>`. it comes also as a (Spectral Advanced) version, with no pingroup.
- Attributable component got refreshed as well: attributes come as `Dictionary<String, Object>` 
- renamed Typeable component to Focusable
- Rotary widget now internally made with a slider (since they share the same behaviour).

### 2.2.3

- Another small fix in Panel

### 2.2.2

- Panel fix

### 2.2.1

- Cleanup in the node browser
- some fixes

### 2.2.0

- New LayerElementum widget
- New Drawable component
- Drawing performance improved

### 2.1.1

- New Image node
- Fixes in help patches

### 2.1.0

- New Panel node
- New Folder node
- New Style utility nodes
- New Tooltip component
- Added GetStyleSheet operation in IElementum
- Added GetComponentsVersion in IElementum
- Changed GetDirtyLayout and GetDirtyGraph operations in IElementum to GetLayoutVersion and GetGraphVersion
- Introduced ElementaContext class: every widget have access to the graph resources
- Added SetElementaContext and SetMe operations in IElementum
- Introduced SetElementaContext and SetParent operations in IComponent: each component has now access to any resource of the graph and can easily edit its own parent widget
- Different Layout/Graph/Components changes check system
- Help patches now referencing the nuget instead of the vl file (SavingAs the patches doesn't break the reference)
- Cleaned Root node architecture
- fixed Moveable and Resizeable components behaviour in multi selection scenarios
- New componentProcessors management
- Individual help patches available for all widgets
- Added node and pin descriptions on all widgets
- Reorganized help patches
- Deleted TextFieldMultiline, which is now TextField
- Some minor fixes

### 2.0.0

- New nodes to push widgets to Overlay
- Renamed the library to VL.Elementa
- New widget architecture : value properties and widget manager are now generic
- completely reworked StyleSheet management
- Style can be provided to a widget with the new Styleable component
- Orientation, multi-components widgets and specific attributes are now handled by components (was in widget managers before)
- Widgets can now have custom drawers
- Layout nodes (stack, columns, etc) now provide more options to play with, allowing more precise layout
- Added Padding to layout nodes
- A widget's ValueProperty can be provided from outside, allowing several widgets to share the same ValueProperty
- mapping between external ValueProperties of different types
- New help patches explaining custom drawers, shared value properties and Moveable/Resizeable components

### 1.0.0

- First version of the architecture
