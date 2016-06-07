namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System;

    #endregion

    public sealed class ZsCard
    {
        [JsonProperty("card_id")]
        public string CardId { get; set; }
        [JsonProperty("last_four_digits")]
        public int CardLastFourDigits { get; set; }
        [JsonProperty("cvv_number")]
        public int CvvNumber { get; set; }
        [JsonProperty("expiry_month")]
        public int ExpiryMonth { get; set; }
        [JsonProperty("expiry_year")]
        public int ExpiryYear { get; set; }
        [JsonProperty("payment_gateway")]
        internal string PaymentGatewayRaw { get; set; }
        [JsonIgnore]
        public ZsPaymentGateway PaymentGateway
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.PaymentGatewayRaw))
                {
                    return ZsPaymentGateway.TestGateway;
                }

                switch (this.PaymentGatewayRaw)
                {
                    case "payflow_pro":
                        return ZsPaymentGateway.PayflowPro;
                    case "stripe":
                        return ZsPaymentGateway.Stripe;
                    case "2checkout":
                        return ZsPaymentGateway.TwoCheckout;
                    case "authorize_net":
                        return ZsPaymentGateway.AuthorizeNet;
                    case "payments_pro":
                        return ZsPaymentGateway.PaymentsPro;
                    case "forte":
                        return ZsPaymentGateway.Forte;
                    case "world_pay":
                        return ZsPaymentGateway.WorldPay;
                    case "test_gateway":
                    default:
                        return ZsPaymentGateway.TestGateway;
                }
            }
        }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("zip")]
        public string Zip { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("created_time")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_time")]
        public DateTime UpdatedAt { get; set; }
    }
}