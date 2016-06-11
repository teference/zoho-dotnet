namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System;

    #endregion

    public sealed class ZsContactPerson
    {
        [JsonProperty("contactperson_id")]
        public string ContactPersonId { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("mobile")]
        public string Mobile { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
        [JsonProperty("created_time")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_time")]
        public DateTime? UpdatedAt { get; set; }
    }
}