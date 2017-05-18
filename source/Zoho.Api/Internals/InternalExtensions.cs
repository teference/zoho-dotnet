namespace Teference.Zoho.Api
{
    #region Namespace

    using Internals;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    #endregion

    internal static class InternalExtensions
    {
        internal static void Configure(this HttpClient httpClient, string apiBaseUrl, string organizationId, string authToken, bool isPdf = false)
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

            if (!isPdf)
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            else
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/pdf"));
            }

            // Sanity patch for base URL to end with /
            if (!apiBaseUrl.EndsWith("/"))
                apiBaseUrl = apiBaseUrl + "/";

            httpClient.BaseAddress = new Uri(apiBaseUrl);

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

            if (string.IsNullOrEmpty(configuration.ApiBaseUrl) || configuration.ApiBaseUrl.Trim() == string.Empty || !Uri.IsWellFormedUriString(configuration.ApiBaseUrl, UriKind.RelativeOrAbsolute))
            {
                throw new ArgumentNullException("Zoho API configuration - API base URL is not well formed URI");
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

        internal static void CheckConfigApiBaseUrl(this string apiBaseUrl)
        {
            if (string.IsNullOrEmpty(apiBaseUrl) || apiBaseUrl.Trim() == string.Empty || !Uri.IsWellFormedUriString(apiBaseUrl, UriKind.RelativeOrAbsolute))
            {
                throw new ArgumentNullException("Zoho API configuration - API base URL is not well formed URI");
            }
        }

        internal static async Task<ProcessEntity<T>> ProcessResponse<T>(this HttpResponseMessage response)
        {
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
                    return new ProcessEntity<T> { Error = new InvalidOperationException("API call did not completed successfully or response parse error occurred", exception) };
                }

                if (null == errorResponse || string.IsNullOrWhiteSpace(errorResponse.Message))
                {
                    return new ProcessEntity<T> { Error = new InvalidOperationException("API call did not completed successfully or response parse error occurred") };
                }

                return new ProcessEntity<T> { Error = new InvalidOperationException(errorResponse.Message) };
            }
            else
            {
                if (typeof(T) == (typeof(bool)))
                {
                    return new ProcessEntity<T> { Data = (T)(object)response.IsSuccessStatusCode };
                }

                try
                {
                    var rawResponseContent = await response.Content.ReadAsStringAsync();
                    return new ProcessEntity<T> { Data = JsonConvert.DeserializeObject<T>(rawResponseContent) };
                }
                catch (Exception exception)
                {
                    return new ProcessEntity<T> { Error = new InvalidOperationException("API call did not completed successfully or response parse error occurred", exception) };
                }
            }
        }
    }
}