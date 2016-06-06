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
        }

        #endregion

        #region Properties

        public IZsProductApi Products { get; private set; }
        public IZsPlanApi Plans { get; private set; }
        public IZsAddonApi Addons { get; private set; }

        #endregion
    }
}