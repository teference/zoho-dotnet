namespace Teference.Zoho.Api
{
    #region Namespace

    using Internals;
    using System;
    using System.Globalization;
    using System.Net.Http;
    using System.Net.Http.Headers;

    #endregion

    internal static class InternalExtensions
    {
        internal static void Configure(this HttpClient httpClient, string organizationId, string authToken)
        {
            if (httpClient.DefaultRequestHeaders.CacheControl == null)
            {
                httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
            }

            httpClient.DefaultRequestHeaders.CacheControl.NoCache = true;
            httpClient.DefaultRequestHeaders.IfModifiedSince = DateTime.UtcNow;
            httpClient.DefaultRequestHeaders.CacheControl.NoStore = true;

            httpClient.Timeout = new TimeSpan(0, 0, 30);

            httpClient.DefaultRequestHeaders.Accept.Clear();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.BaseAddress = new Uri(ApiResources.ZsRootEndpoint);

            httpClient.DefaultRequestHeaders.Add("authorization", string.Format(CultureInfo.InvariantCulture, "Zoho-authtoken {0}", authToken));
            httpClient.DefaultRequestHeaders.Add("x-com-zoho-subscriptions-organizationid", organizationId);
        }

        internal static void CheckConfig(this ZohoConfig configuration)
        {
            if (null == configuration)
            {
                throw new ArgumentException("Zoho API configurations missing or not set before making API call");
            }

            if (string.IsNullOrEmpty(configuration.OrganizationId) || configuration.OrganizationId.Trim() == string.Empty)
            {
                throw new ArgumentNullException("Zoho API configuration - Organization Id cannot be null");
            }

            if (string.IsNullOrEmpty(configuration.AuthToken) || configuration.AuthToken.Trim() == string.Empty)
            {
                throw new ArgumentNullException("Zoho API configuration - Authorization token cannot be null");
            }
        }

        internal static void CheckConfigAuthToken(this string authToken)
        {
            if (string.IsNullOrEmpty(authToken) || authToken.Trim() == string.Empty)
            {
                throw new ArgumentNullException("Zoho API configuration - Authorization token cannot be null");
            }
        }

        internal static void CheckConfigOrganizationId(this string organizationId)
        {
            if (string.IsNullOrEmpty(organizationId) || organizationId.Trim() == string.Empty)
            {
                throw new ArgumentNullException("Zoho API configuration - Organization Id cannot be null");
            }
        }
    }
}