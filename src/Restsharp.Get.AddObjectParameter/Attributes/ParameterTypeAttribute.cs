using System;
using RestSharp;

namespace Restsharp.Get.AddObjectParameter.Attributes
{
    /// <summary>
    ///     Specifies Type for parameter.
    ///     If not present, then ParameterType.GetOrPost is used instead.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterTypeAttribute : Attribute
    {
        public ParameterTypeAttribute(ParameterType parameterType)
            => ParameterType = parameterType;

        public ParameterType ParameterType { get; }
    }
}