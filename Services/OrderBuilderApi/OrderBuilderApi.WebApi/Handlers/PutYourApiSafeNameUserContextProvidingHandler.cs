using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.AspNet.Handlers;
using IQ.Platform.Framework.WebApi.Services.Security;
using OrderBuilderApi.ApiServices.Security;

namespace OrderBuilderApi.WebApi.Handlers
{
    public class PutYourApiSafeNameUserContextProvidingHandler
            : ApiSecurityContextProvidingHandler<OrderBuilderApiApiUser, NullUserContext>
    {

        public PutYourApiSafeNameUserContextProvidingHandler(
            IStoreDataInHttpRequest<OrderBuilderApiApiUser> apiUserInRequestStore)
            : base(new OrderBuilderApiUserFactory(), CreateContextProvider(), apiUserInRequestStore)
        {
        }

        static ApiUserContextProvider<OrderBuilderApiApiUser, NullUserContext> CreateContextProvider()
        {
            return
                new ApiUserContextProvider<OrderBuilderApiApiUser, NullUserContext>(_ => new NullUserContext());
        }
    }
}