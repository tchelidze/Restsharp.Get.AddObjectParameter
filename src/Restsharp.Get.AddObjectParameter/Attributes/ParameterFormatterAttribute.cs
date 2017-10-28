using System;

namespace Restsharp.Get.AddObjectParameter.Attributes
{
    public class ParameterFormatterAttribute : Attribute
    {
        public ParameterFormatterAttribute(
            Type formatterType)
            => FormatterType = formatterType;

        public Type FormatterType { get; }
    }
}