using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using OrderBuilderApi.Model;

namespace OrderBuilderApi.WebApi.Hypermedia
{
    public class ItemSpec : SingleStateResourceSpec<Item, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Carts({cartId})/Items({id})");

        protected override IEnumerable<ResourceLinkTemplate<Item>> Links()
        {
            yield return CreateLinkTemplate(LinkRelations.Cart, CartSpec.Uri, i => i.CartId);
        }
    }
}