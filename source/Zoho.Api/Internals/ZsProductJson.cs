namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ZsProductJson : ZsErrorJson
    {
        [JsonProperty("product")]
        public ZsProduct Product { get; set; }
    }
}