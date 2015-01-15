namespace OrderBuilderApi.Model
{
    /// <summary>
    /// iQmetrix link relation names
    /// </summary>
    public static class LinkRelations
    {
        /// <summary>
        /// link relation to describe the Identity resource.
        /// </summary>
        public const string Cart = "iq:cart";

        public const string Order = "iq:order";

        public const string AddShippingDetails = "iq:add-shipping-details";

        public const string ConfirmPayment = "iq:confirm-payment";

        public const string ConfirmOrder = "iq:confirm-order";
    }
}
