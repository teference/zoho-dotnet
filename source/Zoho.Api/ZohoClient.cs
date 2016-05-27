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
            this.ZsProductApi = new ZsProductApi(this);
            this.ZsPlanApi = new ZsPlanApi(this);
        }

        public ZohoClient(ZohoConfig configuration) : this()
        {
            configuration.CheckConfig();
            this.Configuration = configuration;
        }

        #endregion

        #region Properties

        public ZohoConfig Configuration { get; set; }

        public IZsProductApi ZsProductApi { get; private set; }
        public IZsPlanApi ZsPlanApi { get; private set; }

        #endregion
    }
}