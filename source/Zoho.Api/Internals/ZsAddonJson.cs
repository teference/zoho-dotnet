namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ZsAddonJson : ZsErrorJson
    {
        [JsonProperty("addon")]
        public ZsAddon Addon { get; set; }
    }
}