namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal class ZsSubscriptionBuyOnetimeAddonJson
    {
        [JsonProperty("addon_code")]
        internal string AddonCode { get; set; }
        [JsonProperty("quantity")]
        internal int Quantity { get; set; }
        [JsonProperty("price")]
        internal double Price { get; set; }
        [JsonProperty("tax_id")]
        internal string TaxId { get; set; }
    }
}