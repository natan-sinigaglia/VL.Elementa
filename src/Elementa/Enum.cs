using System;

namespace Elementa
{
    public enum Mouse_Event_Kind
    {
        Down, Up, Pressed, Move, DoubleClick, IsLost
    }

    public enum Keyboard_Event_Kind
    {
        Down, Up, Pressed
    }

    public enum Elementum_State
    {
        Idle, Hovered, Selected, Focused, Preview
    }

    public enum Label_Placement
    {
        Down, Right, Up, Left
    }

    public enum ComponentType
    {
        Interactive, Hoverable, Focusable, Selectable, Previewable, Typeable, Taggable, Styleable, Taskable, Moveable, Resizeable, Orientable, Attributable, Subdividable
    }

    public enum KnownWidget
    {
        Bang, Press, Toggle, Integer, IntegerUpDown, Value, Value64, Slider, Rotary, Vector2D, Slider2D, Range, Vector3D, Vector4D, Color, TextField, Dropdown, NavigateToButton
    }

    public enum WidgetOrientation
    {
        Horizontal, Vertical
    }

    public enum GroupExposureKind
    {
        Flat, Nested, Stacked
    }
    public enum Layout_Orientation
    {
        Horizontal, Vertical
    }

    public enum Layout_Mode
    {
        None, Stack, Distribute
    }

    public enum Layout_VerticalAlignment
    {
        None, Left, Center, Right
    }

    public enum Layout_HorizontalAlignment
    {
        None, Top, Middle, Bottom
    }

}
