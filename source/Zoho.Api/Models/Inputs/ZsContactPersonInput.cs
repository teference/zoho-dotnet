namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    public sealed class ZsContactPersonInput
    {
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

        internal string Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Email))
            {
                return "Contact person email is required";
            }

            return string.Empty;
        }
    }
}