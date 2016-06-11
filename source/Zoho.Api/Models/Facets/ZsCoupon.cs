namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    #endregion

    public sealed class ZsCoupon
    {
        public ZsCoupon()
        {
            this.Plans = new List<string>();
            this.Addons = new List<string>();
        }

        [JsonProperty("coupon_code")]
        public string Code { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        internal string TypeRaw { get; set; }

        [JsonIgnore]
        public ZsCouponType Type
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.TypeRaw))
                {
                    return ZsCouponType.None;
                }

                switch (this.TypeRaw)
                {
                    case "one_time":
                        return ZsCouponType.OneTime;
                    case "forever":
                        return ZsCouponType.Forever;
                    default:
                        return ZsCouponType.None;
                }
            }
        }

        [JsonProperty("discount_by")]
        internal string DiscountByRaw { get; set; }
        [JsonIgnore]
        public ZsCouponDiscountBy DiscountBy
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.DiscountByRaw))
                {
                    return ZsCouponDiscountBy.None;
                }

                switch (this.DiscountByRaw)
                {
                    case "flat":
                        return ZsCouponDiscountBy.Flat;
                    case "percentage":
                        return ZsCouponDiscountBy.Percentage;
                    default:
                        return ZsCouponDiscountBy.None;
                }
            }
        }
        [JsonProperty("discount_value")]
        public double DiscountValue { get; set; }

        [JsonProperty("max_redemption")]
        public int MaxRedemption { get; set; }
        [JsonProperty("redemption_count")]
        public string RedemptionCount { get; set; }

        [JsonProperty("apply_to_plans")]
        internal string ApplyToPlansRaw { get; set; }
        [JsonIgnore]
        public ZsCouponApplyTo ApplyToPlans
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.ApplyToPlansRaw))
                {
                    return ZsCouponApplyTo.None;
                }

                switch (this.ApplyToPlansRaw)
                {
                    case "select":
                        return ZsCouponApplyTo.Select;
                    case "all":
                        return ZsCouponApplyTo.All;
                    case "none":
                    default:
                        return ZsCouponApplyTo.None;
                }
            }
        }
        [JsonProperty("plans")]
        public List<string> Plans { get; set; }

        [JsonProperty("apply_to_addons")]
        internal string ApplyToAddonsRaw { get; set; }
        [JsonIgnore]
        public ZsCouponApplyTo ApplyToAddons
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.ApplyToAddonsRaw))
                {
                    return ZsCouponApplyTo.None;
                }

                switch (this.ApplyToAddonsRaw)
                {
                    case "select":
                        return ZsCouponApplyTo.Select;
                    case "all":
                        return ZsCouponApplyTo.All;
                    case "none":
                    default:
                        return ZsCouponApplyTo.None;
                }
            }
        }
        [JsonProperty("addons")]
        public List<string> Addons { get; set; }

        [JsonProperty("status")]
        internal string StatusRaw { get; set; }
        [JsonIgnore]
        public ZsCouponStatus Status
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.StatusRaw))
                {
                    return ZsCouponStatus.Active;
                }

                switch (this.StatusRaw)
                {
                    case "inactive":
                        return ZsCouponStatus.Inactive;
                    case "maxed_out":
                        return ZsCouponStatus.MaxedOut;
                    case "expired":
                        return ZsCouponStatus.Expired;
                    case "active":
                    default:
                        return ZsCouponStatus.Active;
                }
            }
        }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("expiry_at")]
        public DateTime ExpiryAt { get; set; }
        [JsonProperty("created_time")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_time")]
        public DateTime? UpdatedAt { get; set; }
    }
}