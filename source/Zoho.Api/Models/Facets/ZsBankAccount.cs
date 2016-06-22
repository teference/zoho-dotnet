namespace Teference.Zoho.Api
{
    using Newtonsoft.Json;

    public sealed class ZsBankAccount
    {
        [JsonIgnore]
        public ZsPaymentGateway PaymentGateway { get; set; }

        [JsonProperty("payment_gateway")]
        internal string PaymentGatewayRaw
        {
            get
            {
                switch (this.PaymentGateway)
                {
                    case ZsPaymentGateway.PayflowPro:
                        return "payflow_pro";
                    case ZsPaymentGateway.Stripe:
                        return "stripe";
                    case ZsPaymentGateway.TwoCheckout:
                        return "2checkout";
                    case ZsPaymentGateway.AuthorizeNet:
                        return "authorize_net";
                    case ZsPaymentGateway.PaymentsPro:
                        return "payments_pro";
                    case ZsPaymentGateway.Forte:
                        return "forte";
                    case ZsPaymentGateway.WorldPay:
                        return "world_pay";
                    case ZsPaymentGateway.TestGateway:
                    default:
                        return "test_gateway";
                }
            }
        }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }
        [JsonProperty("routing_number")]
        public string RoutingNumber { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("accept_license")]
        public bool AcceptLicense { get; set; }
    }
}