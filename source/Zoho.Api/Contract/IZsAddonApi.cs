namespace Teference.Zoho.Api
{
    #region Namespace

    using System.Threading.Tasks;

    #endregion

    public interface IZsAddonApi
    {
        Task<ZsAddon> GetAsync(string code);
        Task<ZsAddon> GetAsync(string authToken, string organizationId, string code);

        Task<ZsAddons> GetAllAsync();
        Task<ZsAddons> GetAllAsync(string authToken, string organizationId);

        Task<ZsAddon> CreateAsync(ZsAddonCreate createInput);
        Task<ZsAddon> CreateAsync(string authToken, string organizationId, ZsAddonCreate createInput);

        Task<ZsAddon> UpdateAsync(string code, ZsAddonUpdate updateInput);
        Task<ZsAddon> UpdateAsync(string authToken, string organizationId, string code, ZsAddonUpdate updateInput);

        Task<bool> DeleteAsync(string code);
        Task<bool> DeleteAsync(string authToken, string organizationId, string code);

        Task<bool> ActivateAsync(string code);
        Task<bool> ActivateAsync(string authToken, string organizationId, string code);

        Task<bool> DeactivateAsync(string code);
        Task<bool> DeactivateAsync(string authToken, string organizationId, string code);
    }
}