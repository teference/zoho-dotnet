namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System;

    #endregion

    public class ZsHostedPage
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("hostedpage_id")]
        public string Id { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("url")]
        public string HostedPageUrl { get; set; }
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("expiring_time")]
        public DateTime ExpiresAt { get; set; }
        [JsonProperty("created_time")]
        public DateTime CreatedAt { get; set; }
    }
}