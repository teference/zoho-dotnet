namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    #endregion

    public class ZsSubscription
    {
        [JsonProperty("subscription_id")] //
        public string SubscriptionId { get; set; }
        [JsonProperty("name")] //
        public string Name { get; set; }
        [JsonProperty("sub_total")]//
        public double SubTotal { get; set; }
        [JsonProperty("amount")]//
        public double Amount { get; set; }
        [JsonProperty("product_id")]//
        public string ProductId { get; set; }
        [JsonProperty("product_name")]//
        public string ProductName { get; set; }
        [JsonProperty("reference_id")]//
        public string ReferenceId { get; set; }
        [JsonProperty("pricebook_id")]//
        public string PricebookId { get; set; }
        [JsonProperty("currency_code")]//
        public string CurrencyCode { get; set; }
        [JsonProperty("currency_symbol")]//
        public string CurrencySymbol { get; set; }
        //[JsonProperty("exchange_rate")]
        //public double ExchangeRate { get; set; }
        [JsonProperty("status")]//
        public string Status { get; set; }
        [JsonProperty("auto_collect")]//
        public bool AutoCollect { get; set; }
        [JsonProperty("end_of_term")]//
        public bool IsEndOfTerm { get; set; }
        [JsonProperty("payment_terms")]//
        public int PaymentTerms { get; set; }
        [JsonProperty("payment_terms_label")]//
        public string PaymentTermsLabel { get; set; }
        [JsonProperty("can_add_bank_account")]//
        public bool CanAddBankAccount { get; set; }
        [JsonProperty("salesperson_id")]//
        public string SalesPersonId { get; set; }
        [JsonProperty("salesperson_name")]//
        public string SalesPersonName { get; set; }
        //[JsonProperty("child_invoice_id")]
        //public string ChildInvoiceId { get; set; }
        [JsonProperty("interval")]//
        public int Interval { get; set; }
        // TODO: This should be an enum.
        [JsonProperty("interval_unit")]//
        public string IntervalUnit { get; set; }
        [JsonProperty("trial_remaining_days")]//
        public int TrialRemainingDays { get; set; }

        [JsonProperty("plan")]//
        public ZsSubscriptionPlan Plan { get; set; }
        //[JsonProperty("taxes")] // This one is a array of some kind.
        //public string Taxes { get; set; }
        [JsonProperty("customer")]
        public ZsSubscriptionCustomer Customer { get; set; }
        [JsonProperty("contactpersons")]
        public List<ZsSubscriptionContactperson> ContactPersons { get; set; }
        [JsonProperty("addons")]//
        public List<ZsSubscriptionAddon> Addons { get; set; }
        [JsonProperty("coupon")]
        public ZsSubscriptionCoupon Coupon { get; set; }
        [JsonProperty("custom_fields")]//
        public List<ZsCustomField> CustomFields { get; set; }
        [JsonProperty("card")]
        public ZsSubscriptionCard Card { get; set; }
        [JsonProperty("notes")]//
        public List<ZsSubscriptionNote> Notes { get; set; }
        //[JsonProperty("payment_gateways")] // This one is a array of some kind.
        //public string PaymentGateways { get; set; }

        [JsonProperty("previous_attribute")]
        public ZsSubscriptionPreviousData PreviousData { get; set; }

        [JsonProperty("trial_starts_at")]//
        public DateTime? TrialStartsAt { get; set; }
        [JsonProperty("trial_ends_at")]//
        public DateTime? TrialEndsAt { get; set; }
        [JsonProperty("activated_at")]//
        public DateTime ActivatedAt { get; set; }
        //[JsonProperty("starts_at")]
        //public DateTime StartsAt { get; set; }
        [JsonProperty("current_term_starts_at")]//
        public DateTime CurrentTermStartsAt { get; set; }
        [JsonProperty("current_term_ends_at")]//
        public DateTime CurrentTermEndsAt { get; set; }
        [JsonProperty("expires_at")]//
        public DateTime? ExpiresAt { get; set; }
        //[JsonProperty("last_billing_at")]
        //public DateTime LastBillingAt { get; set; }
        [JsonProperty("next_billing_at")]//
        public DateTime? NextBillingAt { get; set; }
        [JsonProperty("created_at")]//
        public DateTime CreatedAtDate { get; set; }
        [JsonProperty("created_time")]//
        public DateTime CreatedAtDateTime { get; set; }
        [JsonProperty("updated_time")]//
        public DateTime? UpdatedAtDateTime { get; set; }
    }

    public class ZsSubscriptionCard
    {
        [JsonProperty("payment_gateway")]
        public string PaymentGateway { get; set; }
        [JsonProperty("card_id")]
        public string CardId { get; set; }
        [JsonProperty("last_four_digits")]
        public string LastFourDigits { get; set; }
        [JsonProperty("expiry_month")]
        public int ExpiryMonth { get; set; }
        [JsonProperty("expiry_year")]
        public int ExpiryYear { get; set; }
    }

    public class ZsSubscriptionCoupon
    {
        [JsonProperty("coupon_code")]
        public string CouponCode { get; set; }
        [JsonProperty("discount_amount")]
        public string DiscountAmount { get; set; }
    }

    public class ZsSubscriptionAddon
    {
        [JsonProperty("addon_code")]
        public string AddonCode { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("tax_id")]
        public string TaxId { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class ZsSubscriptionPlan
    {
        [JsonProperty("plan_code")]
        public string PlanCode { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("discount")]
        public double Discount { get; set; }
        [JsonProperty("total")]
        public double Total { get; set; }
        [JsonProperty("setup_fee")]
        public double SetupFee { get; set; }
        //[JsonProperty("billing_cycles")]
        //public int BillingCycles { get; set; }
        //[JsonProperty("trial_days")]
        //public int TrialDays { get; set; }
        [JsonProperty("tax_id")]
        public string TaxId { get; set; }
        [JsonProperty("setup_fee_tax_id")]
        public string SetupFeeTaxId { get; set; }
        [JsonProperty("tax_name")]
        public string TaxName { get; set; }
        [JsonProperty("tax_percentage")]
        public string TaxPercentage { get; set; }
        [JsonProperty("tax_type")]
        public string TaxType { get; set; }
        [JsonProperty("setup_fee_tax_name")]
        public string SetupFeeTaxName { get; set; }
        [JsonProperty("setup_fee_tax_percentage")]
        public string SetupFeeTaxPercentage { get; set; }
        [JsonProperty("setup_fee_tax_type")]
        public string SetupFeeTaxType { get; set; }
    }

    public class ZsSubscriptionContactperson
    {
        [JsonProperty("contactperson_id")]
        public string ContactPersonId { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("mobile")]
        public string Mobile { get; set; }
        [JsonProperty("zcrm_contact_id")]
        public string ZCrmContactId { get; set; }
    }

    public class ZsSubscriptionCustomer
    {
        [JsonProperty("customer_id")]//
        public string CustomerId { get; set; }
        [JsonProperty("display_name")]//
        public string DisplayName { get; set; }
        [JsonProperty("company_name")]//
        public string CompanyName { get; set; }
        [JsonProperty("first_name")]//
        public string FirstName { get; set; }
        [JsonProperty("last_name")]//
        public string LastName { get; set; }
        [JsonProperty("email")]//
        public string Email { get; set; }
        [JsonProperty("website")]//
        public string Website { get; set; }
        [JsonProperty("currency_code")] //?
        public string CurrencyCode { get; set; }
        [JsonProperty("currency_symbol")] //?
        public string CurrencySymbol { get; set; }
        [JsonProperty("ach_supported")] //?
        public bool IsAchSupported { get; set; }
        [JsonProperty("zcrm_account_id")]//
        public string ZCrmAccountId { get; set; }
        [JsonProperty("zcrm_contact_id")]//
        public string ZCrmContactId { get; set; }

        [JsonProperty("payment_terms")]
        public int PaymentTerms { get; set; }
        [JsonProperty("payment_terms_label")]
        public string PaymentTermsLabel { get; set; }

        [JsonProperty("billing_address")]
        public ZsCustomerAddress BillingAddress { get; set; }
        [JsonProperty("shipping_address")]
        public ZsCustomerAddress ShippingAddress { get; set; }
        [JsonProperty("custom_fields")] //?
        public List<ZsCustomField> CustomField { get; set; }
    }

    public class ZsSubscriptionPreviousData
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("plan_code")]
        public string PlanCode { get; set; }

        [JsonProperty("plan_id")]
        public string PlanId { get; set; }

        [JsonProperty("plan_name")]
        public string PlanName { get; set; }
    }
}