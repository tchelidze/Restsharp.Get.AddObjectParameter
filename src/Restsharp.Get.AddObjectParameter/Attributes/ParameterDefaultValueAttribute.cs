using System;

namespace Restsharp.Get.AddObjectParameter.Attributes
{
    public class ParameterDefaultValueAttribute : Attribute
    {
        public ParameterDefaultValueAttribute(object value)
            => DefaultValue = value;

        public object DefaultValue { get; }
    }
}