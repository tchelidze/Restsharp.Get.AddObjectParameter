using System;

namespace Restsharp.Get.AddObjectParameter.Attributes
{
    /// <inheritdoc />
    /// <summary>
    ///     If property type defines method with signature ToString(string), then it's invoked with FormatString
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterFormatStringAttribute : Attribute
    {
        public ParameterFormatStringAttribute(string formatString)
        {
            if (string.IsNullOrEmpty(formatString))
            {
                throw new ArgumentException("Must not be null or empty", nameof(formatString));
            }

            FormatString = formatString;
        }

        public string FormatString { get; }
    }
}