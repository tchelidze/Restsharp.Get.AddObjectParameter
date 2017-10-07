using Moq;
using RestSharp;

namespace Restsharp.Get.AddObjectParameter.Spec
{
    public class RestRequestExtensions_spec_base<TObjectParameter>
        where TObjectParameter : new()
    {
        protected static readonly Mock<IRestRequest> Request = new Mock<IRestRequest>();

        protected static readonly TObjectParameter ObjectParameter = new TObjectParameter();
    }
}