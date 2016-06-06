namespace Teference.Zoho.Api
{
    using Newtonsoft.Json;

    internal class ZsErrorJson
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}