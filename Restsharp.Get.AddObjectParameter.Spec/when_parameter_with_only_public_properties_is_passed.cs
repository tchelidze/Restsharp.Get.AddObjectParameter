using Machine.Specifications;
using Restsharp.Get.AddObjectParameter.Extensions;

namespace Restsharp.Get.AddObjectParameter.Spec
{
    [Subject(nameof(RestRequestExtensions))]
    public class when_parameter_with_only_public_properties_is_passed : RestRequestExtensions_spec_base<when_parameter_with_only_public_properties_is_passed.Parameter>
    {
        Because Context = () => { Request.Object.AddObjectParameter(ObjectParameter); };

        Establish Establish = () => { };

        It should_add_Name1_parameter_with_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name1) && ti.Value as string == ObjectParameter.Name1))); };

        It should_add_Name2_parameter_with_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name2) && int.Parse(ti.Value.ToString()) == ObjectParameter.Name2))); };

        public class Parameter
        {
            public string Name1 { get; } = "Value33";

            public int Name2 { get; } = 2;
        }
    }
}