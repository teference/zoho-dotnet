namespace Teference.Zoho.Api
{
    #region Namespace

    using System.Threading.Tasks;

    #endregion

    public interface IZsProductApi
    {
        Task<ZsProduct> GetAsync(string id);
        Task<ZsProduct> GetAsync(string apiBaseUrl, string authToken, string organizationId, string id);

        Task<ZsProducts> GetAllAsync(ZsPage page = null);
        Task<ZsProducts> GetAllAsync(string apiBaseUrl, string authToken, string organizationId, ZsPage page = null);

        Task<ZsProduct> CreateAsync(ZsProductInput createInput);
        Task<ZsProduct> CreateAsync(string apiBaseUrl, string authToken, string organizationId, ZsProductInput createInput);

        Task<ZsProduct> UpdateAsync(string id, ZsProductInput updateInput);
        Task<ZsProduct> UpdateAsync(string apiBaseUrl, string authToken, string organizationId, string id, ZsProductInput updateInput);

        Task<bool> DeleteAsync(string id);
        Task<bool> DeleteAsync(string apiBaseUrl, string authToken, string organizationId, string id);

        Task<bool> ActivateAsync(string id);
        Task<bool> ActivateAsync(string apiBaseUrl, string authToken, string organizationId, string id);

        Task<bool> DeactivateAsync(string id);
        Task<bool> DeactivateAsync(string apiBaseUrl, string authToken, string organizationId, string id);
    }
}