namespace Teference.Zoho.Api
{
    #region Namespace

    using System.Threading.Tasks;

    #endregion

    public interface IZsContactPersonApi
    {
        Task<ZsContactPerson> GetAsync(string customerId, string contactPersonId);
        Task<ZsContactPerson> GetAsync(string apiBaseUrl, string authToken, string organizationId, string customerId, string contactPersonId);

        Task<ZsContactPersons> GetAllAsync(string customerId, ZsPage page = null);
        Task<ZsContactPersons> GetAllAsync(string apiBaseUrl, string authToken, string organizationId, string customerId, ZsPage page = null);

        Task<ZsContactPerson> CreateAsync(string customerId, ZsContactPersonInput createInput);
        Task<ZsContactPerson> CreateAsync(string apiBaseUrl, string authToken, string organizationId, string customerId, ZsContactPersonInput createInput);

        Task<ZsContactPerson> UpdateAsync(string customerId, string contactPersonId, ZsContactPersonInput updateInput);
        Task<ZsContactPerson> UpdateAsync(string apiBaseUrl, string authToken, string organizationId, string customerId, string contactPersonId, ZsContactPersonInput updateInput);

        Task<bool> DeleteAsync(string customerId, string contactPersonId);
        Task<bool> DeleteAsync(string apiBaseUrl, string authToken, string organizationId, string customerId, string contactPersonId);
    }
}