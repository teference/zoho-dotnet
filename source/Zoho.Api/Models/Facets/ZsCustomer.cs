namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    #endregion

    public sealed class ZsCustomer
    {
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("mobile")]
        public string Mobile { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
        [JsonProperty("currency_symbol")]
        public string CurrencySymbol { get; set; }
        [JsonProperty("currency_id")]
        public string CurrencyId { get; set; }

        [JsonProperty("price_precision")]
        public double PricePrecision { get; set; }
        [JsonProperty("unused_credits")]
        public double UnusedCredits { get; set; }
        // TODO: "outstanding_receivable_amount": 0 - Is this balance??
        [JsonProperty("balance")]
        public double Balance { get; set; }
        [JsonProperty("outstanding")]
        public double Outstanding { get; set; }

        [JsonProperty("is_gapps_customer")]
        public bool IsFromGoogleApps { get; set; }

        #region Fields not getting filled when GETALL API is called

        [JsonProperty("ach_supported")]
        public bool IsAchSupported { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("zcrm_account_id")]
        public string CrmAccountId { get; set; }
        [JsonProperty("zcrm_contact_id")]
        public string CrmContactId { get; set; }
        [JsonProperty("billing_address")]
        public ZsCustomerAddress BillingAddress { get; set; }
        [JsonProperty("shipping_address")]
        public ZsCustomerAddress ShippingAddress { get; set; }
        [JsonProperty("custom_fields")]
        public List<ZsCustomerField> CustomFields { get; set; }

        #endregion

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

        [JsonProperty("created_time")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_time")]
        public DateTime? UpdatedAt { get; set; }
    }
}