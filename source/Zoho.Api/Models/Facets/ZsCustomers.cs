namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System.Collections.Generic;

    #endregion

    public sealed class ZsCustomers
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("customers")]
        public List<ZsCustomer> Customers { get; set; }

        [JsonProperty("page_context")]
        public ZsPageContext PageContext { get; set; }
    }
}