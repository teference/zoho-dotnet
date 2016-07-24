namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    internal class ZsSubscriptionPostponeRenewalJson
    {
        [JsonProperty("renewal_at")]
        internal string RenewalAt { get; set; }
    }
}