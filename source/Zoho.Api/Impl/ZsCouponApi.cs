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
    internal sealed class ZsCouponApi : IZsCouponApi
    {
        #region Variable declaration

        private IZohoClient client;

        #endregion

        #region Constructor

        public ZsCouponApi(IZohoClient client)
        {
            this.client = client;
        }

        #endregion

        #region Methods

        public async Task<ZsCoupon> GetAsync(string code)
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, code);
        }
        public async Task<ZsCoupon> GetAsync(string apiBaseUrl, string authToken, string organizationId, string code)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException("Coupon code is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var response = await httpClient.GetAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsGetCoupon, code));
                var processResult = await response.ProcessResponse<ZsCouponJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Coupon;
            }
        }

        public async Task<ZsCoupons> GetAllAsync()
        {
            this.client.Configuration.CheckConfig();
            return await this.GetAllAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId);
        }
        public async Task<ZsCoupons> GetAllAsync(string apiBaseUrl, string authToken, string organizationId)
        {
            apiBaseUrl.CheckConfigApiBaseUrl();
            authToken.CheckConfigAuthToken();
            organizationId.CheckConfigOrganizationId();

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var response = await httpClient.GetAsync(ApiResources.ZsGetCouponsAll);
                var processResult = await response.ProcessResponse<ZsCoupons>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data;
            }
        }

        public async Task<ZsCoupon> CreateAsync(ZsCouponCreate createInput)
        {
            this.client.Configuration.CheckConfig();
            return await this.CreateAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, createInput);
        }
        public async Task<ZsCoupon> CreateAsync(string apiBaseUrl, string authToken, string organizationId, ZsCouponCreate createInput)
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
                var response = await httpClient.PostAsync(ApiResources.ZsPostCoupon, content);
                var processResult = await response.ProcessResponse<ZsCouponJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Coupon;
            }
        }

        public async Task<ZsCoupon> UpdateAsync(string code, ZsCouponUpdate updateInput)
        {
            this.client.Configuration.CheckConfig();
            return await this.UpdateAsync(this.client.Configuration.ApiBaseUrl, this.client.Configuration.AuthToken, this.client.Configuration.OrganizationId, code, updateInput);
        }
        public async Task<ZsCoupon> UpdateAsync(string apiBaseUrl, string authToken, string organizationId, string code, ZsCouponUpdate updateInput)
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
                throw new ArgumentNullException("Coupon code is required");
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
                var response = await httpClient.PutAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPutCoupon, code), content);
                var processResult = await response.ProcessResponse<ZsCouponJson>();
                if (null != processResult.Error)
                {
                    throw processResult.Error;
                }

                return processResult.Data.Coupon;
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
                throw new ArgumentNullException("Coupon code is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var response = await httpClient.DeleteAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsDeleteCoupon, code));
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
                throw new ArgumentNullException("Coupon code is required");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.Configure(apiBaseUrl, organizationId, authToken);
                var response = await httpClient.PostAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPostCouponMarkActive, code), null);
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
                var response = await httpClient.PostAsync(string.Format(CultureInfo.InvariantCulture, ApiResources.ZsPostCouponMarkInActive, code), null);
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