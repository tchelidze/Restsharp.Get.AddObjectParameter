using System;
using System.Linq;
using System.Reflection;
using Restsharp.Get.AddObjectParameter.Attributes;

namespace Restsharp.Get.AddObjectParameter.Extensions
{
    public static partial class RestRequestExtensions
    {
        static string GetParameterValue(this PropertyInfo propertyInfo, object propertyOwner)
        {
            var bareValue = GetParameterBareValue(propertyInfo, propertyOwner);
            return bareValue?.ApplyFormatString(propertyInfo) ?? bareValue?.ToString();
        }

        static object GetParameterBareValue(this PropertyInfo propertyInfo, object propertyOwner)
        {
            var value = propertyInfo.GetValue(propertyOwner);
            if (value == null)
            {
                return propertyInfo.TryGetParameterDefaultValue();
            }

            if (propertyInfo.PropertyType.IsArray)
            {
                return value.AsArrayToParameterValue();
            }

            return value;
        }

        static string TryGetParameterDefaultValue(this MemberInfo propertyInfo)
        {
            var parameterDefaultValueAttribute = propertyInfo.GetCustomAttribute<ParameterDefaultValueAttribute>();
            return parameterDefaultValueAttribute?.DefaultValue.ToString();
        }

        static string AsArrayToParameterValue(this object arrayValue)
            => ((Array)arrayValue).OfType<object>().Aggregate("", (acc, cur) => $"{acc},{cur}");
    }
}