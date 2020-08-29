# VL.Elementa

[![Matrix](https://img.shields.io/matrix/VL.Elementa:matrix.org?color=blue&label=chat%20on%20matrix&logo=matrix)](https://matrix.to/#/!ozhuuBcieNoMbRkvVj:matrix.org?via=matrix.org)
[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/VL.Elementa?logo=nuget)](https://www.nuget.org/packages/VL.Elementa/)

A node based UI widgets library made in VL for Skia rendering.

The library includes:
- A collection of ready to use widgets to handle the most common value types in vvvv Gamma
- A set of Layout nodes to easily arrange your widgets and create responsive UIs
- A bunch of utilities and help patches



## Installing

To use the latest stable version:
1. Go to Gamma's Quad menu > Manage Nugets > Commandline and type:

	```
	nuget install VL.Elementa
	```
2. Press Enter and wait the ending of the installation process



## Contributing to the development

1. Clone the repository
2. Build the solution located in the `src` folder in `Release` mode. 
3. You can then start contributing to the lib.

### Contributing new widgets

Read [this wiki page](https://github.com/vvvv-dottore/VL.Elementa/wiki/Contributing-new-widgets) to get specific guidelines on how to contribute new widgets.


## Licencing

MIT License - You're free to use VL.Elementa in your creative & commercial projects.

[Natan Sinigaglia](http://natansinigaglia.com/)


## Changelog

### 4.0.0

#### New
- Massive documentation update : many new help patches, pin and nodes descriptions
- New widgets :
	- DropdownGrid
	- DropdownGridEnum
	- IntegerPolar
	- ValuePolar
	- IntegerPolarUpDown
- New StylePresets : readymade stylesheets you can plug to your Elementa graph. Contribute your own!

#### Changed/Updated
- Changed pin names in Layout nodes. `Inherit Size From Children` and all similar names are now `Auto Size`
- Masked irrelevant pins for some Layout nodes

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