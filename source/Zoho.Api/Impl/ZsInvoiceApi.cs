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

    internal sealed class ZsInvoiceApi : IZsInvoiceApi
    {
        #region Variable declaration

        private IZohoClient client;

        #endregion

        #region Constructor

        public ZsInvoiceApi(IZohoClient client)
        {
            this.client = client;
        }

        #endregion

        #region Methods

        public async Task<ZsInvoice> GetAsync(string id)
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id);
        }
        public async Task<ZsInvoice> GetAsync(string authToken, string organizationId, string id)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("Invoice id is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsGetInvoice, id));
                var processResult = await response.ProcessResponse<ZsInvoiceJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Invoice;
            }
        }

        public async Task<ZsInvoices> GetAllAsync()
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAllAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId);
        }
        public async Task<ZsInvoices> GetAllAsync(string authToken, string organizationId)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.GetAsync(ApiResources.ZsGetInvoicesAll);
                var processResult = await response.ProcessResponse<ZsInvoices>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<ZsInvoices> GetAllAsync(ZsInvoiceFilter filterType, string filterId)
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAllAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, filterType, filterId);
        }
        public async Task<ZsInvoices> GetAllAsync(string authToken, string organizationId, ZsInvoiceFilter filterType, string filterId)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(filterId))
            {
                throw new ArgumentNullException("Filter id - Subscription id or Customer id is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var requestUri = ApiResources.ZsGetInvoicesAll;
                switch(filterType)
                {
                    case ZsInvoiceFilter.CustomerId:
                        requestUri = string.Format(CultureInfo.InvariantCulture, ApiResources.ZsGetInvoicesAllByCustomerId, filterId);
                        break;
                    case ZsInvoiceFilter.SubscriptionId:
                        requestUri = string.Format(CultureInfo.InvariantCulture, ApiResources.ZsGetInvoicesAllBySubscriptionId, filterId);
                        break;
                }

                var response = await httpClient.GetAsync(requestUri);
                var processResult = await response.ProcessResponse<ZsInvoices>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<ZsInvoice> CollectCharge(string id, string cardId)
        {
            this.client.Configuration.CheckConfig();
            return await this.CollectCharge(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id, cardId);
        }
        public async Task<ZsInvoice> CollectCharge(string authToken, string organizationId, string id, string cardId)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("Invoice id is required");
            }

            if (string.IsNullOrWhiteSpace(cardId))
            {
                throw new ArgumentNullException("Card id is required");
            }

            var invoiceCollectChargeJson = new ZsInvoiceCollectChargeJson { CardId = cardId };
            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var jsonContent = JsonConvert.SerializeObject(
                        invoiceCollectChargeJson,
                        Formatting.None,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPostInvoiceCollectCharges, id), content);
                var processResult = await response.ProcessResponse<ZsInvoiceJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Invoice;
            }
        }

        public async Task<bool> ConvertToVoid(string id)
        {
            this.client.Configuration.CheckConfig();
            return await this.ConvertToVoid(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id);
        }
        public async Task<bool> ConvertToVoid(string authToken, string organizationId, string id)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("Invoice id is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.PostAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPostInvoiceConvertToVoid, id), null);
                var processResult = await response.ProcessResponse<bool>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<bool> ConvertToOpen(string id)
        {
            this.client.Configuration.CheckConfig();
            return await this.ConvertToOpen(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id);
        }
        public async Task<bool> ConvertToOpen(string authToken, string organizationId, string id)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("Invoice id is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.PostAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPostInvoiceConvertToOpen, id), null);
                var processResult = await response.ProcessResponse<bool>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<bool> EmailInvoice(string id, ZsInvoiceEmailInput emailInput)
        {
            this.client.Configuration.CheckConfig();
            return await this.EmailInvoice(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id, emailInput);
        }
        public async Task<bool> EmailInvoice(string authToken, string organizationId, string id, ZsInvoiceEmailInput emailInput)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("Invoice id is required");
            }

            if (emailInput == null)
            {
                throw new ArgumentNullException("emailInput");
            }

            var validationResult = emailInput.Validate();
            if (!string.IsNullOrWhiteSpace(validationResult))
            {
                throw new ArgumentException(validationResult);
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var content = new StringContent(
                    JsonConvert.SerializeObject(
                        emailInput,
                        Formatting.None,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    Encoding.UTF8,
                    "application/json");
                var response = await httpClient.PostAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPostInvoiceEmail, id), content);
                var processResult = await response.ProcessResponse<bool>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<bool> WriteOff(string id)
        {
            this.client.Configuration.CheckConfig();
            return await this.WriteOff(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id);
        }
        public async Task<bool> WriteOff(string authToken, string organizationId, string id)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("Invoice id is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.PostAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPostInvoiceWriteOff, id), null);
                var processResult = await response.ProcessResponse<bool>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<bool> CancelWriteOff(string id)
        {
            this.client.Configuration.CheckConfig();
            return await this.CancelWriteOff(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id);
        }
        public async Task<bool> CancelWriteOff(string authToken, string organizationId, string id)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("Invoice id is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken);
                var response = await httpClient.PostAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPostInvoiceCancelWriteOff, id), null);
                var processResult = await response.ProcessResponse<bool>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<Stream> GetPdfAsync(string id)
        {
            this.client.Configuration.CheckConfig();
            return await this.GetPdfAsync(this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, id);
        }
        public async Task<Stream> GetPdfAsync(string authToken, string organizationId, string id)
        {
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(organizationId, authToken, isPdf: true);
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsGetInvoiceAsPdf, id));
                if (null == response)
                {
                    throw new ArgumentNullException("response");
                }

                if (!response.IsSuccessStatusCode)
                {
                    ZsErrorJson errorResponse = null;
                    try
                    {
                        var rawErrorResponse = await response.Content.ReadAsStringAsync();
                        errorResponse = JsonConvert.DeserializeObject<ZsErrorJson>(rawErrorResponse);
                    }
                    catch (Exception exception)
                    {
                        throw new InvalidOperationException("API call did not completed successfully or response parse error occurred", exception);
                    }

                    if (null == errorResponse || string.IsNullOrWhiteSpace(errorResponse.Message))
                    {
                        throw new InvalidOperationException("API call did not completed successfully or response parse error occurred");
                    }

                    throw new InvalidOperationException(errorResponse.Message);
                }
                else
                {
                    try
                    {
                        return await response.Content.ReadAsStreamAsync();
                    }
                    catch (Exception exception)
                    {
                        throw new InvalidOperationException("API call did not completed successfully or response parse error occurred", exception);
                    }
                }
            }
        }

        #endregion
    }
}