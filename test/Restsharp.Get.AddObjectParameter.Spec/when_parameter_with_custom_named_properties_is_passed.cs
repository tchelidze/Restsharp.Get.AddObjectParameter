using Machine.Specifications;
using Restsharp.Get.AddObjectParameter.Attributes;
using Restsharp.Get.AddObjectParameter.Extensions;

// ReSharper disable ArrangeTypeMemberModifiers

namespace Restsharp.Get.AddObjectParameter.Spec
{
    [Subject(nameof(RestRequestExtensions))]
    public class when_parameter_with_custom_named_properties_is_passed : RestRequestExtensions_spec_base<when_parameter_with_custom_named_properties_is_passed.Parameter>
    {
        Because Context = () => { Request.Object.AddObjectParameter(ObjectParameter); };

        Establish Establish = () => { };

        It should_add_Name2_parameter_with_custom_name_and_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == CustomParameterNames.Name2 && int.Parse(ti.Value.ToString()) == ObjectParameter.Name2))); };

        It should_add_Name3_parameter_with_custom_name_and_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == CustomParameterNames.Name3 && double.Parse(ti.Value.ToString()) == ObjectParameter.GetName3()))); };

        It should_add_Name4_parameter_with_custom_name_and_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == CustomParameterNames.Name4 && bool.Parse(ti.Value.ToString()) == ObjectParameter.Name4))); };

        It should_add_Name5_parameter_with_custom_name_and_corresponding_value =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == CustomParameterNames.Name5 && bool.Parse(ti.Value.ToString()) == ObjectParameter.GetName5()))); };

        public class Parameter
        {
            [IncludeParameter]
            [ParameterName(CustomParameterNames.Name2)]
            public int Name2 { get; } = 2;

            [IncludeParameter]
            [ParameterName(CustomParameterNames.Name3)]
            private double Name3 { get; } = 2.343;

            [IncludeParameter]
            [ParameterName(CustomParameterNames.Name4)]
            internal bool Name4 { get; } = true;

            [IncludeParameter]
            [ParameterName(CustomParameterNames.Name5)]
            protected bool Name5 { get; } = true;

            public double GetName3() => Name3;

            public bool GetName5() => Name5;
        }

        public class CustomParameterNames
        {
            public const string Name2 = "CustomName2";

            public const string Name3 = "CustomName3";

            public const string Name4 = "CustomName4";

            public const string Name5 = "CustomName5";
        }
    }
}