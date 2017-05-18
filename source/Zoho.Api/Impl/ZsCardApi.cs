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

    internal sealed class ZsCardApi : IZsCardApi
    {
        #region Variable declaration

        private IZohoClient client;

        #endregion

        #region Constructor

        public ZsCardApi(IZohoClient client)
        {
            this.client = client;
        }

        #endregion

        #region Methods

        public async Task<ZsCard> GetAsync(string customerId, string cardId)
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, customerId, cardId);
        }

        public async Task<ZsCard> GetAsync(string apiBaseUrl, string authToken, string organizationId, string customerId, string cardId)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentNullException("customerId");
            }

            if (string.IsNullOrWhiteSpace(cardId))
            {
                throw new ArgumentNullException("cardId");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsGetCard, customerId, cardId));
                var processResult = await response.ProcessResponse<ZsCardJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Card;
            }
        }

        public async Task<ZsCard> CreateAsync(string customerId, ZsCardCreate createInput)
        {
            this.client.Configuration.CheckConfig();
            return await this.CreateAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, customerId, createInput);
        }

        public async Task<ZsCard> CreateAsync(string apiBaseUrl, string authToken, string organizationId, string customerId, ZsCardCreate createInput)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentNullException("customerId");
            }

            if (createInput == null)
            {
                throw new ArgumentNullException("createInput");
            }

            var validationResult = createInput.Validate();
            if (!string.IsNullOrWhiteSpace(validationResult))
            {
                throw new ArgumentException(validationResult);
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var content = new StringContent(
                    JsonConvert.SerializeObject(
                        createInput,
                        Formatting.None,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    Encoding.UTF8,
                    "application/json");
                var response = await httpClient.PostAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPostCard, customerId), content);
                var processResult = await response.ProcessResponse<ZsCardJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Card;
            }
        }

        public async Task<ZsCard> UpdateAsync(string customerId, string cardId, ZsCardUpdate updateInput)
        {
            this.client.Configuration.CheckConfig();
            return await this.UpdateAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, customerId, cardId, updateInput);
        }

        public async Task<ZsCard> UpdateAsync(string apiBaseUrl, string authToken, string organizationId, string customerId, string cardId, ZsCardUpdate updateInput)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentNullException("customerId");
            }

            if (string.IsNullOrWhiteSpace(cardId))
            {
                throw new ArgumentNullException("cardId");
            }

            if (updateInput == null)
            {
                throw new ArgumentNullException("updateInput");
            }

            var validationResult = updateInput.Validate();
            if (!string.IsNullOrWhiteSpace(validationResult))
            {
                throw new ArgumentException(validationResult);
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var content = new StringContent(JsonConvert.SerializeObject(updateInput), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPutCard, customerId, cardId), content);
                var processResult = await response.ProcessResponse<ZsCardJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Card;
            }
        }

        public async Task<bool> DeleteAsync(string customerId, string cardId)
        {
            this.client.Configuration.CheckConfig();
            return await this.DeleteAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, customerId, cardId);
        }

        public async Task<bool> DeleteAsync(string apiBaseUrl, string authToken, string organizationId, string customerId, string cardId)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentNullException("customerId");
            }

            if (string.IsNullOrWhiteSpace(cardId))
            {
                throw new ArgumentNullException("cardId");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var response = await httpClient.DeleteAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsDeleteCard, customerId, cardId));
                var processResult = await response.ProcessResponse<bool>();
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