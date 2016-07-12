namespace Teference.Zoho.Api
{
    #region Namespace

    using Internals;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    #endregion

    internal sealed class ZsSubscriptionApi : IZsSubscriptionApi
    {
        #region Variable declaration

        private IZohoClient client;

        #endregion

        #region Constructor

        public ZsSubscriptionApi(IZohoClient client)
        {
            this.client = client;
        }

        #endregion

        #region Methods

        public async Task<ZsSubscription> GetAsync(string id)
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id);
        }

        public async Task<ZsSubscription> GetAsync(string authToken, string organizationId, string id)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsGetSubscription, id));
                var processResult = await response.ProcessResponse<ZsSubscriptionJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Subscription;
            }
        }

        public async Task<ZsSubscriptions> GetAllAsync()
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAllAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId);
        }

        public async Task<ZsSubscriptions> GetAllAsync(string authToken, string organizationId)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.GetAsync(ApiResources.ZsGetSubscriptionsAll);
                var processResult = await response.ProcessResponse<ZsSubscriptions>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<ZsSubscription> CreateAsync(ZsSubscriptionCreate createInput)
        {
            this.client.Configuration.CheckConfig();
            return await this.CreateAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, createInput);
        }

        public async Task<ZsSubscription> CreateAsync(string authToken, string organizationId, ZsSubscriptionCreate createInput)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (createInput == null)
            {
                throw new ArgumentNullException("createInput");
            }

            //var validationResult = createInput.Validate();
            //if (!string.IsNullOrWhiteSpace(validationResult))
            //{
            //    throw new ArgumentException(validationResult);
            //}

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
                var response = await httpClient.PostAsync(ApiResources.ZsPostSubscription, content);
                var processResult = await response.ProcessResponse<ZsSubscriptionJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Subscription;
            }
        }

        public async Task<ZsSubscription> UpdateAsync(string id, ZsSubscriptionUpdate updateInput)
        {
            this.client.Configuration.CheckConfig();
            return await this.UpdateAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id, updateInput);
        }

        public async Task<ZsSubscription> UpdateAsync(string authToken, string organizationId, string id, ZsSubscriptionUpdate updateInput)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (updateInput == null)
            {
                throw new ArgumentNullException("updateInput");
            }

            if (string.IsNullOrEmpty(id) || id == string.Empty)
            {
                throw new ArgumentNullException("id");
            }

            //var validationResult = updateInput.Validate();
            //if (!string.IsNullOrWhiteSpace(validationResult))
            //{
            //    throw new ArgumentException(validationResult);
            //}

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var jsonContent = JsonConvert.SerializeObject(
                        updateInput,
                        Formatting.None,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPutSubscription, id), content);
                var processResult = await response.ProcessResponse<ZsSubscriptionJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Subscription;
            }
        }

        public async Task<ZsSubscription> AddContactPerson(string id, List<string> contactPersons)
        {
            this.client.Configuration.CheckConfig();
            return await this.AddContactPerson(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id, contactPersons);
        }

        public async Task<ZsSubscription> AddContactPerson(string authToken, string organizationId, string id, List<string> contactPersons)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrEmpty(id) || id == string.Empty)
            {
                throw new ArgumentNullException("id");
            }

            if (null == contactPersons || contactPersons.Count == 0)
            {
                throw new ArgumentNullException("contactPersons");
            }

            var contactPersonsList = new ZsSubscriptionAddContactsJson();
            contactPersonsList.ContactPersons = new List<ZsSubscriptionAddContactJson>();
            foreach (var item in contactPersons)
            {
                contactPersonsList.ContactPersons.Add(new ZsSubscriptionAddContactJson { ContactPersonId = item });
            }

            //var validationResult = updateInput.Validate();
            //if (!string.IsNullOrWhiteSpace(validationResult))
            //{
            //    throw new ArgumentException(validationResult);
            //}

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var jsonContent = JsonConvert.SerializeObject(
                        contactPersonsList,
                        Formatting.None,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPostSubscriptionAddContactPerson, id), content);
                var processResult = await response.ProcessResponse<ZsSubscriptionJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Subscription;
            }
        }

        #endregion
    }
}