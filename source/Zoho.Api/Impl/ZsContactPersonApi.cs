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

    internal sealed class ZsContactPersonApi : IZsContactPersonApi
    {
        #region Variable declaration

        private IZohoClient client;

        #endregion

        #region Constructor

        public ZsContactPersonApi(IZohoClient client)
        {
            this.client = client;
        }

        #endregion

        #region Methods

        public async Task<ZsContactPerson> GetAsync(string customerId, string contactPersonId)
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, customerId, contactPersonId);
        }
        public async Task<ZsContactPerson> GetAsync(string authToken, string organizationId, string customerId, string contactPersonId)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException("Addon code is required");
            }

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException("Addon code is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsGetAddon, code));
                var processResult = await response.ProcessResponse<ZsAddonJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Addon;
            }
        }

        public async Task<ZsContactPersons> GetAllAsync(string customerId)
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAllAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, customerId);
        }
        public async Task<ZsContactPersons> GetAllAsync(string authToken, string organizationId, string customerId)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.GetAsync(ApiResources.ZsGetAddonsAll);
                var processResult = await response.ProcessResponse<ZsAddons>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<ZsContactPerson> CreateAsync(string customerId, ZsAddonCreate createInput)
        {
            this.client.Configuration.CheckConfig();
            return await this.CreateAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, customerId, createInput);
        }
        public async Task<ZsContactPerson> CreateAsync(string authToken, string organizationId, string customerId, ZsAddonCreate createInput)
        {
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
                httpClient.Configure(organizationId, authToken);
                var content = new StringContent(
                    JsonConvert.SerializeObject(
                        createInput,
                        Formatting.None,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    Encoding.UTF8,
                    "application/json");
                var response = await httpClient.PostAsync(ApiResources.ZsPostAddon, content);
                var processResult = await response.ProcessResponse<ZsAddonJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Addon;
            }
        }

        public async Task<ZsContactPerson> UpdateAsync(string customerId, string contactPersonId, ZsAddonUpdate updateInput)
        {
            this.client.Configuration.CheckConfig();
            return await this.UpdateAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, customerId, contactPersonId, updateInput);
        }
        public async Task<ZsContactPerson> UpdateAsync(string authToken, string organizationId, string customerId, string contactPersonId, ZsAddonUpdate updateInput)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (updateInput == null)
            {
                throw new ArgumentNullException("updateInput");
            }

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException("Addon code is required");
            }

            var validationResult = updateInput.Validate();
            if (!string.IsNullOrWhiteSpace(validationResult))
            {
                throw new ArgumentException(validationResult);
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var updateJson = JsonConvert.SerializeObject(
                        updateInput,
                        Formatting.None,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                var content = new StringContent(
                    updateJson,
                    Encoding.UTF8,
                    "application/json");
                var response = await httpClient.PutAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPutAddon, code), content);
                var processResult = await response.ProcessResponse<ZsAddonJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Addon;
            }
        }

        public async Task<bool> DeleteAsync(string customerId, string contactPersonId)
        {
            this.client.Configuration.CheckConfig();
            return await this.DeleteAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, customerId, contactPersonId);
        }
        public async Task<bool> DeleteAsync(string authToken, string organizationId, string customerId, string contactPersonId)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException("Addon code is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.DeleteAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsDeleteAddon, code));
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