namespace Teference.Zoho.Api
{
    using Newtonsoft.Json;

    public sealed class ZsCustomerField
    {
        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}