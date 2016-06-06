namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal sealed class ZsCouponJson : ZsErrorJson
    {
        [JsonProperty("coupon")]
        public ZsCoupon Coupon { get; set; }
    }
}