using System;

namespace Elementa
{
    public enum MouseEventKind
    {
        Down, Up, Pressed, Move, DoubleClick, IsLost
    }

    public enum KeyboardEventKind
    {
        Down, Up, Pressed
    }

    public enum ElementumState
    {
        Idle, Hovered, Selected, Focused
    }

    public enum LabelPlacement
    {
        Left, Right, Top, Bottom
    }

    public enum KnownWidget
    {
        Bang, Press, Toggle, Integer, IntegerUpDown, Value, Value64, Slider, Rotary, Vector2D, Slider2D, Range, Vector3D, Vector4D, Color, TextField, Dropdown, NavigateToButton
    }

    public enum Orientation
    {
        Horizontal, Vertical
    }

    public enum GroupExposureKind
    {
        Flat, Nested, Stacked
    }

    public enum LayoutMode
    {
        None, Stack, Distribute, Allocate
    }

    public enum VerticalAlignment
    {
        None, Left, Center, Right
    }

    public enum HorizontalAlignment
    {
        None, Top, Middle, Bottom
    }

    public enum AxisConstraint
    {
        NoConstraint, Horizontal, Vertical
    }

    public enum HandlersOffset
    {
        Internal, OnEdge, External
    }

    public enum ValueEditingMode
    {
        Absolute, Relative, Sticky
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