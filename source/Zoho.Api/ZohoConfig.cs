namespace Teference.Zoho.Api
{
    public sealed class ZohoConfig
    {
        /// <summary>
        /// Set Zoho API base URL (ending with '/') - if not set default "https://subscriptions.zoho.com/api/v1/" will be used.
        /// </summary>
        public string ApiBaseUrl { get; set; } = "https://subscriptions.zoho.com/api/v1/";
        public string OrganizationId { get; set; }
        public string AuthToken { get; set; }
    }
}