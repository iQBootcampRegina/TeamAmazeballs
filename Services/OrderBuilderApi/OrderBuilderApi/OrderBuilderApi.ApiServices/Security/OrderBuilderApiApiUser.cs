using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace OrderBuilderApi.ApiServices.Security
{

    public class OrderBuilderApiApiUser : ApiUser<UserAuthData>
    {
        public OrderBuilderApiApiUser(string name, Option<UserAuthData> authData)
            : base(authData)
        {
            Name = name;
        }

        public string Name { get; private set; }

    }

    public class OrderBuilderApiUserFactory : ApiUserFactory<OrderBuilderApiApiUser, UserAuthData>
    {
        public OrderBuilderApiUserFactory() :
            base(new HttpRequestDataStore<UserAuthData>())
        {
        }

        protected override OrderBuilderApiApiUser CreateUser(Option<UserAuthData> auth)
        {
            return new OrderBuilderApiApiUser("OrderBuilderApi user", auth);
        }
    }

}
