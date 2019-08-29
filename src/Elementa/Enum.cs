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
        Interactive, Hoverable, Focusable, Selectable, Previewable, Typeable, Taggable, Stylable, Taskable, Moveable, Resizeable
    }

    public enum KnownWidget
    {
        Bang, Press, Toggle, Integer, IntegerUpDown, Value, Slider, Rotary, Vector2D, Slider2D, Range, Vector3D, Vector4D, Color, TextField, Dropdown, NavigateToButton
    }

    public enum WidgetOrientation
    {
        Horizontal, Vertical
    }

    public enum GroupExposureKind
    {
        Flat, Nested, Stacked
    }

}
