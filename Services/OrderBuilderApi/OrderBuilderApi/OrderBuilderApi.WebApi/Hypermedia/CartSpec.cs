using System.Collections.Generic;
using OrderBuilderApi.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;

namespace OrderBuilderApi.WebApi.Hypermedia
{
    public class CartSpec : ResourceSpec<Cart, CartStatus, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Carts({id})");

        protected override IEnumerable<IResourceStateSpec<Cart, CartStatus, int>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<Cart, CartStatus, int>(CartStatus.Created)
                {
                    Operations =
                        {
                            InitialPost = ServiceOperations.Create
                        }
                };

            yield return new ResourceStateSpec<Cart, CartStatus, int>(CartStatus.Empty)
            {
                Operations =
                {
                    Delete = ServiceOperations.Delete
                },
                
                Links =
                    {
                        CreateLinkTemplate(LinkRelations.Cart, ItemSpec.Uri.Many, c => c.Id),
                    }
            };


            yield return new ResourceStateSpec<Cart, CartStatus, int>(CartStatus.HasItems)
            {
                Operations =
                {
                    Delete = ServiceOperations.Delete
                },

                Links =
                    {
                        CreateLinkTemplate(LinkRelations.Cart, ItemSpec.Uri.Many, c => c.Id),
                    }
            };
        }

        public override string EntrypointRelation
        {
            get { return LinkRelations.Cart; }
        }


        // IResourceStateSpec is not required but can be overridden to define custom operations and links.
        // See example below...
        //
        //public override IResourceStateSpec<SampleResource, NullState, string> StateSpec
        //{
        //    get
        //    {
        //        return
        //            new SingleStateSpec<SampleResource, string>
        //            {
        //                Links =
        //                {
        //                    CreateLinkTemplate(LinkRelations.SampleResource2, OrganizationSpec2.Uri, r => r.Id),
        //                },

        //                Operations = new StateSpecOperationsSource<SampleResource, string>
        //                {
        //                    Get = ServiceOperations.Get,
        //                    InitialPost = ServiceOperations.Create,
        //                    Post = ServiceOperations.Update,
        //                    Delete = ServiceOperations.Delete,
        //                },
        //            };
        //    }
        //}

    }
}