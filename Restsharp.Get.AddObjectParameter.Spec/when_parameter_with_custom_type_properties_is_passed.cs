using Machine.Specifications;
using Restsharp.Get.AddObjectParameter.Attributes;
using Restsharp.Get.AddObjectParameter.Extensions;
using RestSharp;

// ReSharper disable ArrangeTypeMemberModifiers

namespace Restsharp.Get.AddObjectParameter.Spec
{
    [Subject(nameof(RestRequestExtensions))]
    public class when_parameter_with_custom_type_properties_is_passed : RestRequestExtensions_spec_base<when_parameter_with_custom_type_properties_is_passed.Parameter>
    {
        Because Context = () => { Request.Object.AddObjectParameter(ObjectParameter); };

        Establish Establish = () => { };

        It should_add_Name2_parameter_with_custom_type =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name2) && ti.Type == CustomParameterType.Name2))); };

        It should_add_Name3_parameter_with_custom_type =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == "Name3" && ti.Type == CustomParameterType.Name3))); };

        It should_add_Name4_parameter_with_custom_type =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name4) && ti.Type == CustomParameterType.Name4))); };

        It should_add_Name5_parameter_with_custom_type =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == "Name5" && ti.Type == CustomParameterType.Name5))); };

        It should_add_Name6_parameter_with_custom_type =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name6) && ti.Type == CustomParameterType.Name6))); };

        It should_add_Name7_parameter_with_custom_type =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name7) && ti.Type == CustomParameterType.Name7))); };

        It should_add_Name8_parameter_with_default_type =
            () => { Request.Verify(it => it.AddParameter(Moq.It.Is<RestSharp.Parameter>(ti => ti.Name == nameof(Parameter.Name8) && ti.Type == CustomParameterType.Default))); };

        public class Parameter
        {
            [IncludeParameter]
            [ParameterType(ParameterType.Cookie)]
            public int Name2 { get; } = 2;

            [IncludeParameter]
            [ParameterType(ParameterType.GetOrPost)]
            private double Name3 { get; } = 2.343;

            [IncludeParameter]
            [ParameterType(ParameterType.UrlSegment)]
            internal bool Name4 { get; } = true;

            [IncludeParameter]
            [ParameterType(ParameterType.HttpHeader)]
            protected bool Name5 { get; } = true;

            [IncludeParameter]
            [ParameterType(ParameterType.RequestBody)]
            public bool Name6 { get; } = true;

            [IncludeParameter]
            [ParameterType(ParameterType.QueryString)]
            public bool Name7 { get; } = true;

            [IncludeParameter]
            public bool Name8 { get; } = true;

            public double GetName3() => Name3;

            public bool GetName5() => Name5;
        }

        public class CustomParameterType
        {
            public const ParameterType Name2 = ParameterType.Cookie;

            public const ParameterType Name3 = ParameterType.GetOrPost;

            public const ParameterType Name4 = ParameterType.UrlSegment;

            public const ParameterType Name5 = ParameterType.HttpHeader;

            public const ParameterType Name6 = ParameterType.RequestBody;

            public const ParameterType Name7 = ParameterType.QueryString;

            public const ParameterType Default = ParameterType.GetOrPost;
        }
    }
}