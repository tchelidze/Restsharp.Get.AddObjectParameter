using System.Reflection;
using Restsharp.Get.AddObjectParameter.Attributes;

namespace Restsharp.Get.AddObjectParameter.Extensions
{
    public static partial class RestRequestExtensions
    {
        static string GetParameterContentType(this MemberInfo propertyInfo)
            => propertyInfo.GetCustomAttribute<ParameterContentTypeAttribute>()?.ContentType;
    }
}