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

}
