namespace Teference.Zoho.Api
{
    using Newtonsoft.Json;

    public class ZsPlanCommon
    {
        [JsonProperty("plan_code")]
        public string PlanCode { get; set; }
        [JsonProperty("billing_cycles")]
        public int BillingCycles { get; set; }
        [JsonProperty("setup_fee")]
        public double SetupFee { get; set; }

        // TODO: Setup and allow tax id.
        //[JsonProperty("tax_id")]
        //public string TaxId { get; set; }
    }
}