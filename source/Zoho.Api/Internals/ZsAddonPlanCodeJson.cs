namespace Teference.Zoho.Api
{
    using Newtonsoft.Json;

    internal sealed class ZsAddonPlanCodeJson
    {
        [JsonProperty("plan_code")]
        public string PlanCode { get; set; }
    }
}