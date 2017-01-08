namespace Teference.Zoho.Api
{
    #region Namespace

    using Internals;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    #endregion

    internal sealed class ZsHostedPageApi : IZsHostedPageApi
    {
        #region Variable declaration

        private IZohoClient client;

        #endregion

        #region Constructor

        public ZsHostedPageApi(IZohoClient client)
        {
            this.client = client;
        }

        #endregion

        #region Methods

        public async Task<ZsHostedPageDetail> GetAsync(string hostedPageId)
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, hostedPageId);
        }

        public async Task<ZsHostedPageDetail> GetAsync(string authToken, string organizationId, string hostedPageId)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(hostedPageId))
            {
                throw new ArgumentNullException("Hosted page id is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsGetHostedPlan, hostedPageId));
                var processResult = await response.ProcessResponse<ZsHostedPageDetail>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<ZsHostedPages> GetAllAsync()
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAllAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId);
        }
        public async Task<ZsHostedPages> GetAllAsync(string authToken, string organizationId)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.GetAsync(ApiResources.ZsGetHostedPageAll);
                var processResult = await response.ProcessResponse<ZsHostedPages>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<ZsHostedPage> CreateSubscriptionAsync(ZsHostedPageCreateSubscriptionInput hostedPageCreateSubscription)
        {
            this.client.Configuration.CheckConfig();
            return await this.CreateSubscriptionAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, hostedPageCreateSubscription);
        }
        public async Task<ZsHostedPage> CreateSubscriptionAsync(string authToken, string organizationId, ZsHostedPageCreateSubscriptionInput hostedPageCreateSubscription)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            var validationResult = hostedPageCreateSubscription.Validate();
            if (!string.IsNullOrWhiteSpace(validationResult))
            {
                throw new ArgumentException(validationResult);
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var content = new StringContent(
                    JsonConvert.SerializeObject(
                        hostedPageCreateSubscription,
                        Formatting.None,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    Encoding.UTF8,
                    "application/json");
                var response = await httpClient.PostAsync(ApiResources.ZsPostHostedPageCreateSubscription, content);
                var processResult = await response.ProcessResponse<ZsHostedPageJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.HostedPage;
            }
        }

        public async Task<ZsHostedPage> UpdateSubscriptionAsync(ZsHostedPageUpdateSubscriptionInput hostedPageUpdateSubscription)
        {
            this.client.Configuration.CheckConfig();
            return await this.UpdateSubscriptionAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, hostedPageUpdateSubscription);
        }

        public async Task<ZsHostedPage> UpdateSubscriptionAsync(string authToken, string organizationId, ZsHostedPageUpdateSubscriptionInput hostedPageUpdateSubscription)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            var validationResult = hostedPageUpdateSubscription.Validate();
            if (!string.IsNullOrWhiteSpace(validationResult))
            {
                throw new ArgumentException(validationResult);
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var content = new StringContent(
                    JsonConvert.SerializeObject(
                        hostedPageUpdateSubscription,
                        Formatting.None,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    Encoding.UTF8,
                    "application/json");
                var response = await httpClient.PostAsync(ApiResources.ZsPostHostedPageUpdateSubscription, content);
                var processResult = await response.ProcessResponse<ZsHostedPageJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.HostedPage;
            }
        }

        public async Task<ZsHostedPage> UpdateCardAsync(ZsHostedPageUpdateCardInput hostedPageUpdateCard)
        {
            this.client.Configuration.CheckConfig();
            return await this.UpdateCardAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, hostedPageUpdateCard);
        }
        public async Task<ZsHostedPage> UpdateCardAsync(string authToken, string organizationId, ZsHostedPageUpdateCardInput hostedPageUpdateCard)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            var validationResult = hostedPageUpdateCard.Validate();
            if (!string.IsNullOrWhiteSpace(validationResult))
            {
                throw new ArgumentException(validationResult);
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var content = new StringContent(
                    JsonConvert.SerializeObject(
                        hostedPageUpdateCard,
                        Formatting.None,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    Encoding.UTF8,
                    "application/json");
                var response = await httpClient.PostAsync(ApiResources.ZsPostHostedPageUpdateCard, content);
                var processResult = await response.ProcessResponse<ZsHostedPageJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.HostedPage;
            }
        }

        public async Task<ZsHostedPage> BuyOneTimeAddonAsync(ZsHostedPageBuyAddonInput hostedPageBuyAddon)
        {
            this.client.Configuration.CheckConfig();
            return await this.BuyOneTimeAddonAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, hostedPageBuyAddon);
        }
        public async Task<ZsHostedPage> BuyOneTimeAddonAsync(string authToken, string organizationId, ZsHostedPageBuyAddonInput hostedPageBuyAddon)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            var validationResult = hostedPageBuyAddon.Validate();
            if (!string.IsNullOrWhiteSpace(validationResult))
            {
                throw new ArgumentException(validationResult);
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var content = new StringContent(
                    JsonConvert.SerializeObject(
                        hostedPageBuyAddon,
                        Formatting.None,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    Encoding.UTF8,
                    "application/json");
                var response = await httpClient.PostAsync(ApiResources.ZsPostHostedPageBuyAddon, content);
                var processResult = await response.ProcessResponse<ZsHostedPageJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.HostedPage;
            }
        }

        #endregion
    }
}