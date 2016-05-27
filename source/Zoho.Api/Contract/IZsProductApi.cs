namespace Teference.Zoho.Api
{
    #region Namespace

    using System.Threading.Tasks;
    using Models;
    using System.Collections.Generic;

    #endregion

    public interface IZsProductApi
    {
        Task<ZsProduct> GetAsync(string id);
        Task<ZsProduct> GetAsync(string authToken, string organizationId, string id);

        Task<ZsProducts> GetAllAsync();
        Task<ZsProducts> GetAllAsync(string authToken, string organizationId);

        Task<ZsProduct> CreateAsync(string name, string description = "", IEnumerable<string> notificationEmails = null, string redirectUrl = null);
        Task<ZsProduct> CreateAsync(string authToken, string organizationId, string name, string description = "", IEnumerable<string> notificationEmails = null, string redirectUrl = null);

        Task<ZsProduct> UpdateAsync(string id, string name, string description = "", IEnumerable<string> notificationEmails = null, string redirectUrl = null);
        Task<ZsProduct> UpdateAsync(string authToken, string organizationId, string id, string name, string description = "", IEnumerable<string> notificationEmails = null, string redirectUrl = null);

        Task<bool> DeleteAsync(string id);
        Task<bool> DeleteAsync(string authToken, string organizationId, string id);

        Task<bool> ActivateAsync(string id);
        Task<bool> ActivateAsync(string authToken, string organizationId, string id);

        Task<bool> DeactivateAsync(string id);
        Task<bool> DeactivateAsync(string authToken, string organizationId, string id);
    }
}