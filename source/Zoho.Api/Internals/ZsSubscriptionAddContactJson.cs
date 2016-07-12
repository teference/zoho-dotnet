namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System.Collections.Generic;

    #endregion

    internal class ZsSubscriptionAddContactsJson
    {
        [JsonProperty("contactpersons")]
        internal List<ZsSubscriptionAddContactJson> ContactPersons { get; set; }
    }

    internal class ZsSubscriptionAddContactJson
    {
        [JsonProperty("contactperson_id")]
        public string ContactPersonId { get; set; }
    }
}