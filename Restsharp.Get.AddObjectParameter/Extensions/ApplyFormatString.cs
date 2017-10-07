using System;
using System.Reflection;
using Restsharp.Get.AddObjectParameter.Attributes;

namespace Restsharp.Get.AddObjectParameter.Extensions
{
    public static partial class RestRequestExtensions
    {
        static string ApplyFormatString(this object value, PropertyInfo propertyInfo)
        {
            var formatStringAttribute = propertyInfo.GetCustomAttribute<ParameterFormatStringAttribute>();
            if (formatStringAttribute == null)
            {
                return null;
            }

            var formatterToStringMethodOfParameterValue = propertyInfo.PropertyType.GetTypeInfo().GetMethod(nameof(DateTime.ToString), new[] {typeof(string)});
            if (formatterToStringMethodOfParameterValue != null)
            {
                return (string) formatterToStringMethodOfParameterValue.Invoke(value, new object[] {formatStringAttribute.FormatString});
            }

            return value.ToString();
        }
    }
}