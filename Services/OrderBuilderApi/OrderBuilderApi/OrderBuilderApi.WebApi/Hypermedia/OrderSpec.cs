using System.Collections.Generic;
using OrderBuilderApi.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;

namespace OrderBuilderApi.WebApi.Hypermedia
{
    public class OrderSpec : ResourceSpec<Order, OrderStatus, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Orders({id})");

        protected override IEnumerable<IResourceStateSpec<Order, OrderStatus, int>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<Order, OrderStatus, int>(OrderStatus.Created)
            {
                Operations =
                {
                    InitialPost = ServiceOperations.Create
                }
            };

            yield return new ResourceStateSpec<Order, OrderStatus, int>(OrderStatus.NeedsShippingDetails)
            {
                Operations =
                {
                    Put = ServiceOperations.Update
                },
                Links =
                    {
                        CreateLinkTemplate(LinkRelations.Order, Uri, o => o.Id),
                        CreateLinkTemplate(LinkRelations.AddShippingDetails, Uri, o => o.Id)
                    }
            };

            yield return new ResourceStateSpec<Order, OrderStatus, int>(OrderStatus.WaitingForPayment)
            {
                Operations =
                {
                    Put = ServiceOperations.Update
                },
                Links =
                    {
                        CreateLinkTemplate(LinkRelations.Order, Uri, o => o.Id),
                        CreateLinkTemplate(LinkRelations.ConfirmPayment, Uri, o => o.Id)
                    }
            };

            yield return new ResourceStateSpec<Order, OrderStatus, int>(OrderStatus.WaitingForConfirmation)
            {
                Operations =
                {
                    Put = ServiceOperations.Update
                },
                Links =
                    {
                        CreateLinkTemplate(LinkRelations.Order, Uri, o => o.Id),
                        CreateLinkTemplate(LinkRelations.ConfirmOrder, Uri, o => o.Id)
                    }
            };

            yield return new ResourceStateSpec<Order, OrderStatus, int>(OrderStatus.Completed)
            {
                Operations =
                {
                    Put = ServiceOperations.Update
                },
                Links =
                    {
                        CreateLinkTemplate(LinkRelations.Order, Uri, o => o.Id)
                    }
            };
        }

        public override string EntrypointRelation
        {
            get { return LinkRelations.Order; }
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