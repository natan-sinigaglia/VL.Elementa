using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIElements.Core
{

    public enum Button_Shape
    {
        Rectangle,
        Triangle_Up,
        Triangle_Down,
        Triangle_Left,
        Triangle_Right,
        Circle,
        RoundRectangle,
        Menu
    }

    public enum Interaction_State
    {
        Idle,
        Hovered,
        Focused,
        Selected,
        TextPreview
    }

    public enum Style_Element
    {
        Fill_Visible,
        Fill_Color,
        Fill_Paint,
        Texture_Enable,
        Texture,
        Stroke_Visible,
        Stroke_Color,
        Stroke_Paint,
        Shape,
        Size,
        Text_Visible,
        Text_Color,
        Text_Paint,
        Text_Font,
        Text_Size,
        Text_Alignment_Vertical,
        Text_Alignment_Horizontal,
    }

}
