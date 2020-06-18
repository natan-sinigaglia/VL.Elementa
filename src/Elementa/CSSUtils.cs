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
                case "font-family":
                    result = StyleProperties.Text_FamilyName;
                    break;
                case "font-size":
                    result = StyleProperties.Text_Size;
                    break;
                case "font-style":
                    result = StyleProperties.Text_Style;
                    break;
                case "line-height":
                    result = StyleProperties.Text_LineHeight;
                    break;
                case "padding":
                case "padding-top":
                case "padding-right":
                case "padding-bottom":
                case "padding-left":
                    result = StyleProperties.Text_Padding;
                    break;
                case "text-align":
                    result = StyleProperties.Text_HorizonalAlignment;
                    break;
                case "vertical-align":
                    result = StyleProperties.Text_VerticalAlignment;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
