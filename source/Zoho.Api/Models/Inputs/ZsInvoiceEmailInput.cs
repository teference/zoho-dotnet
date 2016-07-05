namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System.Collections.Generic;

    #endregion

    public sealed class ZsInvoiceEmailInput
    {
        public ZsInvoiceEmailInput()
        {
            this.RecipientMailIdList = new List<string>();
            // this.CcMailIdList = new List<string>();
        }

        [JsonRequired]
        [JsonProperty("from_mail_id")]
        public string FromMailId { get; set; }

        [JsonRequired]
        [JsonProperty("to_mail_ids")]
        public List<string> RecipientMailIdList { get; set; }

        [JsonRequired]
        [JsonProperty("cc_mail_ids")]
        public List<string> CcMailIdList { get; set; }

        [JsonRequired]
        [JsonProperty("subject")]
        public string EmailSubject { get; set; }

        [JsonRequired]
        [JsonProperty("body")]
        public string EmailBody { get; set; }

        internal string Validate()
        {
            if (string.IsNullOrWhiteSpace(this.FromMailId))
            {
                return "From email address is required.";
            }

            if (string.IsNullOrWhiteSpace(this.EmailSubject))
            {
                return "Email subject is required.";
            }

            if (string.IsNullOrWhiteSpace(this.EmailBody))
            {
                return "Email body is required.";
            }

            if (null == this.RecipientMailIdList || this.RecipientMailIdList.Count == 0)
            {
                return "Recipient email address list is required.";
            }

            //if (null == this.CcMailIdList || this.CcMailIdList.Count == 0)
            //{
            //    return "CC email address list is required.";
            //}

            return string.Empty;
        }
    }
}