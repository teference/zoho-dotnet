namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    #endregion

    public class ZsHostedPageCreateSubscriptionInput
    {
        #region Variable declaration

        private List<string> contactPersons;

        #endregion

        #region Properties

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
        [JsonProperty("customer")]
        public ZsCustomerInput Customer { get; set; }
        [JsonIgnore]
        public List<string> ContactPersons
        {
            get
            {
                return this.contactPersons;
            }

            set
            {
                this.contactPersons = value;
                if (this.contactPersons != null && this.contactPersons.Count > 0)
                {
                    this.ContactPersonsRaw = new List<ZsSubscriptionAddContactJson>();
                    foreach (var item in this.contactPersons)
                    {
                        this.ContactPersonsRaw.Add(new ZsSubscriptionAddContactJson { ContactPersonId = item });
                    }
                }
                else
                {
                    this.ContactPersonsRaw = null;
                }
            }
        }
        [JsonProperty("contactpersons")]
        internal List<ZsSubscriptionAddContactJson> ContactPersonsRaw { get; set; }
        [JsonProperty("plan")]
        public ZsHostedPageCreateSubscriptionInputPlan Plan { get; set; }
        [JsonProperty("addons")]
        public List<ZsHostedPageCreateSubscriptionInputAddon> Addons { get; set; }
        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }
        [JsonProperty("additional_param")]
        public string Additionalparam { get; set; }
        [JsonProperty("starts_at")]
        public DateTime? StartsAt { get; set; }
        [JsonProperty("custom_fields")]
        public List<ZsCustomFieldEx> CustomFields { get; set; }
        [JsonProperty("coupon_code")]
        public string CouponCode { get; set; }
        [JsonProperty("salesperson_name")]
        public string SalesPersonName { get; set; }
        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        #endregion

        #region Methods

        internal string Validate()
        {
            if (string.IsNullOrWhiteSpace(this.CustomerId))
            {
                if (string.IsNullOrWhiteSpace(Customer?.DisplayName) || string.IsNullOrWhiteSpace(this.Customer.Email))
                {
                    return "Customer (displayname, email) is required.";
                }

                return "Customer id is required.";
            }

            if (string.IsNullOrWhiteSpace(Plan?.PlanCode) || 0 == this.Plan.Quantity)
            {
                return "Plan details is required.";
            }

            return string.Empty;
        }

        #endregion
    }

    public class ZsHostedPageCreateSubscriptionInputPlan
    {
        [JsonProperty("plan_code")]
        public string PlanCode { get; set; }
        [JsonProperty("plan_description")]
        public string PlanDescription { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("setup_fee")]
        public double SetupFee { get; set; }
        [JsonProperty("setup_fee_tax_id")]
        public string SetupFeeTaxId { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("tax_id")]
        public string TaxId { get; set; }
        [JsonProperty("tax_exemption_id")]
        public string TaxExemptionId { get; set; }
        [JsonProperty("tax_exemption_code")]
        public string TaxExemptionCode { get; set; }
        [JsonProperty("setup_fee_tax_exemption_id")]
        public string SetupFeeTaxExemptionId { get; set; }
        [JsonProperty("setup_fee_tax_exemption_code")]
        public string SetupFeeTaxExemptionCode { get; set; }
        [JsonProperty("exclude_trial")]
        public bool ExcludeTrial { get; set; }
        [JsonProperty("exclude_setup_fee")]
        public bool ExcludeSetupFee { get; set; }
        [JsonProperty("billing_cycles")]
        public int BillingCycles { get; set; }
        [JsonProperty("trial_days")]
        public int TrialDays { get; set; }
    }

    public class ZsHostedPageCreateSubscriptionInputAddon
    {
        [JsonProperty("addon_code")]
        public string AddonCode { get; set; }
        [JsonProperty("addon_description")]
        public string AddonDescription { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("tax_id")]
        public string TaxId { get; set; }
        [JsonProperty("tax_exemption_id")]
        public string TaxExemptionId { get; set; }
        [JsonProperty("tax_exemption_code")]
        public string TaxExemptionCode { get; set; }
    }
}