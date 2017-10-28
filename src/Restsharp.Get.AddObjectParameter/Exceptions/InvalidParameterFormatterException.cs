using System;

namespace Restsharp.Get.AddObjectParameter.Exceptions
{
    public class InvalidParameterFormatterException : Exception
    {
        public InvalidParameterFormatterException(
            Type invalidParameterFormatterType)
            => InvalidParameterFormatterType = invalidParameterFormatterType;

        public Type InvalidParameterFormatterType { get; }
    }
}