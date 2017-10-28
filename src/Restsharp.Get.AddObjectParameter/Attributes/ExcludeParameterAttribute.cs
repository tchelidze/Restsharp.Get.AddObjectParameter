using System;

namespace Restsharp.Get.AddObjectParameter.Attributes
{
    /// <summary>
    ///     Is used to exclude property from parameter list
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcludeParameterAttribute : Attribute
    { }
}