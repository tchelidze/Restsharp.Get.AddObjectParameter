using System.Linq;
using System.Reflection;
using Restsharp.Get.AddObjectParameter.Attributes;
using RestSharp;

namespace Restsharp.Get.AddObjectParameter.Extensions
{
    public static partial class RestRequestExtensions
    {
        /// <summary>
        ///     Add the objects public (if not configured otherwise) readable  properties as parameters to the request
        /// </summary>
        /// <param name="restRequest"> Request to add parameter to </param>
        /// <param name="parameter"> Object containing parameters as properties </param>
        /// <returns></returns>
        public static IRestRequest AddObjectParameter(this IRestRequest restRequest, object parameter)
        {
            parameter
                .GetType()
                .GetTypeInfo()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(it => it.CanRead)
                .Where(it => it.GetMethod.IsPublic || it.HasCustomAttribute<IncludeParameterAttribute>())
                .Where(it => it.DoesNotHaveCustomAttribute<ExcludeParameterAttribute>())
                .Select(it => new Parameter
                {
                    Name = it.GetCustomAttribute<ParameterNameAttribute>()?.ParameterName ?? it.Name,
                    Value = it.GetParameterValue(parameter)
                })
                .Where(it => it.Value != null)
                .ToList()
                .ForEach(it => restRequest.AddParameter(it));

            return restRequest;
        }
    }
}