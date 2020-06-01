using System;
using System.Collections.Generic;
using System.Text;
using ExCSS;

namespace Elementa
{
    public static class CSSUtils
    {
        public static StyleProperties? CSSToElementaProperty(string propertyName)
        {
            StyleProperties? result = null;
            switch (propertyName)
            {
                case "background-color":
                    result = StyleProperties.Background_Color;
                    break;
                case "border-color":
                case "border-top-color":
                case "border-righ-color":
                case "border-bottom-color":
                case "border-left-color":
                    result = StyleProperties.Background_Stroke_Color;
                    break;
                case "color":
                    result = StyleProperties.Text_Color;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
