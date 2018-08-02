namespace Teference.Zoho.Api
{
    #region Namespace

    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    #endregion

    public sealed class ZsInvoice
    {
        [JsonProperty("invoice_id")]
        public string InvoiceId { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("status")]
        internal string StatusRaw { get; set; }

        [JsonIgnore]
        public ZsInvoiceStatus Status
        {
            get
            {
                switch (this.StatusRaw)
                {
                    case "paid":
                        return ZsInvoiceStatus.Paid;
                    case "sent":
                        return ZsInvoiceStatus.Sent;
                    case "overdue":
                        return ZsInvoiceStatus.Overdue;
                    case "partially_paid":
                        return ZsInvoiceStatus.PartiallyPaid;
                    case "void":
                        return ZsInvoiceStatus.Void;
                    case "pending":
                    default:
                        return ZsInvoiceStatus.Pending;
                }
            }
        }

        [JsonProperty("invoice_date")]
        public DateTime InvoiceDate { get; set; }

        [JsonProperty("due_date")]
        public DateTime? DueDate { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("invoice_items")]
        public List<ZsInvoiceItem> InvoiceItems { get; set; }

        [JsonProperty("coupons")]
        public List<ZsInvoiceCoupon> Coupons { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }

        [JsonProperty("payment_made")]
        public double PaymentMade { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("credits_applied")]
        public double CreditsApplied { get; set; }

        [JsonProperty("write_off_amount")]
        public double WriteOffAmount { get; set; }

        [JsonProperty("payments")]
        public List<ZsInvoicePayment> Payments { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_time")]
        public DateTime? UpdatedAt { get; set; }
    }

    public class ZsInvoiceItem
    {
        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("item_total")]
        public double ItemTotal { get; set; }

        [JsonProperty("tax_id")]
        public string TaxId { get; set; }
    }

    public class ZsInvoiceCoupon
    {
        [JsonProperty("coupon_code")]
        public string CouponCode { get; set; }

        [JsonProperty("discount_amount")]
        public double DiscountAmount { get; set; }

        [JsonProperty("coupon_name")]
        public string CouponName { get; set; }
    }

    public class ZsInvoicePayment
    {
        [JsonProperty("payment_id")]
        public string PaymentId { get; set; }

        [JsonProperty("payment_mode")]
        public string PaymentMode { get; set; }

        [JsonProperty("invoice_payment_id")]
        public string InvoicePaymentId { get; set; }

        [JsonProperty("gateway_transaction_id")]
        public string GatewayTransactionId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        [JsonProperty("reference_number")]
        public string ReferenceNumber { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}