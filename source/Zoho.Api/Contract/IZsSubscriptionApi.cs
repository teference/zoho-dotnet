namespace Teference.Zoho.Api
{
    #region Namespace

    using System;
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

        Task<ZsSubscription> AutoCollectAsync(string id, bool isAutoCollect);
        Task<ZsSubscription> AutoCollectAsync(string authToken, string organizationId, string id, bool isAutoCollect);

        Task<bool> AssociateCouponAsync(string id, string couponCode);
        Task<bool> AssociateCouponAsync(string authToken, string organizationId, string id, string couponCode);

        Task<bool> RemoveCouponAsync(string id);
        Task<bool> RemoveCouponAsync(string authToken, string organizationId, string id);

        Task<ZsInvoice> AddChargeAsync(string id, double amount, string description);
        Task<ZsInvoice> AddChargeAsync(string authToken, string organizationId, string id, double amount, string description);

        Task<ZsSubscription> AddContactPerson(string id, List<string> contactPersons);
        Task<ZsSubscription> AddContactPerson(string authToken, string organizationId, string id, List<string> contactPersons);

        Task<ZsSubscriptionNote> PostponeRenewalAsync(string id, DateTime renewalAt);
        Task<ZsSubscriptionNote> PostponeRenewalAsync(string authToken, string organizationId, string id, DateTime renewalAt);

        Task<ZsSubscriptionNote> AddNoteAsync(string id, string noteDescription);
        Task<ZsSubscriptionNote> AddNoteAsync(string authToken, string organizationId, string id, string noteDescription);

        Task<bool> DeleteNoteAsync(string id, string noteId);
        Task<bool> DeleteNoteAsync(string authToken, string organizationId, string id, string noteId);

        Task<bool> DeleteAsync(string id);
        Task<bool> DeleteAsync(string authToken, string organizationId, string id);

        Task<ZsSubscription> CancelAsync(string id, bool cancelAtEndOfCurrentTerm);
        Task<ZsSubscription> CancelAsync(string authToken, string organizationId, string id, bool cancelAtEndOfCurrentTerm);

        Task<ZsSubscription> ReactivateAsync(string id);
        Task<ZsSubscription> ReactivateAsync(string authToken, string organizationId, string id);

        //Task<bool> DeleteAsync(string id);
        //Task<bool> DeleteAsync(string authToken, string organizationId, string id);

        //Task<bool> ActivateAsync(string id);
        //Task<bool> ActivateAsync(string authToken, string organizationId, string id);

        //Task<bool> DeactivateAsync(string id);
        //Task<bool> DeactivateAsync(string authToken, string organizationId, string id);
    }
}