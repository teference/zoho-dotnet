namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal class ZsSubscriptionAddNoteJson
    {
        [JsonProperty("description")]
        internal string Description { get; set; }
    }
}