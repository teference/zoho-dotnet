namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;
    using System;

    #endregion

    public sealed class ZsSubscriptionPayload
    {
        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("data")]
        public ZsSubscriptionData Data { get; set; }

        [JsonProperty("event_time")]
        public DateTime EventTime { get; set; }

        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [JsonProperty("event_time_formatted")]
        public string EventTimeFormatted { get; set; }
    }

    public sealed class ZsSubscriptionData
    {
        [JsonProperty("subscription")]
        public ZsSubscription Subscription { get; set; }
    }
}