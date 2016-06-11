namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System.Collections.Generic;

    #endregion

    public sealed class ZsContactPersons
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("contactpersons")]
        public List<ZsContactPerson> ContactPerson { get; set; }

        [JsonProperty("page_context")]
        public ZsPageContext PageContext { get; set; }
    }
}