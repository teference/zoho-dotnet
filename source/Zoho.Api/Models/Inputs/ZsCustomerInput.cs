namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public sealed class ZsCustomerInput
    {
        public ZsCustomerInput()
        {
            this.CurrencyCode = "USD";
        }

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

        [JsonProperty("billing_address")]
        public ZsCustomerAddress BillingAddress { get; set; }
        [JsonProperty("shipping_address")]
        public ZsCustomerAddress ShippingAddress { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
        [JsonProperty("ach_supported")]
        public bool IsAchSupported { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("custom_fields")]
        public List<ZsCustomerField> CustomFields { get; set; }

        internal string Validate()
        {
            if (string.IsNullOrWhiteSpace(this.DisplayName))
            {
                return "Customer display name is required";
            }

            if (string.IsNullOrWhiteSpace(this.Email))
            {
                return "Customer email is required";
            }

            if (null != this.CustomFields && this.CustomFields.Count > 0 && this.CustomFields.Any(item => string.IsNullOrWhiteSpace(item.Value)))
            {
                return "Customer - custom field - value is required";
            }

            return string.Empty;
        }
    }
}