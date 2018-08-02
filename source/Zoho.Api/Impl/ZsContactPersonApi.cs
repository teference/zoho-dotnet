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
            return await this.GetAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, customerId, contactPersonId);
        }
        public async Task<ZsContactPerson> GetAsync(string apiBaseUrl, string authToken, string organizationId, string customerId, string contactPersonId)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentNullException("Customer id is required");
            }

            if (string.IsNullOrWhiteSpace(contactPersonId))
            {
                throw new ArgumentNullException("Contact person id is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsGetContactPerson, customerId, contactPersonId));
                var processResult = await response.ProcessResponse< ZsContactPersonJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.ContactPerson;
            }
        }

        public async Task<ZsContactPersons> GetAllAsync(string customerId, ZsPage page = null)
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAllAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, customerId, page);
        }
        public async Task<ZsContactPersons> GetAllAsync(string apiBaseUrl, string authToken, string organizationId, string customerId, ZsPage page = null)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var response = await httpClient.GetAsync(page.AppendTo(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsGetContactPersonsAll, customerId)));
                var processResult = await response.ProcessResponse<ZsContactPersons>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<ZsContactPerson> CreateAsync(string customerId, ZsContactPersonInput createInput)
        {
            this.client.Configuration.CheckConfig();
            return await this.CreateAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, customerId, createInput);
        }
        public async Task<ZsContactPerson> CreateAsync(string apiBaseUrl, string authToken, string organizationId, string customerId, ZsContactPersonInput createInput)
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
                var response = await httpClient.PostAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPostContactPerson, customerId), content);
                var processResult = await response.ProcessResponse<ZsContactPersonJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.ContactPerson;
            }
        }

        public async Task<ZsContactPerson> UpdateAsync(string customerId, string contactPersonId, ZsContactPersonInput updateInput)
        {
            this.client.Configuration.CheckConfig();
            return await this.UpdateAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, customerId, contactPersonId, updateInput);
        }
        public async Task<ZsContactPerson> UpdateAsync(string apiBaseUrl, string authToken, string organizationId, string customerId, string contactPersonId, ZsContactPersonInput updateInput)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (updateInput == null)
            {
                throw new ArgumentNullException("updateInput");
            }

            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentNullException("Customer id is required");
            }

            if (string.IsNullOrWhiteSpace(contactPersonId))
            {
                throw new ArgumentNullException("Contact person id is required");
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
                var response = await httpClient.PutAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPutContactPerson, customerId, contactPersonId), content);
                var processResult = await response.ProcessResponse<ZsContactPersonJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.ContactPerson;
            }
        }

        public async Task<bool> DeleteAsync(string customerId, string contactPersonId)
        {
            this.client.Configuration.CheckConfig();
            return await this.DeleteAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, customerId, contactPersonId);
        }
        public async Task<bool> DeleteAsync(string apiBaseUrl, string authToken, string organizationId, string customerId, string contactPersonId)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentNullException("Customer id is required");
            }

            if (string.IsNullOrWhiteSpace(contactPersonId))
            {
                throw new ArgumentNullException("Contact person id is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var response = await httpClient.DeleteAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsDeleteContactPerson, customerId, contactPersonId));
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