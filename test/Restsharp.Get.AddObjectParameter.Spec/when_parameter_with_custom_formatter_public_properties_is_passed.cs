using Machine.Specifications;
using Restsharp.Get.AddObjectParameter.Attributes;
using Restsharp.Get.AddObjectParameter.Extensions;

// ReSharper disable ArrangeTypeMemberModifiers

namespace Restsharp.Get.AddObjectParameter.Spec
{
    [Subject(nameof(RestRequestExtensions))]
    public class when_parameter_with_custom_formatter_public_properties_is_passed : RestRequestExtensions_spec_base<when_parameter_with_custom_formatter_public_properties_is_passed.Parameter>
    {
        Because Context = () => { Request.Object.AddObjectParameter(ObjectParameter); };

        Establish Establish = () => { };

        It should_add_Name2_parameter_with_custom_formatted_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name2) && ti.Value.ToString() == "Y"))); };

        It should_add_Name3_parameter_with_custom_formatted_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name3) && ti.Value.ToString() == "N"))); };

        public class Parameter
        {
            [ParameterFormatter(typeof(BooleanCustomFormatter))]
            public bool Name2 { get; } = true;

            [ParameterFormatter(typeof(BooleanCustomFormatter))]
            public bool Name3 { get; } = false;
        }

        public class BooleanCustomFormatter : IParameterFormatter
        {
            public string Format(object parameterValue)
            {
                var value = (bool) parameterValue;
                return value ? "Y" : "N";
            }
        }
    }
}