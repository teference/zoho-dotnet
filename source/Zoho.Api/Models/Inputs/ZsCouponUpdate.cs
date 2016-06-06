namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System;

    #endregion

    public class ZsCouponUpdate
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("max_redemption")]
        public int MaxRedemption { get; set; }

        [JsonProperty("expiry_at")]
        public DateTime ExpiryAt { get; set; }

        internal string Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                return "Coupon name is required.";
            }

            return string.Empty;
        }
    }
}