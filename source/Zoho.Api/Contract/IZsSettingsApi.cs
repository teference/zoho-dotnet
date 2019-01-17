namespace Teference.Zoho.Api
{
    #region Namespace

    using System.IO;
    using System.Threading.Tasks;

    #endregion

    public interface IZsSettingsApi
    {
        Task<ZsTaxes> GetAllTaxesAsync();
        Task<ZsTaxes> GetAllTaxesAsync(string apiBaseUrl, string authToken, string organizationId);
    }
}