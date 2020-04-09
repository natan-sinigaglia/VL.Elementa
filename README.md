# VL.Elementa

UI widgets library made in VL. 
Skia based rendering.

## Changelog

### 2.0.0

- Renamed the library to VL.Elementa
- New widget architecture : value properties and widget manager are now generic
- Style can be provided to a widget with the new Styleable component
- Orientation, multi-components widgets and specific attributes are now handled by components (was in widget managers before)
- Widgets can now have custom drawers
- Layout nodes (stack, columns, etc) now provide more options to play with, allowing more precise layout
- A widget's value can now be overriden from the outside, allowing several widgets to share the same value
- mapping between external ValueProperties of different types
- New help patches explaining custom drawers, shared value properties and Moveable/Resizeable components

## Installing

To use the latest stable version, go to Gamma's command line and type

```
nuget install vl.elementa
```

## Contributing

- Clone the repo and build the solution located in the `src` folder in `Release` mode. You can then start contributing to the lib.