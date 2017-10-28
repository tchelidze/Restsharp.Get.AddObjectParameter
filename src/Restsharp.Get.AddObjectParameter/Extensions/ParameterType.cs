using System.Reflection;
using Restsharp.Get.AddObjectParameter.Attributes;
using RestSharp;

namespace Restsharp.Get.AddObjectParameter.Extensions
{
    public static partial class RestRequestExtensions
    {
        static ParameterType GetParameterType(this MemberInfo propertyInfo)
            => propertyInfo.GetCustomAttribute<ParameterTypeAttribute>()?.ParameterType ?? ParameterType.GetOrPost;
    }
}