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

    // TODO: Testing pending.
    internal sealed class ZsCustomerApi : IZsCustomerApi
    {
        #region Variable declaration

        private IZohoClient client;

        #endregion

        #region Constructor

        public ZsCustomerApi(IZohoClient client)
        {
            this.client = client;
        }

        #endregion

        #region Methods

        public async Task<ZsCustomer> GetAsync(string id)
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id);
        }
        public async Task<ZsCustomer> GetAsync(string authToken, string organizationId, string id)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("Customer id is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsGetCustomer, id));
                var processResult = await response.ProcessResponse<ZsCustomerJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Customer;
            }
        }

        public async Task<ZsCustomers> GetAllAsync()
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAllAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId);
        }
        public async Task<ZsCustomers> GetAllAsync(string authToken, string organizationId)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.GetAsync(ApiResources.ZsGetCustomersAll);
                var processResult = await response.ProcessResponse<ZsCustomers>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<ZsCustomer> CreateAsync(ZsCustomerInput createInput)
        {
            this.client.Configuration.CheckConfig();
            return await this.CreateAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, createInput);
        }
        public async Task<ZsCustomer> CreateAsync(string authToken, string organizationId, ZsCustomerInput createInput)
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
                var response = await httpClient.PostAsync(ApiResources.ZsPostCustomer, content);
                var processResult = await response.ProcessResponse<ZsCustomerJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Customer;
            }
        }

        public async Task<ZsCustomer> UpdateAsync(string id, ZsCustomerInput updateInput)
        {
            this.client.Configuration.CheckConfig();
            return await this.UpdateAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id, updateInput);
        }
        public async Task<ZsCustomer> UpdateAsync(string authToken, string organizationId, string id, ZsCustomerInput updateInput)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (updateInput == null)
            {
                throw new ArgumentNullException("updateInput");
            }

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("Customer id is required");
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
                var response = await httpClient.PutAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPutCustomer, id), content);
                var processResult = await response.ProcessResponse<ZsCustomerJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Customer;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            this.client.Configuration.CheckConfig();
            return await this.DeleteAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id);
        }
        public async Task<bool> DeleteAsync(string authToken, string organizationId, string id)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("Customer id is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.DeleteAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsDeleteCustomer, id));
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