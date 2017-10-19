using System;

namespace Restsharp.Get.AddObjectParameter.Attributes
{
    /// <summary>
    ///     Specifies ContentType for parameter.
    ///     If not present, null is used instead.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterContentTypeAttribute : Attribute
    {
        public ParameterContentTypeAttribute(string contentType)
            => ContentType = contentType;

        public string ContentType { get; }
    }
}