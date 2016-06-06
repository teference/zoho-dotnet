namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System.Collections.Generic;

    #endregion

    public sealed class ZsCoupons
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("coupons")]
        public List<ZsCoupon> Coupons { get; set; }

        [JsonProperty("page_context")]
        public ZsPageContext PageContext { get; set; }
    }
}
