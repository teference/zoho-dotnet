namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ZsCustomerJson : ZsErrorJson
    {
        [JsonProperty("customer")]
        public ZsCustomer Customer { get; set; }
    }
}