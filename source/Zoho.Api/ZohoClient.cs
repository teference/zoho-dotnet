namespace Teference.Zoho.Api
{
    #region Namespace

    using System;

    #endregion

    public sealed class ZohoClient : IZohoClient
    {
        #region Variable declaration

        internal bool isConfigSet;

        #endregion

        #region Constructor

        public ZohoClient()
        {
        }

        public ZohoClient(ZohoConfig configuration) : this()
        {
            if(null == configuration)
            {
                return;
            }

            if(string.IsNullOrEmpty(configuration.OrganizationId) || configuration.OrganizationId.Trim() == string.Empty)
            {
                throw new ArgumentNullException("Zoho config - Organization Id cannot be null");
            }

            if (string.IsNullOrEmpty(configuration.AuthToken) || configuration.AuthToken.Trim() == string.Empty)
            {
                throw new ArgumentNullException("Zoho config - Authorization token cannot be null");
            }

            this.Configuration = configuration;
            this.isConfigSet = true;
        }

        #endregion

        #region Properties

        public ZohoConfig Configuration { get; set; }

        #endregion
    }
}