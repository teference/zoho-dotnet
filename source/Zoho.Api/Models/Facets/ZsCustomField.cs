namespace Teference.Zoho.Api
{
    using Newtonsoft.Json;

    public class ZsCustomField
    {
        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public sealed class ZsCustomFieldEx : ZsCustomField
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}