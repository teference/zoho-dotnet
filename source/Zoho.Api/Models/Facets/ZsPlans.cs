namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System.Collections.Generic;

    #endregion

    public sealed class ZsPlans
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("plans")]
        public List<ZsPlan> Plans { get; set; }

        [JsonProperty("page_context")]
        public ZsPageContext PageContext { get; set; }
    }
}