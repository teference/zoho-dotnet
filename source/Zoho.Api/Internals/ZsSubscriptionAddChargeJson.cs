namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal class ZsSubscriptionAddChargeJson
    {
        [JsonProperty("amount")]
        internal double Amount { get; set; }
        [JsonProperty("description")]
        internal string Description { get; set; }
    }
}