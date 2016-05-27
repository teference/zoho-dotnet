namespace Teference.Zoho.Api
{
    #region Namespace

    using Internals;
    using Models;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Threading.Tasks;

    #endregion

    internal sealed class ZsPlanApi : IZsPlanApi
    {
        #region Variable declaration

        private IZohoClient client;

        #endregion

        #region Constructor

        public ZsPlanApi(IZohoClient client)
        {
            this.client = client;
        }

        #endregion

        #region Methods

        public async Task<ZsPlans> GetAllAsync()
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAllAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId);
        }

        public async Task<ZsPlans> GetAllAsync(string authToken, string organizationId)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.GetAsync(ApiResources.ZsGetProductsAll);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ZsPlans>(rawResponseContent);
            }
        }

        #endregion
    }
}