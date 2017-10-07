using Machine.Specifications;
using Restsharp.Get.AddObjectParameter.Attributes;
using Restsharp.Get.AddObjectParameter.Extensions;

// ReSharper disable ArrangeTypeMemberModifiers

namespace Restsharp.Get.AddObjectParameter.Spec
{
    [Subject(nameof(RestRequestExtensions))]
    public class when_parameter_with_properties_with_default_values_is_passed : RestRequestExtensions_spec_base<when_parameter_with_properties_with_default_values_is_passed.Parameter>
    {
        Because Context = () => { Request.Object.AddObjectParameter(ObjectParameter); };

        Establish Establish = () => { };

        It should_add_Name1_parameter_with_default_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name1) && (ti.Value as string) == ParameterDefaultValues.Name1))); };

        It should_add_Name2_parameter_with_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == "Name2" && int.Parse(ti.Value.ToString()) == ParameterDefaultValues.Name2))); };

        public class Parameter
        {
            [ParameterDefaultValue(ParameterDefaultValues.Name1)]
            public string Name1 { get; }

            [IncludeParameter]
            [ParameterDefaultValue(ParameterDefaultValues.Name2)]
            private int? Name2 { get; }
        }

        public class ParameterDefaultValues
        {
            public const string Name1 = "Dracula";

            public const int Name2 = 22;
        }
    }
}