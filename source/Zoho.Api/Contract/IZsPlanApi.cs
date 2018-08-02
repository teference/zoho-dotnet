namespace Teference.Zoho.Api
{
    #region Namespace

    using System.Threading.Tasks;

    #endregion

    public interface IZsPlanApi
    {
        Task<ZsPlan> GetAsync(string code);
        Task<ZsPlan> GetAsync(string apiBaseUrl, string authToken, string organizationId, string code);

        Task<ZsPlans> GetAllAsync(ZsPage page = null);
        Task<ZsPlans> GetAllAsync(string apiBaseUrl, string authToken, string organizationId, ZsPage page = null);

        Task<ZsPlans> GetAllAsync(string productId, ZsPage page = null);
        Task<ZsPlans> GetAllAsync(string apiBaseUrl, string authToken, string organizationId, string productId, ZsPage page = null);

        Task<ZsPlan> CreateAsync(ZsPlanCreate createInput);
        Task<ZsPlan> CreateAsync(string apiBaseUrl, string authToken, string organizationId, ZsPlanCreate createInput);

        Task<ZsPlan> UpdateAsync(string code, ZsPlanUpdate updateInput);
        Task<ZsPlan> UpdateAsync(string apiBaseUrl, string authToken, string organizationId, string code, ZsPlanUpdate updateInput);

        Task<bool> DeleteAsync(string code);
        Task<bool> DeleteAsync(string apiBaseUrl, string authToken, string organizationId, string code);

        Task<bool> ActivateAsync(string code);
        Task<bool> ActivateAsync(string apiBaseUrl, string authToken, string organizationId, string code);

        Task<bool> DeactivateAsync(string code);
        Task<bool> DeactivateAsync(string apiBaseUrl, string authToken, string organizationId, string code);
    }
}