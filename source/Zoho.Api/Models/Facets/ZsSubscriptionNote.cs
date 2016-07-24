namespace Teference.Zoho.Api
{
    #region Namespace

    using System;
    using Newtonsoft.Json;

    #endregion

    public class ZsSubscriptionNote
    {
        [JsonProperty("note_id")]
        public string NoteId { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("commented_by")]
        public string CommentedBy { get; set; }
        [JsonProperty("commented_time")]
        public DateTime CommentedTime { get; set; }
    }
}