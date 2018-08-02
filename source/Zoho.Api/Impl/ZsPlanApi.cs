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

        public async Task<ZsPlan> GetAsync(string code)
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, code);
        }
        public async Task<ZsPlan> GetAsync(string apiBaseUrl, string authToken, string organizationId, string code)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException("Plan code is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsGetPlan, code));
                var processResult = await response.ProcessResponse<ZsPlanJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Plan;
            }
        }

        public async Task<ZsPlans> GetAllAsync(ZsPage page = null)
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAllAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, page);
        }
        public async Task<ZsPlans> GetAllAsync(string apiBaseUrl, string authToken, string organizationId, ZsPage page = null)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var response = await httpClient.GetAsync(page.AppendTo(ApiResources.ZsGetPlansAll));
                var processResult = await response.ProcessResponse<ZsPlans>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<ZsPlans> GetAllAsync(string productId, ZsPage page = null)
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAllAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, productId, page);
        }
        public async Task<ZsPlans> GetAllAsync(string apiBaseUrl, string authToken, string organizationId, string productId, ZsPage page = null)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentNullException("Plan product id is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                
                var requestUri = new QueryStringBuilder(ApiResources.ZsGetPlansAll);
                requestUri.Add("product_id", productId);
                
                var response = await httpClient.GetAsync(page.AppendTo(requestUri).ToString());
                var processResult = await response.ProcessResponse<ZsPlans>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<ZsPlan> CreateAsync(ZsPlanCreate createInput)
        {
            this.client.Configuration.CheckConfig();
            return await this.CreateAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, createInput);
        }
        public async Task<ZsPlan> CreateAsync(string apiBaseUrl, string authToken, string organizationId, ZsPlanCreate createInput)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

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
                var response = await httpClient.PostAsync(ApiResources.ZsPostPlan, content);
                var processResult = await response.ProcessResponse<ZsPlanJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Plan;
            }
        }

        public async Task<ZsPlan> UpdateAsync(string code, ZsPlanUpdate updateInput)
        {
            this.client.Configuration.CheckConfig();
            return await this.UpdateAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, code, updateInput);
        }
        public async Task<ZsPlan> UpdateAsync(string apiBaseUrl, string authToken, string organizationId, string code, ZsPlanUpdate updateInput)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (updateInput == null)
            {
                throw new ArgumentNullException("updateInput");
            }

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException("Plan code is required");
            }

            var validationResult = updateInput.Validate();
            if (!string.IsNullOrWhiteSpace(validationResult))
            {
                throw new ArgumentException(validationResult);
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var updateJson = JsonConvert.SerializeObject(
                        updateInput,
                        Formatting.None,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                var content = new StringContent(
                    updateJson,
                    Encoding.UTF8,
                    "application/json");
                var response = await httpClient.PutAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPutPlan, code), content);
                var processResult = await response.ProcessResponse<ZsPlanJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Plan;
            }
        }

        public async Task<bool> DeleteAsync(string code)
        {
            this.client.Configuration.CheckConfig();
            return await this.DeleteAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, code);
        }
        public async Task<bool> DeleteAsync(string apiBaseUrl, string authToken, string organizationId, string code)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException("Plan code is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var response = await httpClient.DeleteAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsDeletePlan, code));
                var processResult = await response.ProcessResponse<bool>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<bool> ActivateAsync(string code)
        {
            this.client.Configuration.CheckConfig();
            return await this.ActivateAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, code);
        }
        public async Task<bool> ActivateAsync(string apiBaseUrl, string authToken, string organizationId, string code)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException("Plan code is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var response = await httpClient.PostAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPostPlanMarkActive, code), null);
                var processResult = await response.ProcessResponse<bool>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<bool> DeactivateAsync(string code)
        {
            this.client.Configuration.CheckConfig();
            return await this.DeactivateAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, code);
        }
        public async Task<bool> DeactivateAsync(string apiBaseUrl, string authToken, string organizationId, string code)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException("Plan code is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var response = await httpClient.PostAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPostPlanMarkInActive, code), null);
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