namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public sealed class ZsAddon
    {
        public ZsAddon()
        {
            this.PriceBrackets = new List<ZsPriceBracket>();
        }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("addon_code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("unit_name")]
        public string UnitName { get; set; }

        [JsonProperty("pricing_scheme")]
        internal string PricingSchemeRaw { get; set; }

        [JsonIgnore]
        internal ZsAddonPricingScheme PricingScheme
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.PricingSchemeRaw))
                {
                    return ZsAddonPricingScheme.Unit;
                }

                switch (this.PricingSchemeRaw)
                {
                    case "unit":
                        return ZsAddonPricingScheme.Unit;
                    case "package":
                        return ZsAddonPricingScheme.Package;
                    case "tier":
                        return ZsAddonPricingScheme.Tier;
                    case "volume":
                        return ZsAddonPricingScheme.Volume;
                    default:
                        return ZsAddonPricingScheme.Unit;
                }
            }
        }

        [JsonProperty("price_brackets")]
        public List<ZsPriceBracket> PriceBrackets { get; set; }

        [JsonProperty("type")]
        internal string TypeRaw { get; set; }

        [JsonIgnore]
        public ZsAddonType Type
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.TypeRaw))
                {
                    return ZsAddonType.Recurring;
                }

                switch (this.TypeRaw)
                {
                    case "one_time":
                        return ZsAddonType.OneTime;
                    case "recurring":
                    default:
                        return ZsAddonType.Recurring;
                }
            }
        }

        // TODO: Zoho API bug.
        //[JsonProperty("interval_unit")]
        //internal string IntervalUnitRaw { get; set; }

        //[JsonIgnore]
        //public ZsAddonIntervalUnit IntervalUnit
        //{
        //    get
        //    {
        //        if (string.IsNullOrWhiteSpace(this.IntervalUnitRaw))
        //        {
        //            return ZsAddonIntervalUnit.Monthly;
        //        }

        //        switch (this.IntervalUnitRaw)
        //        {
        //            case "yearly":
        //                return ZsAddonIntervalUnit.Yearly;
        //            case "monthly":
        //            default:
        //                return ZsAddonIntervalUnit.Monthly;
        //        }
        //    }
        //}

        [JsonProperty("plans")]
        internal List<ZsAddonPlanCodeJson> PlansCodeRaw { get; set; }

        [JsonIgnore]
        public List<string> Plans
        {
            get
            {
                return null == this.PlansCodeRaw ? new List<string>() : this.PlansCodeRaw.Select(item => item.PlanCode).ToList();
            }
        }

        [JsonProperty("status")]
        internal string StatusRaw { get; set; }

        [JsonIgnore]
        public ZsStatus Status
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.StatusRaw))
                {
                    return ZsStatus.Active;
                }

                switch (this.StatusRaw)
                {
                    case "inactive":
                        return ZsStatus.Inactive;
                    case "active":
                    default:
                        return ZsStatus.Active;
                }
            }
        }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        // TODO: Setup and allow tax id.
        //[JsonProperty("tax_id")]
        //public string TaxId { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_time")]
        public DateTime? UpdatedAt { get; set; }
    }
}