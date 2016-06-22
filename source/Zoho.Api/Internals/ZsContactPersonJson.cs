namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ZsContactPersonJson : ZsErrorJson
    {
        [JsonProperty("contactperson")]
        public ZsContactPerson ContactPerson { get; set; }
    }
}