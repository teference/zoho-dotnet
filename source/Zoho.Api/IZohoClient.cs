namespace Teference.Zoho.Api
{
    public interface IZohoClient
    {
        #region Properties

        ZohoConfig Configuration { get; set; }

        ISubscriptionApi Subscription { get; }

        #endregion
    }
}