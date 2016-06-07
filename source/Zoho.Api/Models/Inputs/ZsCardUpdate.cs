namespace Teference.Zoho.Api
{
    using Newtonsoft.Json;

    public class ZsCardUpdate
    {
        [JsonProperty("card_number")]
        public string CardNumber { get; set; }
        [JsonProperty("cvv_number")]
        public int CvvNumber { get; set; }
        [JsonProperty("expiry_month")]
        public int ExpiryMonth { get; set; }
        [JsonProperty("expiry_year")]
        public int ExpiryYear { get; set; }
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

        internal string Validate()
        {
            if (string.IsNullOrWhiteSpace(this.CardNumber))
            {
                return "Card number is required.";
            }

            if (this.CvvNumber == 0 || this.CvvNumber < 100 || this.CvvNumber > 999)
            {
                return "Card CVV number is missing or not valid.";
            }

            if (this.ExpiryMonth == 0 || this.ExpiryMonth > 12)
            {
                return "Card expiry month is missing or not valid.";
            }

            if (this.ExpiryYear == 0 || this.CvvNumber < 1000 || this.CvvNumber > 9999)
            {
                return "Card expiry year is missing or not valid.";
            }

            if (string.IsNullOrWhiteSpace(this.Street))
            {
                return "Card street is required.";
            }

            if (string.IsNullOrWhiteSpace(this.City))
            {
                return "Card city is required.";
            }

            if (string.IsNullOrWhiteSpace(this.State))
            {
                return "Card state is required.";
            }

            if (string.IsNullOrWhiteSpace(this.Zip))
            {
                return "Card zip is required.";
            }

            if (string.IsNullOrWhiteSpace(this.Country))
            {
                return "Card country is required.";
            }

            return string.Empty;
        }
    }
}