namespace Teference.Zoho.Api.Models
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    public sealed class ZsPageContext
    {
        [JsonProperty("page")]
        public int PageNumber { get; set; }
        [JsonProperty("per_page")]
        public int RecordsPerPage { get; set; }
        [JsonProperty("has_more_page")]
        public bool HasMoreRecords { get; set; }
        [JsonProperty("applied_filter")]
        public string FilteredOn { get; set; }
        [JsonProperty("sort_column")]
        public string SortColumn { get; set; }
        [JsonProperty("sort_order")]
        public string SortOrder { get; set; }
    }
}
