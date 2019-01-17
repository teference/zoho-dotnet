namespace Teference.Zoho.Api
{
    public interface ISubscriptionApi
    {
        /// <summary>
        /// Provides contract(s) API methods for zoho subscription product.
        /// </summary>
        IZsProductApi Products { get; }

        /// <summary>
        /// Provides contract(s) API methods for zoho subscription plan.
        /// </summary>
        IZsPlanApi Plans { get; }

        /// <summary>
        /// Provides contract(s) API methods for zoho subscription add-on.
        /// </summary>
        IZsAddonApi Addons { get; }

        /// <summary>
        /// Provides contract(s) API methods for zoho subscription coupon.
        /// </summary>
        IZsCouponApi Coupons { get; }

        /// <summary>
        /// Provides contract(s) API methods for zoho subscription customer.
        /// </summary>
        IZsCustomerApi Customers { get; }

        /// <summary>
        /// Provides contract(s) API methods for zoho subscription card.
        /// </summary>
        IZsCardApi Cards { get; }

        /// <summary>
        /// Provides contract(s) API methods for zoho subscription contact person.
        /// </summary>
        IZsContactPersonApi ContactPersons { get; }

        /// <summary>
        /// Provides contract(s) API methods for zoho subscription - subscription API fragment.
        /// </summary>
        IZsSubscriptionApi Subscriptions { get; }

        /// <summary>
        /// Provides contract(s) API methods for zoho subscription - hosted page API fragment.
        /// </summary>
        IZsHostedPageApi HostedPage { get; }

        /// <summary>
        /// Provides contract(s) API methods for zoho subscription - invoice API fragment.
        /// </summary>
        IZsInvoiceApi Invoices { get; }

        /// <summary>
        /// Provides contract(s) API methods for zoho subscription - settings API fragment.
        /// </summary>
        IZsSettingsApi Settings { get; }
    }
}