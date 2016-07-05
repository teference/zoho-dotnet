namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    public sealed class ZsHostedPageDetail : ZsHostedPage
    {
        [JsonProperty("data")]
        public ZsHostedPageData Data { get; set; }
    }
}