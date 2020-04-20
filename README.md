# VL.Elementa

A node based UI widgets library made in VL for Skia rendering.

The library includes:
- a collection of ready to use widgets to handle the most common value types in vvvv Gamma
- a set of Layout nodes to easily arrange your widgets and create responsive UIs
- a bunch of utilities and help patches



## Installing

To use the latest stable version:
1. go to Gamma's Quad menu > Manage Nugets > Commandline and type:

	```
	nuget install vl.elementa
	```
2. press Enter and wait the ending of the installation process



## Contributing to the development

1. Clone the repository
2. build the solution located in the `src` folder in `Release` mode. 
3. You can then start contributing to the lib.



## Licencing

MIT License - You're free to use VL.Elementa in your creative & commercial projects.
[Natan Sinigaglia](http://natansinigaglia.com/)



## Changelog

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
