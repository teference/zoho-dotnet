namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    public sealed class ZsCardCreate : ZsCardUpdate
    {
        #region Constructor

        public ZsCardCreate()
        {
            this.PaymentGateway = ZsPaymentGateway.TestGateway;
        }

        #endregion

        #region Properties

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

        #endregion

        #region Methods

        internal new string Validate()
        {
            var baseValidationResult = base.Validate();
            if (!string.IsNullOrWhiteSpace(baseValidationResult))
            {
                return baseValidationResult;
            }

            return string.Empty;
        }

        #endregion
    }
}