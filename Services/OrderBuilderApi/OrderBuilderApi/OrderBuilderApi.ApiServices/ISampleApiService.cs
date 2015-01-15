using OrderBuilderApi.Model;
using IQ.Platform.Framework.WebApi;

namespace OrderBuilderApi.ApiServices
{
    public interface ISampleApiService :
        IGetAResourceAsync<Cart, int>,
        IGetManyOfAResourceAsync<Cart, int>,
        ICreateAResourceAsync<Cart, int>,
        IUpdateAResourceAsync<Cart, int>,
        IDeleteResourceAsync<Cart, int>
    {
    }
}
