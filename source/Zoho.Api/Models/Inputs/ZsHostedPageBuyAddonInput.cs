using System.Linq;

namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System.Collections.Generic;

    #endregion

    public class ZsHostedPageBuyAddonInput
    {
        #region Properties

        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }
        [JsonProperty("addons")]
        public List<ZsHostedPageBuyAddonInputAddon> Addons { get; set; }
        [JsonProperty("additional_param")]
        public string AdditionalParam { get; set; }
        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }
        [JsonProperty("coupon_code")]
        public string CouponCode { get; set; }

        #endregion

        #region Methods

        internal string Validate()
        {
            if (string.IsNullOrWhiteSpace(this.SubscriptionId))
            {
                return "Subscription id is required.";
            }

            if (null == this.Addons || this.Addons.Any(item => string.IsNullOrWhiteSpace(item.AddonCode)))
            {
                return "At least one addon is required with AddonCode specified.";
            }

            return string.Empty;
        }

        #endregion
    }

    public class ZsHostedPageBuyAddonInputAddon
    {
        [JsonProperty("addon_code")]
        public string AddonCode { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("tax_id")]
        public string TaxId { get; set; }
        [JsonProperty("tax_exemption_id")]
        public string TaxExemptionId { get; set; }
        [JsonProperty("tax_exemption_code")]
        public string TaxExemptionCode { get; set; }
        [JsonProperty("product_type")]
        public string ProductType { get; set; }
    }
}