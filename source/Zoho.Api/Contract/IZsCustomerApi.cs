namespace Teference.Zoho.Api
{
    #region Namespace

    using System.Threading.Tasks;

    #endregion

    public interface IZsCustomerApi
    {
        Task<ZsCustomer> GetAsync(string id);
        Task<ZsCustomer> GetAsync(string apiBaseUrl, string authToken, string organizationId, string id);

        Task<ZsCustomers> GetAllAsync(QueryStringBuilder queryStringBuilder = null);
        Task<ZsCustomers> GetAllAsync(string apiBaseUrl, string authToken, string organizationId, QueryStringBuilder queryStringBuilder = null);

        Task<ZsCustomer> CreateAsync(ZsCustomerInput createInput);
        Task<ZsCustomer> CreateAsync(string apiBaseUrl, string authToken, string organizationId, ZsCustomerInput createInput);

        Task<ZsCustomer> UpdateAsync(string id, ZsCustomerInput updateInput);
        Task<ZsCustomer> UpdateAsync(string apiBaseUrl, string authToken, string organizationId, string id, ZsCustomerInput updateInput);

        Task<bool> DeleteAsync(string id);
        Task<bool> DeleteAsync(string apiBaseUrl, string authToken, string organizationId, string id);
    }
}