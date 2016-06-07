namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ZsCardJson : ZsErrorJson
    {
        [JsonProperty("card")]
        public ZsCard Card { get; set; }
    }
}