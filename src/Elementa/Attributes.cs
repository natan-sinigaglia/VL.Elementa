using System;
using System.Collections.Generic;
using System.Text;

namespace Elementa.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SuppressAllAttribute : Attribute
    {
    }
    public class ExposeAttribute : Attribute
    {
    }
    public class SuppressAttribute : Attribute
    {
    }

    public class KnownWidgetAttribute : Attribute
    {
        public KnownWidgetAttribute(KnownWidget widget)
        {
            Widget = widget;
        }

        public KnownWidget Widget { get; }
    }

    public class WidgetOrientationAttribute : Attribute
    {
        public WidgetOrientationAttribute(WidgetOrientation widgetOrientation)
        {
            WidgetOrientation = widgetOrientation;
        }

        public WidgetOrientation WidgetOrientation { get; }
    }

    public class GroupExposureKindAttribute : Attribute
    {
        public GroupExposureKindAttribute(GroupExposureKind groupExposureKind)
        {
            GroupExposureKind = groupExposureKind;
        }

        public GroupExposureKind GroupExposureKind { get; }
    }

    public class CustomOSCAddressAttribute : Attribute
    {
        public CustomOSCAddressAttribute(string customOSCAddress)
        {
            CustomOSCAddress = customOSCAddress;
        }

        public string CustomOSCAddress { get; }
    }

    public class LayoutPriorityAttribute : Attribute
    {
        public LayoutPriorityAttribute(UInt32 layoutPriorityAttribute)
        {
            LayoutPriority = layoutPriorityAttribute;
        }

        public UInt32 LayoutPriority { get; }
    }

    // =======================================================================================
    // VALUE RELATED ATTRIBUTES:

    // Allowed types are bool, float, etc. string, enums, System.Type and array of previous OR object

    public class DefaultValueAttribute : Attribute
    {

        public DefaultValueAttribute(object defaultValue)
        {
            DefaultValue = defaultValue;
        }

        public object DefaultValue { get; }
    }

    public class MininumValueAttribute : Attribute
    {
        public MininumValueAttribute(object minimumValue)
        {
            MinimumValue = minimumValue;
        }

        public object MinimumValue { get; }
    }

    public class MaximumValueAttribute : Attribute
    {
        public MaximumValueAttribute(object maximumValue)
        {
            MaximumValue = maximumValue;
        }

        public object MaximumValue { get; }
    }

    public class IsCyclicAttribute : Attribute
    {
    }

    public class StepSizeAttribute : Attribute
    {
        public StepSizeAttribute(object stepSize)
        {
            StepSize = StepSize;
        }

        public object StepSize { get; }
    }

    public class DisplayTextAttribute : Attribute
    {
        public DisplayTextAttribute(String text)
        {
            Text = text;
        }

        public String Text { get; }

    }

}
