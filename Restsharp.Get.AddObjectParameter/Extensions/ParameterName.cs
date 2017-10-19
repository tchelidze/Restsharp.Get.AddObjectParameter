using System.Reflection;
using Restsharp.Get.AddObjectParameter.Attributes;

namespace Restsharp.Get.AddObjectParameter.Extensions
{
    public static partial class RestRequestExtensions
    {
        static string GetParameterName(this MemberInfo propertyInfo)
            => propertyInfo.GetCustomAttribute<ParameterNameAttribute>()?.ParameterName ?? propertyInfo.Name;
    }
}