namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ZsSubscriptionJson : ZsErrorJson
    {
        [JsonProperty("subscription")]
        public ZsSubscription Subscription { get; set; }
    }
}