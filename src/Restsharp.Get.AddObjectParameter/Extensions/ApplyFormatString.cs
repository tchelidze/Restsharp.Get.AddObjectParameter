using System;
using System.Reflection;
using Restsharp.Get.AddObjectParameter.Attributes;
using Restsharp.Get.AddObjectParameter.Exceptions;

namespace Restsharp.Get.AddObjectParameter.Extensions
{
    public static partial class RestRequestExtensions
    {
        static string ApplyFormatString(this object value, PropertyInfo propertyInfo)
        {
            var formatStringAttribute = propertyInfo.GetCustomAttribute<ParameterFormatStringAttribute>();
            if (formatStringAttribute != null)
            {
                return ApplyToStringFormatting(value, propertyInfo, formatStringAttribute);
            }

            var parameterFormatterAttribute = propertyInfo.GetCustomAttribute<ParameterFormatterAttribute>();
            if (parameterFormatterAttribute != null)
            {
                return ApplyParameterFormatterFormatting(value, propertyInfo, parameterFormatterAttribute);
            }

            return null;
        }

        static string ApplyToStringFormatting(this object value, PropertyInfo propertyInfo, ParameterFormatStringAttribute formatStringAttribute)
        {
            var formatterToStringMethodOfParameterValue = propertyInfo.PropertyType.GetTypeInfo().GetMethod(nameof(DateTime.ToString), new[] {typeof(string)});
            if (formatterToStringMethodOfParameterValue != null)
            {
                return (string) formatterToStringMethodOfParameterValue.Invoke(value, new object[] {formatStringAttribute.FormatString});
            }

            return value.ToString();
        }

        static string ApplyParameterFormatterFormatting(this object value, PropertyInfo propertyInfo, ParameterFormatterAttribute formatStringAttribute)
        {
            var formatterType = formatStringAttribute.FormatterType;
            if (!typeof(IParameterFormatter).GetTypeInfo().IsAssignableFrom(formatterType))
            {
                throw new InvalidParameterFormatterException(formatterType);
            }

            var parameterFormatter = (IParameterFormatter) Activator.CreateInstance(formatterType);
            return parameterFormatter.Format(value);
        }
    }
}