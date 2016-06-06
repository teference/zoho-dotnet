namespace Teference.Zoho.Api
{
    #region Namespace

    using System.Threading.Tasks;

    #endregion

    public interface IZsPlanApi
    {
        Task<ZsPlan> GetAsync(string code);
        Task<ZsPlan> GetAsync(string authToken, string organizationId, string code);

        Task<ZsPlans> GetAllAsync();
        Task<ZsPlans> GetAllAsync(string authToken, string organizationId);

        Task<ZsPlans> GetAllAsync(string productId);
        Task<ZsPlans> GetAllAsync(string authToken, string organizationId, string productId);

        Task<ZsPlan> CreateAsync(ZsPlanCreate createInput);
        Task<ZsPlan> CreateAsync(string authToken, string organizationId, ZsPlanCreate createInput);

        Task<ZsPlan> UpdateAsync(string code, ZsPlanUpdate updateInput);
        Task<ZsPlan> UpdateAsync(string authToken, string organizationId, string code, ZsPlanUpdate updateInput);

        Task<bool> DeleteAsync(string code);
        Task<bool> DeleteAsync(string authToken, string organizationId, string code);

        Task<bool> ActivateAsync(string code);
        Task<bool> ActivateAsync(string authToken, string organizationId, string code);

        Task<bool> DeactivateAsync(string code);
        Task<bool> DeactivateAsync(string authToken, string organizationId, string code);
    }
}