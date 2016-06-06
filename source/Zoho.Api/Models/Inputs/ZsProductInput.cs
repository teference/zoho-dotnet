namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    #endregion

    public sealed class ZsProductInput
    {
        public ZsProductInput()
        {
            this.Emails = new List<string>();
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("email_ids")]
        internal string EmailsRaw
        {
            get
            {
                if(this.Emails == null || this.Emails.Count == 0)
                {
                    return string.Empty;
                }

                var notificationEmailCommaSeperated = new StringBuilder();
                for (var counter = 0; counter < this.Emails.Count; counter++)
                {
                    if (counter == this.Emails.Count - 1)
                    {
                        notificationEmailCommaSeperated.Append(this.Emails[counter]);
                    }
                    else
                    {
                        notificationEmailCommaSeperated.Append(string.Format(CultureInfo.InvariantCulture, "{0},", this.Emails[counter]));
                    }
                }

                return notificationEmailCommaSeperated.ToString();
            }
        }

        [JsonIgnore]
        public List<string> Emails { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        internal string Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                return "Product name is required";
            }

            return string.Empty;
        }
    }
}