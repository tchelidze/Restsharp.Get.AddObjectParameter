using System;
using Machine.Specifications;
using Restsharp.Get.AddObjectParameter.Attributes;
using Restsharp.Get.AddObjectParameter.Extensions;

// ReSharper disable ArrangeTypeMemberModifiers

namespace Restsharp.Get.AddObjectParameter.Spec
{
    [Subject(nameof(RestRequestExtensions))]
    public class when_parameter_with_custom_formatted_public_properties_is_passed : RestRequestExtensions_spec_base<when_parameter_with_custom_formatted_public_properties_is_passed.Parameter>
    {
        Because Context = () => { Request.Object.AddObjectParameter(ObjectParameter); };

        Establish Establish = () => { };

        It should_add_Name2_parameter_with_custom_name_and_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name2) && ti.Value.ToString() == ObjectParameter.Name2.ToString(CustomParameterFormats.Name2)))); };

        It should_add_Name3_parameter_with_custom_name_and_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == "Name3" && ti.Value.ToString() == ObjectParameter.GetName3().ToString(CustomParameterFormats.Name3)))); };

        It should_add_Name4_parameter_with_custom_name_and_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name4) && ti.Value.ToString() == ObjectParameter.Name4.ToString(CustomParameterFormats.Name4)))); };

        It should_add_Name5_parameter_with_custom_name_and_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == "Name5" && ti.Value.ToString() == ObjectParameter.GetName5().ToString(CustomParameterFormats.Name5)))); };

        public class Parameter
        {
            [IncludeParameter]
            [ParameterFormatString(CustomParameterFormats.Name2)]
            public int Name2 { get; } = 2;

            [IncludeParameter]
            [ParameterFormatString(CustomParameterFormats.Name3)]
            private double Name3 { get; } = 2.343;

            [IncludeParameter]
            [ParameterFormatString(CustomParameterFormats.Name4)]
            internal DateTime Name4 { get; } = DateTime.Now;

            [IncludeParameter]
            [ParameterFormatString(CustomParameterFormats.Name5)]
            protected FormattableObject Name5 { get; } = new FormattableObject();

            public double GetName3() => Name3;

            public FormattableObject GetName5() => Name5;

            public class FormattableObject
            {
                public string ToString(string format) => $"Formatted as {format}";
            }
        }

        public class CustomParameterFormats
        {
            public const string Name2 = "E";

            public const string Name3 = "C";

            public const string Name4 = "F";

            public const string Name5 = "SomeFormatString";
        }
    }
}