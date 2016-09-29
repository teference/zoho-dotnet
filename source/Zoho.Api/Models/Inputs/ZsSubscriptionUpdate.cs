namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel;

    #endregion

    public sealed class ZsSubscriptionUpdate
    {
        public ZsSubscriptionUpdate()
        {
            this.IsEndOfTerm = false;
            this.IsProrated = true;
            this.AutoCollect = true;
        }

        [JsonProperty(PropertyName = "card_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CardId { get; set; }

        [JsonProperty(PropertyName = "exchange_rate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double ExchangeRate { get; set; }

        [JsonProperty(PropertyName = "reference_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ReferenceId { get; set; }

        [JsonProperty("end_of_term")]
        public bool IsEndOfTerm { get; set; }

        [JsonProperty("prorate")]
        public bool IsProrated { get; set; }

        [JsonProperty("auto_collect")]
        public bool AutoCollect { get; set; }

        [JsonProperty("plan")]
        public ZsSubscriptionUpdatePlan Plan { get; set; }

        [JsonProperty(PropertyName = "addons", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<ZsSubscriptionUpdateAddon> Addons { get; set; }

        [JsonProperty(PropertyName = "contactpersons", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<ZsSubscriptionUpdateContactperson> ContactPersons { get; set; }
    }

    public class ZsSubscriptionUpdateContactperson
    {
        [JsonProperty("contactperson_id")]
        public string ContactPersonId { get; set; }
    }

    public class ZsSubscriptionUpdatePlan
    {
        [JsonRequired]
        [JsonProperty("plan_code")]
        public string PlanCode { get; set; }

        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double Price { get; set; }

        [DefaultValue(1)]
        [JsonProperty(PropertyName = "quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "billing_cycles", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int BillingCycles { get; set; }

        [JsonProperty(PropertyName = "trial_days", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TrialDays { get; set; }

        [JsonProperty(PropertyName = "tax_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string TaxId { get; set; }

        [JsonProperty(PropertyName = "setup_fee_tax_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SetupFeeTaxId { get; set; }
    }

    public class ZsSubscriptionUpdateAddon
    {
        [JsonRequired]
        [JsonProperty("addon_code")]
        public string AddonCode { get; set; }

        [JsonProperty(PropertyName = "price", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double Price { get; set; }

        [DefaultValue(1)]
        [JsonProperty(PropertyName = "quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "tax_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string TaxId { get; set; }
    }
}