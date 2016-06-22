namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    #endregion

    public sealed class ZsPlan : ZsPlanCommon
    {
        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("recurring_price")]
        public double RecurringPrice { get; set; }
        [JsonProperty("interval")]
        public int Interval { get; set; }
        [JsonProperty("interval_unit")]
        internal string IntervalUnitRaw { get; set; }
        [JsonIgnore]
        public ZsIntervalUnit IntervalUnit
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.IntervalUnitRaw))
                {
                    return ZsIntervalUnit.Monthly;
                }

                switch (this.IntervalUnitRaw)
                {
                    case "years":
                        return ZsIntervalUnit.Yearly;
                    case "months":
                    default:
                        return ZsIntervalUnit.Monthly;
                }
            }
        }

        [JsonProperty("trial_period")]
        public int TrailPeriod { get; set; }
        [JsonProperty("addons")]
        public List<ZsPlanAddon> Addons { get; set; }

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

        // TODO: Setup and allow tax id.
        //[JsonProperty("tax_id")]
        //public string TaxId { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_time")]
        public DateTime? UpdatedAt { get; set; }
    }
}