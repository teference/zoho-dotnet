namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    public sealed class ZsHostedPageData
    {
        [JsonProperty("subscription")]
        public ZsSubscription Subscription { get; set; }
        [JsonProperty("invoice")]
        public string Invoice { get; set; }
    }
}