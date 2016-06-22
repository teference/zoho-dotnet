namespace Teference.Zoho.Api
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class ZsSubscription
    {
        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("customer")]
        public ZsSubscriptionCustomer Customer { get; set; }
        [JsonProperty("contactpersons")]
        public List<ZsSubscriptionContactperson> ContactPersons { get; set; }
        [JsonProperty("")]
        public double amount { get; set; }
        [JsonProperty("")]
        public string product_id { get; set; }
        [JsonProperty("")]
        public ZsSubscriptionPlan plan { get; set; }
        [JsonProperty("")]
        public List<ZsSubscriptionAddon> addons { get; set; }
        [JsonProperty("")]
        public ZsSubscriptionCoupon coupon { get; set; }
        [JsonProperty("")]
        public List<ZsCustomFieldEx> custom_fields { get; set; }
        [JsonProperty("")]
        public string activated_at { get; set; }
        [JsonProperty("")]
        public string reference_id { get; set; }
        [JsonProperty("")]
        public string currency_code { get; set; }
        [JsonProperty("")]
        public string currency_symbol { get; set; }
        [JsonProperty("")]
        public int exchange_rate { get; set; }
        [JsonProperty("")]
        public string starts_at { get; set; }
        [JsonProperty("")]
        public string status { get; set; }
        [JsonProperty("")]
        public bool auto_collect { get; set; }
        [JsonProperty("")]
        public string salesperson_id { get; set; }
        [JsonProperty("")]
        public string salesperson_name { get; set; }
        [JsonProperty("")]
        public ZsSubscriptionCard card { get; set; }
        [JsonProperty("")]
        public string child_invoice_id { get; set; }
        [JsonProperty("")]
        public string interval { get; set; }
        [JsonProperty("")]
        public string interval_unit { get; set; }
        [JsonProperty("")]
        public string current_term_starts_at { get; set; }
        [JsonProperty("")]
        public string current_term_ends_at { get; set; }
        [JsonProperty("")]
        public string expires_at { get; set; }
        [JsonProperty("")]
        public string last_billing_at { get; set; }
        [JsonProperty("")]
        public string next_billing_at { get; set; }
        [JsonProperty("")]
        public List<ZsSubscriptionNote> notes { get; set; }
        [JsonProperty("")]
        public string created_time { get; set; }
        [JsonProperty("updated_time")]
        public DateTime? updated_time { get; set; }
    }

    public class ZsSubscriptionNote
    {
        public string note_id { get; set; }
        public string description { get; set; }
        public string commented_by { get; set; }
        public string commented_time { get; set; }
    }

    public class ZsSubscriptionCard
    {
        public string payment_gateway { get; set; }
        public string card_id { get; set; }
        public string last_four_digits { get; set; }
        public int expiry_month { get; set; }
        public int expiry_year { get; set; }
    }

    public class ZsSubscriptionCoupon
    {
        public string coupon_code { get; set; }
        public string discount_amount { get; set; }
    }

    public class ZsSubscriptionAddon
    {
        public string addon_code { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public string tax_id { get; set; }
        public string description { get; set; }
    }

    public class ZsSubscriptionPlan
    {
        public string plan_code { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public int billing_cycles { get; set; }
        public int trial_days { get; set; }
        public string tax_id { get; set; }
        public string setup_fee_tax_id { get; set; }
        public string description { get; set; }
    }

    public class ZsSubscriptionContactperson
    {
        public string contactperson_id { get; set; }
        public string email { get; set; }
    }

    public class ZsSubscriptionCustomer
    {
        public string customer_id { get; set; }
        public string display_name { get; set; }
        public string company_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string currency_code { get; set; }
        public string currency_symbol { get; set; }
        public bool ach_supported { get; set; }
        public ZsCustomerAddress billing_address { get; set; }
        public ZsCustomerAddress shipping_address { get; set; }
        public List<ZsCustomField> custom_fields { get; set; }
        public string zcrm_account_id { get; set; }
        public string zcrm_contact_id { get; set; }
    }
}