namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal class ZsInvoiceCollectChargeJson
    {
        [JsonProperty("card_id")]
        internal string CardId { get; set; }
    }
}