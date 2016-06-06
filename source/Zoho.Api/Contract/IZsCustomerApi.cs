namespace Teference.Zoho.Api
{
    #region Namespace

    using System.Threading.Tasks;

    #endregion

    public interface IZsCustomerApi
    {
        Task<ZsCustomer> GetAsync(string id);
        Task<ZsCustomer> GetAsync(string authToken, string organizationId, string id);

        Task<ZsCustomers> GetAllAsync();
        Task<ZsCustomers> GetAllAsync(string authToken, string organizationId);

        Task<ZsCustomer> CreateAsync(ZsCustomerInput createInput);
        Task<ZsCustomer> CreateAsync(string authToken, string organizationId, ZsCustomerInput createInput);

        Task<ZsCustomer> UpdateAsync(string id, ZsCustomerInput updateInput);
        Task<ZsCustomer> UpdateAsync(string authToken, string organizationId, string id, ZsCustomerInput updateInput);

        Task<bool> DeleteAsync(string id);
        Task<bool> DeleteAsync(string authToken, string organizationId, string id);
    }
}