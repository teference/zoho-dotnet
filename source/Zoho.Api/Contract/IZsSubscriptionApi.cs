namespace Teference.Zoho.Api
{
    #region Namespace

    using System.Collections.Generic;
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

        Task<ZsSubscription> AddContactPerson(string id, List<string> contactPersons);
        Task<ZsSubscription> AddContactPerson(string authToken, string organizationId, string id, List<string> contactPersons);

        Task<ZsSubscription> AutoCollectAsync(string id, bool isAutoCollect);
        Task<ZsSubscription> AutoCollectAsync(string authToken, string organizationId, string id, bool isAutoCollect);

        Task<bool> AssociateCouponAsync(string id, string couponCode);
        Task<bool> AssociateCouponAsync(string authToken, string organizationId, string id, string couponCode);

        Task<bool> RemoveCouponAsync(string id);
        Task<bool> RemoveCouponAsync(string authToken, string organizationId, string id);

        Task<ZsSubscriptionNote> AddNoteAsync(string id, string noteDescription);
        Task<ZsSubscriptionNote> AddNoteAsync(string authToken, string organizationId, string id, string noteDescription);

        Task<bool> DeleteNoteAsync(string id, string noteId);
        Task<bool> DeleteNoteAsync(string authToken, string organizationId, string id, string noteId);

        //Task<bool> DeleteAsync(string id);
        //Task<bool> DeleteAsync(string authToken, string organizationId, string id);

        //Task<bool> ActivateAsync(string id);
        //Task<bool> ActivateAsync(string authToken, string organizationId, string id);

        //Task<bool> DeactivateAsync(string id);
        //Task<bool> DeactivateAsync(string authToken, string organizationId, string id);
    }
}