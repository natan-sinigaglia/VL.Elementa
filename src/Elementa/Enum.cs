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
        Idle, Hovered, Selected
    }

    public enum Label_Placement
    {
        Left, Right, Top, Bottom
    }

    public enum ComponentType
    {
        Interactive, Hoverable, Selectable, Typeable, Taggable, Styleable, Taskable, Moveable, Resizeable, Orientable, Attributable, Subdividable, Cycleable
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
        None, Stack, Distribute, Allocate
    }

    public enum Layout_VerticalAlignment
    {
        None, Left, Center, Right
    }

    public enum Layout_HorizontalAlignment
    {
        None, Top, Middle, Bottom
    }

    public enum Axis_Constraint
    {
        NoConstraint, Horizontal, Vertical
    }

    public enum Handlers_Offset
    {
        Internal, OnEdge, External
    }

    public enum StyleProperties
    {
        Background_Enabled,
        Background_Paint,
        Background_Color,
        Background_Padding,
        Background_Stroke_Enabled,
        Background_Stroke_Paint,
        Background_Stroke_Color,

        Foreground_Enabled,
        Foreground_Paint,
        Foreground_Color,
        Foreground_Highlight_Color,
        Foreground_Padding,
        Foreground_Stroke_Enabled,
        Foreground_Stroke_Paint,
        Foreground_Stroke_Color,

        Text_Enabled,
        Text_FamilyName,
        Text_Style,
        Text_Size,
        Text_Color,
        Text_LineHeight,
        Text_HorizonalAlignment,
        Text_VerticalAlignment,
        Text_Padding
    }
}