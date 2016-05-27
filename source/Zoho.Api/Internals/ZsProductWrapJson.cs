namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ZsProductWrapJson
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("email_ids")]
        public string Emails { get; set; }
        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }
    }
}