namespace Teference.Zoho.Api
{
    #region Namespace

    using Newtonsoft.Json;

    #endregion

    public sealed class ZsPlanCreate : ZsPlanUpdate
    {
        [JsonProperty("plan_code")]
        public string Code { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        internal new string Validate()
        {
            var baseValidationResult = base.Validate();
            if (!string.IsNullOrWhiteSpace(baseValidationResult))
            {
                return baseValidationResult;
            }

            if (string.IsNullOrWhiteSpace(this.Code))
            {
                return "Plan code is required.";
            }

            if (string.IsNullOrWhiteSpace(this.ProductId))
            {
                return "Product Id is required.";
            }

            return string.Empty;
        }
    }
}
