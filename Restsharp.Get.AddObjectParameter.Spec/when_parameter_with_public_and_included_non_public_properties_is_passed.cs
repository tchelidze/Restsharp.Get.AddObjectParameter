using System;
using Machine.Specifications;
using Restsharp.Get.AddObjectParameter.Attributes;
using Restsharp.Get.AddObjectParameter.Extensions;

// ReSharper disable ArrangeTypeMemberModifiers

namespace Restsharp.Get.AddObjectParameter.Spec
{
    [Subject(nameof(RestRequestExtensions))]
    public class when_parameter_with_public_and_included_non_public_properties_is_passed : RestRequestExtensions_spec_base<when_parameter_with_public_and_included_non_public_properties_is_passed.Parameter>
    {
        Because Context = () => { Request.Object.AddObjectParameter(ObjectParameter); };

        Establish Establish = () => { };

        It should_add_Name1_parameter_with_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name1) && ti.Value as string == ObjectParameter.Name1))); };

        It should_add_Name2_parameter_with_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name2) && ti.Value.ToString() == ObjectParameter.Name2.ToString()))); };

        It should_add_Name3_parameter_with_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == "Name3" && float.Parse(ti.Value.ToString()) == ObjectParameter.GetName3()))); };

        It should_add_Name4_parameter_with_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name4) && bool.Parse(ti.Value.ToString()) == ObjectParameter.Name4))); };

        It should_add_Name5_parameter_with_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == "Name5" && char.Parse(ti.Value.ToString()) == ObjectParameter.GetName5()))); };

        public class Parameter
        {
            public string Name1 { get; } = "Value33";

            public DateTime Name2 { get; } = DateTime.Now;

            [IncludeParameter]
            private float Name3 { get; } = 2.343f;

            [IncludeParameter]
            internal bool Name4 { get; } = true;

            [IncludeParameter]
            protected char Name5 { get; } = 's';

            public float GetName3() => Name3;

            public char GetName5() => Name5;
        }
    }
}