namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal class ZsSubscriptionAutoCollectJson
    {
        [JsonProperty("auto_collect")]
        internal bool IsAutoCollect { get; set; }
    }
}