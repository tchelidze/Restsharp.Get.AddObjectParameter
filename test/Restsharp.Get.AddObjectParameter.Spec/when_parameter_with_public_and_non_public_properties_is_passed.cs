using System;
using Machine.Specifications;
using Moq;
using Restsharp.Get.AddObjectParameter.Extensions;
using It = Machine.Specifications.It;

// ReSharper disable ArrangeTypeMemberModifiers

namespace Restsharp.Get.AddObjectParameter.Spec
{
    [Subject(nameof(RestRequestExtensions))]
    public class when_parameter_with_public_and_non_public_properties_is_passed : RestRequestExtensions_spec_base<when_parameter_with_public_and_non_public_properties_is_passed.Parameter>
    {
        Because Context = () => { Request.Object.AddObjectParameter(ObjectParameter); };

        Establish Establish = () => { };

        It should_add_Name1_parameter_with_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name1) && ti.Value as string == ObjectParameter.Name1))); };

        It should_add_Name2_parameter_with_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name2) && ti.Value.ToString() == ObjectParameter.Name2.ToString()))); };

        It should_not_add_Name3_parameter =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == "Name3")), Times.Never); };

        It should_not_add_Name4_parameter =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name4))), Times.Never); };

        It should_not_add_Name5_parameter =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == "Name5")), Times.Never); };

        public class Parameter
        {
            public string Name1 { get; } = "Value33";

            public DateTime Name2 { get; } = DateTime.Now;

            private double Name3 { get; } = 2.343;

            internal bool Name4 { get; } = true;

            protected bool Name5 { get; } = true;
        }
    }
}