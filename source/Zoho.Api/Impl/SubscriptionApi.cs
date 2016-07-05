namespace Teference.Zoho.Api
{
    internal class SubscriptionApi : ISubscriptionApi
    {
        #region Variable declaration

        private IZohoClient zohoClient;

        #endregion

        #region Constructor

        public SubscriptionApi(IZohoClient zohoClient)
        {
            this.zohoClient = zohoClient;
            this.Products = new ZsProductApi(this.zohoClient);
            this.Plans = new ZsPlanApi(this.zohoClient);
            this.Addons = new ZsAddonApi(this.zohoClient);
            this.Coupons = new ZsCouponApi(this.zohoClient);
            this.Customers = new ZsCustomerApi(this.zohoClient);
            this.Cards = new ZsCardApi(this.zohoClient);
            this.ContactPersons = new ZsContactPersonApi(this.zohoClient);
            this.Subscriptions = new ZsSubscriptionApi(this.zohoClient);
            this.HostedPage = new ZsHostedPageApi(this.zohoClient);
            this.Invoices = new ZsInvoiceApi(this.zohoClient);
        }

        #endregion

        #region Properties

        public IZsProductApi Products { get; private set; }
        public IZsPlanApi Plans { get; private set; }
        public IZsAddonApi Addons { get; private set; }
        public IZsCouponApi Coupons { get; private set; }
        public IZsCustomerApi Customers { get; private set; }
        public IZsCardApi Cards { get; private set; }
        public IZsContactPersonApi ContactPersons { get; private set; }
        public IZsSubscriptionApi Subscriptions { get; private set; }
        public IZsHostedPageApi HostedPage { get; private set; }
        public IZsInvoiceApi Invoices { get; private set; }

        #endregion
    }
}