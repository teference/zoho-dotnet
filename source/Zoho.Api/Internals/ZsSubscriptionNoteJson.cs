namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ZsSubscriptionNoteJson : ZsErrorJson
    {
        [JsonProperty("note")]
        public ZsSubscriptionNote Note { get; set; }
    }
}