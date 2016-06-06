namespace Teference.Zoho.Api
{
    using Newtonsoft.Json;

    public sealed class ZsPriceBracket
    {
        [JsonProperty("start_quantity")]
        public double? StartQuantity { get; set; }

        [JsonProperty("end_quantity")]
        public double? EndQuantity { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }
    }
}