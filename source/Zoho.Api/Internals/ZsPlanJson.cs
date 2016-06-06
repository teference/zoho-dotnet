namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ZsPlanJson : ZsErrorJson
    {
        [JsonProperty("plan")]
        public ZsPlan Plan { get; set; }
    }
}