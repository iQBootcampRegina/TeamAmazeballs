using IQ.Platform.Framework.Common;
using OrderBuilderApi.Model;
using IQ.Platform.Framework.WebApi;

namespace OrderBuilderApi.ApiServices
{
    public interface IApiService<T, I> :
        IGetAResourceAsync<T, I>,
        IGetManyOfAResourceAsync<T, I>,
        ICreateAResourceAsync<T, I>,
        IUpdateAResourceAsync<T, I>,
        IDeleteResourceAsync<T, I> where T : IIdentifiable<I>
    {
    }
}
