namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ZsInvoiceJson : ZsErrorJson
    {
        [JsonProperty("invoice")]
        public ZsInvoice Invoice { get; set; }
    }
}