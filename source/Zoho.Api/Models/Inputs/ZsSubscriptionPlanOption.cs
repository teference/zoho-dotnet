namespace Teference.Zoho.Api
{
    using Newtonsoft.Json;

    public sealed class ZsSubscriptionPlanOption : ZsPlanCommon
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("exclude_trial")]
        public bool ExcludeTrial { get; set; }

        [JsonProperty("exclude_setup_fee")]
        public bool ExcludeSetupFee { get; set; }

        [JsonProperty("trial_days")]
        public int TrialPeriod { get; set; }

        [JsonProperty("setup_fee_tax_id")]
        public string SetupFeeTaxId { get; set; }

        //[JsonProperty("trial_days")]
        //public string tax_id { get; set; }
    }
}