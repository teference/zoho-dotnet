namespace Teference.Zoho.Api.Models
{
    #region Namespace

    using Newtonsoft.Json;
    using System.Collections.Generic;

    #endregion

    public sealed class ZsProducts
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("products")]
        public List<ZsProduct> Products { get; set; }

        [JsonProperty("page_context")]
        public ZsPageContext PageContext { get; set; }
    }
}