namespace Teference.Zoho.Api
{
    #region Namespace

    using Internals;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    #endregion

    internal sealed class ZsProductApi : IZsProductApi
    {
        #region Variable declaration

        private IZohoClient client;

        #endregion

        #region Constructor

        public ZsProductApi(IZohoClient client)
        {
            this.client = client;
        }

        #endregion

        #region Methods

        public async Task<ZsProduct> GetAsync(string id)
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id);
        }

        public async Task<ZsProduct> GetAsync(string authToken, string organizationId, string id)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrEmpty(id) || id == string.Empty)
            {
                throw new ArgumentNullException("id");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsGetProduct, id));
                if (!response.IsSuccessStatusCode)
                {
                    var rawErrorResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var productSingleGetError = JsonConvert.DeserializeObject<ZsProductJson>(rawErrorResponse);
                        throw new InvalidOperationException(productSingleGetError.Message);
                    }
                    catch (Exception exception)
                    {
                        throw new InvalidOperationException("API call did not completed successfully or response parse error occurred", exception);
                    }
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var productResponse = JsonConvert.DeserializeObject<ZsProductJson>(rawResponseContent);
                return productResponse.Product;
            }
        }

        public async Task<ZsProducts> GetAllAsync()
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAllAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId);
        }

        public async Task<ZsProducts> GetAllAsync(string authToken, string organizationId)
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
                return JsonConvert.DeserializeObject<ZsProducts>(rawResponseContent);
            }
        }

        public async Task<ZsProduct> CreateAsync(string name, string description = "", IEnumerable<string> notificationEmails = null, string redirectUrl = null)
        {
            this.client.Configuration.CheckConfig();
            return await this.CreateAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, name, description, notificationEmails, redirectUrl);
        }

        public async Task<ZsProduct> CreateAsync(string authToken, string organizationId, string name, string description = "", IEnumerable<string> notificationEmails = null, string redirectUrl = null)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrEmpty(name) || name == string.Empty)
            {
                throw new ArgumentNullException("name");
            }

            var zsProductCreate = new ZsProductWrapJson();
            zsProductCreate.Name = name;
            if (!string.IsNullOrWhiteSpace(description))
            {
                zsProductCreate.Description = description;
            }

            if (null != notificationEmails && notificationEmails.Count() > 0)
            {
                var notificationEmailList = notificationEmails.ToList();
                var notificationEmailCommaSeperated = new StringBuilder();
                for (var counter = 0; counter < notificationEmailList.Count; counter++)
                {
                    if (counter == notificationEmailList.Count - 1)
                    {
                        notificationEmailCommaSeperated.Append(notificationEmailList[counter]);
                    }
                    else
                    {
                        notificationEmailCommaSeperated.Append(string.Format(CultureInfo.InvariantCulture, "{0},", notificationEmailList[counter]));
                    }
                }

                zsProductCreate.Emails = notificationEmailCommaSeperated.ToString();
            }

            if (!string.IsNullOrWhiteSpace(redirectUrl))
            {
                zsProductCreate.RedirectUrl = redirectUrl;
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var content = new StringContent(JsonConvert.SerializeObject(zsProductCreate), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(ApiResources.ZsPostProduct, content);
                if (!response.IsSuccessStatusCode)
                {
                    var rawErrorResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var productCreateError = JsonConvert.DeserializeObject<ZsProductJson>(rawErrorResponse);
                        throw new InvalidOperationException(productCreateError.Message);
                    }
                    catch (Exception exception)
                    {
                        throw new InvalidOperationException("API call did not completed successfully or response parse error occurred", exception);
                    }
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var productCreated = JsonConvert.DeserializeObject<ZsProductJson>(rawResponseContent);
                return productCreated.Product;
            }
        }

        public async Task<ZsProduct> UpdateAsync(string id, string name, string description = "", IEnumerable<string> notificationEmails = null, string redirectUrl = null)
        {
            this.client.Configuration.CheckConfig();
            return await this.UpdateAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id, name, description, notificationEmails, redirectUrl);
        }

        public async Task<ZsProduct> UpdateAsync(string authToken, string organizationId, string id, string name, string description = "", IEnumerable<string> notificationEmails = null, string redirectUrl = null)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrEmpty(id) || name == string.Empty)
            {
                throw new ArgumentNullException("id");
            }

            if (string.IsNullOrEmpty(name) || name == string.Empty)
            {
                throw new ArgumentNullException("name");
            }

            var zsProductUpdate = new ZsProductWrapJson();
            zsProductUpdate.Name = name;
            if (!string.IsNullOrWhiteSpace(description))
            {
                zsProductUpdate.Description = description;
            }

            if (null != notificationEmails && notificationEmails.Count() > 0)
            {
                var notificationEmailList = notificationEmails.ToList();
                var notificationEmailCommaSeperated = new StringBuilder();
                for (var counter = 0; counter < notificationEmailList.Count; counter++)
                {
                    if (counter == notificationEmailList.Count - 1)
                    {
                        notificationEmailCommaSeperated.Append(notificationEmailList[counter]);
                    }
                    else
                    {
                        notificationEmailCommaSeperated.Append(string.Format(CultureInfo.InvariantCulture, "{0},", notificationEmailList[counter]));
                    }
                }

                zsProductUpdate.Emails = notificationEmailCommaSeperated.ToString();
            }

            if (!string.IsNullOrWhiteSpace(redirectUrl))
            {
                zsProductUpdate.RedirectUrl = redirectUrl;
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var content = new StringContent(JsonConvert.SerializeObject(zsProductUpdate), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPutProduct, id), content);
                if (!response.IsSuccessStatusCode)
                {
                    var rawErrorResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var productUpdateError = JsonConvert.DeserializeObject<ZsProductJson>(rawErrorResponse);
                        throw new InvalidOperationException(productUpdateError.Message);
                    }
                    catch (Exception exception)
                    {
                        throw new InvalidOperationException("API call did not completed successfully or response parse error occurred", exception);
                    }
                }

                var rawResponseContent = await response.Content.ReadAsStringAsync();
                var productUpdated = JsonConvert.DeserializeObject<ZsProductJson>(rawResponseContent);
                return productUpdated.Product;
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

            if (string.IsNullOrEmpty(id) || id == string.Empty)
            {
                throw new ArgumentNullException("id");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.DeleteAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsDeleteProduct, id));
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> ActivateAsync(string id)
        {
            this.client.Configuration.CheckConfig();
            return await this.ActivateAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id);
        }

        public async Task<bool> ActivateAsync(string authToken, string organizationId, string id)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrEmpty(id) || id == string.Empty)
            {
                throw new ArgumentNullException("id");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.PostAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPostProductMarkActive, id), null);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeactivateAsync(string id)
        {
            this.client.Configuration.CheckConfig();
            return await this.DeactivateAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id);
        }

        public async Task<bool> DeactivateAsync(string authToken, string organizationId, string id)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrEmpty(id) || id == string.Empty)
            {
                throw new ArgumentNullException("id");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.PostAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPostProductMarkInActive, id), null);
                return response.IsSuccessStatusCode;
            }
        }

        #endregion
    }
}