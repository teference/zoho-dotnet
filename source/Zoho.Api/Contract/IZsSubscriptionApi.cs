namespace Teference.Zoho.Api
{
    #region Namespace

    using System.Threading.Tasks;

    #endregion

    public interface IZsSubscriptionApi
    {
        Task<ZsSubscription> GetAsync(string id);
        Task<ZsSubscription> GetAsync(string authToken, string organizationId, string id);

        Task<ZsSubscriptions> GetAllAsync();
        Task<ZsSubscriptions> GetAllAsync(string authToken, string organizationId);

        Task<ZsSubscription> CreateAsync(ZsSubscriptionCreate createInput);
        Task<ZsSubscription> CreateAsync(string authToken, string organizationId, ZsSubscriptionCreate createInput);

        Task<ZsSubscription> UpdateAsync(string id, ZsSubscriptionUpdate updateInput);
        Task<ZsSubscription> UpdateAsync(string authToken, string organizationId, string id, ZsSubscriptionUpdate updateInput);

        //Task<bool> DeleteAsync(string id);
        //Task<bool> DeleteAsync(string authToken, string organizationId, string id);

        //Task<bool> ActivateAsync(string id);
        //Task<bool> ActivateAsync(string authToken, string organizationId, string id);

        //Task<bool> DeactivateAsync(string id);
        //Task<bool> DeactivateAsync(string authToken, string organizationId, string id);
    }
}