namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    #endregion

    public sealed class ZsSubscriptionCreate
    {
        [JsonProperty("customer")]
        public ZsCustomerInput Customer { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("contactpersons")]
        public List<string> ContactPersons { get; set; }

        [JsonProperty("card_id")]
        public string CardId { get; set; }

        [JsonProperty("card")]
        public ZsCardCreate Card { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("bank_account")]
        public ZsBankAccount BankAccount { get; set; }

        [JsonProperty("exchange_rate")]
        public double ExchangeRate { get; set; }

        [JsonProperty("plan")]
        public ZsSubscriptionPlanOption Plan { get; set; }

        [JsonProperty("addons")]
        public List<ZsSubscriptionAddonOption> Addons { get; set; }

        [JsonProperty("coupon_code")]
        public string CouponCode { get; set; }
        [JsonProperty("auto_collect")]
        public bool AutoCollect { get; set; }
        [JsonIgnore]
        public DateTime? StartsAt { get; set; }
        [JsonProperty("starts_at")]
        public string StartsAtRaw
        {
            get
            {
                if(!this.StartsAt.HasValue)
                {
                    return null;
                }

                return this.StartsAt.Value.ToString("yyyy-MM-dd");
            }
        }
        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }
        [JsonProperty("salesperson_name")]
        public string SalesPersonName { get; set; }
        [JsonProperty("custom_fields")]
        public List<ZsCustomField> CustomFields { get; set; }
    }
}