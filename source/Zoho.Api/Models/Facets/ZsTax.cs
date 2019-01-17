namespace Teference.Zoho.Api
{
    #region Namespace

    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    #endregion

    public sealed class ZsTax
    {
        [JsonProperty("tax_id")]
        public string Id { get; set; }
        
        [JsonProperty("tax_name")]
        public string Name { get; set; }

        [JsonProperty("tax_percentage")]
        public double Percentage { get; set; }

        [JsonProperty("tax_type")]
        public string Type { get; set; }

        [JsonProperty("is_default_tax")]
        public bool IsDefault { get; set; }

        [JsonProperty("is_editable")]
        public bool IsEditable { get; set; }

        [JsonProperty("tax_authority_id")]
        public string AuthorityId { get; set; }
        
        [JsonProperty("tax_authority_name")]
        public string AuthorityName { get; set; }
    }       
}
