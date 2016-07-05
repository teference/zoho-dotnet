namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ZsHostedPageJson : ZsErrorJson
    {
        [JsonProperty("hostedpage")]
        public ZsHostedPage HostedPage { get; set; }
    }
}