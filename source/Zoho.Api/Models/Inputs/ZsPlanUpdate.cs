namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    public class ZsPlanUpdate
    {
        public ZsPlanUpdate()
        {
            this.IntervalUnit = ZsIntervalUnit.Monthly;
            this.RecurringPrice = default(double);
            this.Interval = 0;
            this.BillingCycles = -1;
            this.TrailPeriod = 0;
            this.SetupFee = 0;
        }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("recurring_price")]
        public double RecurringPrice { get; set; }
        [JsonProperty("interval")]
        public int Interval { get; set; }
        [JsonProperty("interval_unit")]
        internal string IntervalUnitRaw
        {
            get
            {
                if (this.IntervalUnit == ZsIntervalUnit.Monthly)
                {
                    return "months";
                }
                else if (this.IntervalUnit == ZsIntervalUnit.Yearly)
                {
                    return "years";
                }
                else
                {
                    return "months";
                }
            }
        }
        [JsonIgnore]
        public ZsIntervalUnit IntervalUnit { get; set; }
        [JsonProperty("billing_cycles")]
        public int BillingCycles { get; set; }

        [JsonProperty("trial_period")]
        public int TrailPeriod { get; set; }
        [JsonProperty("setup_fee")]
        public double SetupFee { get; set; }

        // TODO: Setup and allow tax id.
        //[JsonProperty("tax_id")]
        //public string TaxId { get; set; }

        internal string Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                return "Plan name is required.";
            }

            if(this.RecurringPrice == default(double))
            {
                return "Plan recurring price is required.";
            }

            if (this.Interval == 0)
            {
                return "Plan interval is required and should be greater than 0.";
            }

            return string.Empty;
        }
    }
}