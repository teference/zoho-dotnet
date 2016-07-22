namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    public class ZsHostedPageUpdateCardInput
    {
        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }
        [JsonProperty("additional_param")]
        public string AdditionalParameter { get; set; }
        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        internal string Validate()
        {
            if (string.IsNullOrWhiteSpace(this.SubscriptionId))
            {
                return "Subscription id is required.";
            }

            return string.Empty;
        }
    }
}