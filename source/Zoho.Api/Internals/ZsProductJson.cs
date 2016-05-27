namespace Teference.Zoho.Api
{
    #region Namespace

    using Models;
    using Newtonsoft.Json;

    #endregion

    internal sealed class ZsProductJson
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("product")]
        public ZsProduct Product { get; set; }
    }
}