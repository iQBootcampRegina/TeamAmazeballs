using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace OrderBuilderApi.Model
{
    /// <summary>
    /// A Sample Resource, used as a placeholder. To be removed after real-world API resources have been added.
    /// </summary>
    public class Cart : IStatefulResource<CartStatus>, IIdentifiable<int>
    {
        /// <summary>
        /// Unique Identifier for the cart
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The current status of the cart. Ex: Empty, HasItems.
        /// </summary>
        public CartStatus Status { get; set; }
    }
}
