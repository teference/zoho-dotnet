namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    #endregion

    public sealed class ZsHostedPageUpdateSubscriptionInput
    {
        #region Variable declaration

        private List<string> contactPersons;

        #endregion

        #region Properties

        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }

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
        public ZsHostedPageUpdateSubscriptionInputPlan Plan { get; set; }
        [JsonProperty("addons")]
        public List<ZsHostedPageUpdateSubscriptionInputAddon> Addons { get; set; }
        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }
        [JsonProperty("additional_param")]
        public string Additionalparam { get; set; }
        [JsonProperty("starts_at")]
        public DateTime? StartsAt { get; set; }
        [JsonProperty("coupon_code")]
        public string CouponCode { get; set; }
        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        #endregion

        #region Methods

        internal string Validate()
        {
            if (string.IsNullOrWhiteSpace(this.SubscriptionId))
            {
                return "Subscription id is required.";
            }

            if (null == this.Plan || string.IsNullOrWhiteSpace(this.Plan.PlanCode))
            {
                return "Plan details is required.";
            }

            if (string.IsNullOrWhiteSpace(this.Plan.PlanCode))
            {
                return "Plan code is required.";
            }

            if (this.Plan.Quantity == 0)
            {
                return "Plan quantity is required.";
            }

            return string.Empty;
        }

        #endregion
    }

    public class ZsHostedPageUpdateSubscriptionInputPlan
    {
        [JsonProperty("plan_code")]
        public string PlanCode { get; set; }
        [JsonProperty("price")]
        public int Price { get; set; }
        [JsonProperty("exclude_setup_fee")]
        public bool ExcludeSetupFee { get; set; }
        [JsonProperty("exclude_trial")]
        public bool ExcludeTrial { get; set; }
        [JsonProperty("trial_days")]
        public int TrialDays { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("billing_cycles")]
        public int BillingCycles { get; set; }
    }

    public class ZsHostedPageUpdateSubscriptionInputAddon
    {
        [JsonProperty("addon_code")]
        public string AddonCode { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
    }
}