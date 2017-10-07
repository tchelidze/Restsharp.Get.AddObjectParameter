using System;

namespace Restsharp.Get.AddObjectParameter.Attributes
{
    /// <summary>
    ///     Specifies name for parameter.
    ///     If not present, then property name is used instead.
    /// </summary>

    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterNameAttribute : Attribute
    {
        public ParameterNameAttribute(string parameterName) => ParameterName = parameterName;

        public string ParameterName { get; }
    }
}