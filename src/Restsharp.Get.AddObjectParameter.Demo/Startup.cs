using System;
using Restsharp.Get.AddObjectParameter.Attributes;
using Restsharp.Get.AddObjectParameter.Extensions;
using RestSharp;

// ReSharper disable ArrangeTypeMemberModifiers

namespace Restsharp.Get.AddObjectParameter.Demo
{
    public class Startup
    {
        public static void Main()
        {
            var request = new RestRequest("resource/{id}", Method.POST);
            request.AddObjectParameter(new ObjectParameterWithPublicPropertiesOnly());
        }

        public class ObjectParameterWithPublicPropertiesOnly
        {
            public string SimplePublicProperty { get; } = "Value33";

            [IncludeParameter]
            private double ExplicitlyIncludedPrivateProperty { get; } = 2.343;

            [ExcludeParameter]
            public bool ExplicitlyExcludedPrivateProperty { get; } = true;

            [ParameterFormatString("F")]
            public double FormattedPublicProperty { get; } = 52.02947819434;

            [ParameterDefaultValue("Dracula")]
            public string PropertywithDefaultValue { get; } = null;

            [ParameterFormatString("SomeFormatString")]
            public FormattableObject CustomFormattableProperty { get; } = new FormattableObject();

            public class FormattableObject
            {
                public string ToString(string format) => $"Formatted as {format}";
            }
        }
    }
}