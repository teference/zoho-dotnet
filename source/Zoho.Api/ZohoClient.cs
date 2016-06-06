namespace Teference.Zoho.Api
{
    #region Namespace

    using Internals;

    #endregion

    public sealed class ZohoClient : IZohoClient
    {
        #region Constructor

        public ZohoClient()
        {
            this.Subscription = new SubscriptionApi(this);
        }

        public ZohoClient(ZohoConfig configuration) : this()
        {
            configuration.CheckConfig();
            this.Configuration = configuration;
        }

        #endregion

        #region Properties

        public ZohoConfig Configuration { get; set; }
        public ISubscriptionApi Subscription { get; private set; }

        #endregion
    }
}