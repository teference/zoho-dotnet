namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class ZsAddonUpdate
    {
        public ZsAddonUpdate()
        {
            this.PricingScheme = ZsAddonPricingScheme.Unit;
            this.Type = ZsAddonType.Recurring;
            this.IntervalUnit = ZsAddonIntervalUnit.Monthly;
            this.IsApplicableToAllPlans = true;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("unit_name")]
        public string UnitName { get; set; }

        [JsonIgnore]
        public ZsAddonType Type { get; set; }

        [JsonProperty("type")]
        internal string TypeRaw
        {
            get
            {
                if (this.Type == ZsAddonType.OneTime)
                {
                    return "one_time";
                }

                return this.Type.ToString().ToLowerInvariant();
            }
        }

        [JsonIgnore]
        public ZsAddonIntervalUnit IntervalUnit { get; set; }

        [JsonProperty("interval_unit")]
        public string IntervalUnitRaw
        {
            get
            {
                return this.IntervalUnit.ToString().ToLowerInvariant();
            }
        }

        [JsonProperty("applicable_to_all_plans")]
        public bool IsApplicableToAllPlans { get; set; }

        [JsonIgnore]
        public List<string> Plans { get; set; }

        [JsonProperty("plans")]
        internal List<ZsAddonPlanCodeJson> PlansCodeRaw { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        // TODO: Setup and allow tax id.
        //[JsonProperty("tax_id")]
        //public string TaxId { get; set; }


        [JsonIgnore]
        public ZsAddonPricingScheme PricingScheme { get; set; }

        [JsonProperty("pricing_scheme")]
        public string PricingSchemeRaw
        {
            get
            {
                return this.PricingScheme.ToString().ToLowerInvariant();
            }
        }

        [JsonProperty("price_brackets")]
        public List<ZsPriceBracket> PriceBrackets { get; set; }


        internal string Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                return "Addon name is required.";
            }

            if (string.IsNullOrWhiteSpace(this.UnitName))
            {
                return "Addon unit name is required.";
            }

            if ((this.PricingScheme == ZsAddonPricingScheme.Volume || this.PricingScheme == ZsAddonPricingScheme.Tier) && this.PriceBrackets.Any(item => !item.StartQuantity.HasValue || item.StartQuantity.Value == 0))
            {
                return "Price bracket - Start Quantity value is required for Volume and Tier pricing schemes type.";
            }

            if ((this.PricingScheme == ZsAddonPricingScheme.Volume || this.PricingScheme == ZsAddonPricingScheme.Tier || this.PricingScheme == ZsAddonPricingScheme.Package) && this.PriceBrackets.Any(item => !item.EndQuantity.HasValue || item.EndQuantity.Value == 0))
            {
                return "Price bracket - Start Quantity value is required for Volume, Tier and Package pricing schemes type.";
            }

            if (this.PriceBrackets.Any(item => !item.EndQuantity.HasValue || item.EndQuantity.Value == 0))
            {
                return "Price bracket - Price value is required.";
            }

            if (!this.IsApplicableToAllPlans && (null == this.Plans || this.Plans.Any(item => string.IsNullOrWhiteSpace(item))))
            {
                return "Plan codes list is required if IsApplicableToAllPlans is set to false.";
            }

            return string.Empty;
        }
    }
}