namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Teference.Zoho.Api.Internals;

    #endregion

    internal sealed class ZsSettingsApi : IZsSettingsApi
    {
        #region Variable declaration

        private IZohoClient client;

        #endregion

        #region Constructor

        public ZsSettingsApi(IZohoClient client)
        {
            this.client = client;
        }

        #endregion

        #region Methods

        public async Task<ZsTaxes> GetAllTaxesAsync()
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAllTaxesAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId);
        }
        public async Task<ZsTaxes> GetAllTaxesAsync(string apiBaseUrl, string authToken, string organizationId)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();
            
            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsGetTaxes));
                var processResult = await response.ProcessResponse<ZsTaxes>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }
        
        #endregion
    }
}