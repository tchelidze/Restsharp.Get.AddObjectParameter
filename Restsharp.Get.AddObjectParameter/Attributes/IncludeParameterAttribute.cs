using System;

namespace Restsharp.Get.AddObjectParameter.Attributes
{
    /// <summary>
    ///     Is used to include non public property into parameter list
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IncludeParameterAttribute : Attribute
    { }
}