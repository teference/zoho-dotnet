namespace Teference.Zoho.Api
{
    using Newtonsoft.Json;

    public sealed class ZsSubscriptionAddonOption
    {
        [JsonProperty("addon_code")]
        public string AddonCode { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("tax_id")]
        public string TaxId { get; set; }
    }
}