using OrderBuilderApi.Model;
using IQ.Platform.Framework.WebApi;

namespace OrderBuilderApi.ApiServices
{
    public interface ISampleApiService :
        IGetAResourceAsync<SampleResource, string>,
        IGetManyOfAResourceAsync<SampleResource, string>,
        ICreateAResourceAsync<SampleResource, string>,
        IUpdateAResourceAsync<SampleResource, string>,
        IDeleteResourceAsync<SampleResource, string>
    {
    }
}
