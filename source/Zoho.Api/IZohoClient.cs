namespace Teference.Zoho.Api
{
    public interface IZohoClient
    {
        #region Properties

        ZohoConfig Configuration { get; set; }

        IZsProductApi ZsProductApi { get; }
        IZsPlanApi ZsPlanApi { get; }

        #endregion
    }
}