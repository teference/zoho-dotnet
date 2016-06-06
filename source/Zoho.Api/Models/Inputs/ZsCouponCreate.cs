namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System.Collections.Generic;

    #endregion

    public class ZsCouponCreate : ZsCouponUpdate
    {
        [JsonProperty("coupon_code")]
        public string Code { get; set; }

        [JsonIgnore]
        public ZsCouponType Type { get; set; }

        [JsonProperty("type")]
        internal string TypeRaw
        {
            get
            {
                if (this.Type == ZsCouponType.None || this.Type == ZsCouponType.OneTime)
                {
                    return "one_time";
                }

                return this.Type.ToString().ToLowerInvariant();
            }
        }

        [JsonProperty("discount_by")]
        internal string DiscountByRaw
        {
            get
            {
                if (this.DiscountBy == ZsCouponDiscountBy.None)
                {
                    return "flat";
                }

                return this.DiscountBy.ToString().ToLowerInvariant();
            }
        }
        [JsonIgnore]
        public ZsCouponDiscountBy DiscountBy { get; set; }
        [JsonProperty("discount_value")]
        public double DiscountValue { get; set; }

        [JsonProperty("apply_to_plans")]
        internal string ApplyToPlansRaw
        {
            get
            {
                return this.ApplyToPlans.ToString().ToLowerInvariant();
            }
        }
        [JsonIgnore]
        public ZsCouponApplyTo ApplyToPlans { get; set; }
        [JsonProperty("plans")]
        public List<string> Plans { get; set; }

        [JsonProperty("apply_to_addons")]
        internal string ApplyToAddonsRaw
        {
            get
            {
                return this.ApplyToPlans.ToString().ToLowerInvariant();
            }
        }
        [JsonIgnore]
        public ZsCouponApplyTo ApplyToAddons { get; set; }
        [JsonProperty("addons")]
        public List<string> Addons { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        internal new string Validate()
        {
            var baseValidationResult = base.Validate();
            if (!string.IsNullOrWhiteSpace(baseValidationResult))
            {
                return baseValidationResult;
            }

            if (string.IsNullOrWhiteSpace(this.Code))
            {
                return "Coupon code is required.";
            }

            if (string.IsNullOrWhiteSpace(this.ProductId))
            {
                return "Product Id is required.";
            }

            if(this.Type == ZsCouponType.None)
            {
                return "Coupon type is required.";
            }

            if(this.DiscountBy == ZsCouponDiscountBy.None)
            {
                return "Coupon discount by type is required.";
            }

            if(this.ApplyToPlans == ZsCouponApplyTo.Select && (null == this.Plans || this.Plans.Count == 0))
            {
                return "Plan list is required to be filled when 'apply to plans' is set to 'select'";
            }

            if (this.ApplyToAddons == ZsCouponApplyTo.Select && (null == this.Addons || this.Addons.Count == 0))
            {
                return "Addon list is required to be filled when 'apply to addons' is set to 'select'";
            }

            return string.Empty;
        }
    }
}