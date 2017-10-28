using System;
using System.Reflection;

namespace Restsharp.Get.AddObjectParameter.Extensions
{
    internal static class PropertyInfoExtensions
    {
        internal static bool HasCustomAttribute<TAttribute>(this PropertyInfo propertyInfo)
            where TAttribute : Attribute
            => propertyInfo.GetCustomAttribute<TAttribute>() != null;

        internal static bool DoesNotHaveCustomAttribute<TAttribute>(this PropertyInfo propertyInfo)
            where TAttribute : Attribute
            => !propertyInfo.HasCustomAttribute<TAttribute>();
    }
}