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
        Task<ZsSubscription> GetAsync(string apiBaseUrl, string authToken, string organizationId, string id);

        Task<ZsSubscriptions> GetAllAsync();
        Task<ZsSubscriptions> GetAllAsync(string apiBaseUrl, string authToken, string organizationId);
        Task<ZsSubscriptions> GetAllAsync(ZsSubscriptionFilter filterType, string filterId);
        Task<ZsSubscriptions> GetAllAsync(string apiBaseUrl, string authToken, string organizationId, ZsSubscriptionFilter filterType, string filterId);

        Task<ZsSubscription> CreateAsync(ZsSubscriptionCreate createInput);
        Task<ZsSubscription> CreateAsync(string apiBaseUrl, string authToken, string organizationId, ZsSubscriptionCreate createInput);

        Task<ZsSubscription> UpdateAsync(string id, ZsSubscriptionUpdate updateInput);
        Task<ZsSubscription> UpdateAsync(string apiBaseUrl, string authToken, string organizationId, string id, ZsSubscriptionUpdate updateInput);

        Task<ZsSubscription> AutoCollectAsync(string id, bool isAutoCollect);
        Task<ZsSubscription> AutoCollectAsync(string apiBaseUrl, string authToken, string organizationId, string id, bool isAutoCollect);

        Task<bool> AssociateCouponAsync(string id, string couponCode);
        Task<bool> AssociateCouponAsync(string apiBaseUrl, string authToken, string organizationId, string id, string couponCode);

        Task<bool> RemoveCouponAsync(string id);
        Task<bool> RemoveCouponAsync(string apiBaseUrl, string authToken, string organizationId, string id);

        Task<ZsInvoice> AddChargeAsync(string id, double amount, string description);
        Task<ZsInvoice> AddChargeAsync(string apiBaseUrl, string authToken, string organizationId, string id, double amount, string description);

        Task<ZsSubscription> AddContactPerson(string id, List<string> contactPersons);
        Task<ZsSubscription> AddContactPerson(string apiBaseUrl, string authToken, string organizationId, string id, List<string> contactPersons);

        Task<ZsSubscriptionNote> PostponeRenewalAsync(string id, DateTime renewalAt);
        Task<ZsSubscriptionNote> PostponeRenewalAsync(string apiBaseUrl, string authToken, string organizationId, string id, DateTime renewalAt);

        Task<ZsSubscriptionNote> AddNoteAsync(string id, string noteDescription);
        Task<ZsSubscriptionNote> AddNoteAsync(string apiBaseUrl, string authToken, string organizationId, string id, string noteDescription);

        Task<bool> DeleteNoteAsync(string id, string noteId);
        Task<bool> DeleteNoteAsync(string apiBaseUrl, string authToken, string organizationId, string id, string noteId);

        Task<bool> DeleteAsync(string id);
        Task<bool> DeleteAsync(string apiBaseUrl, string authToken, string organizationId, string id);

        Task<ZsSubscription> CancelAsync(string id, bool cancelAtEndOfCurrentTerm);
        Task<ZsSubscription> CancelAsync(string apiBaseUrl, string authToken, string organizationId, string id, bool cancelAtEndOfCurrentTerm);

        Task<ZsSubscription> ReactivateAsync(string id);
        Task<ZsSubscription> ReactivateAsync(string apiBaseUrl, string authToken, string organizationId, string id);

        //Task<bool> DeleteAsync(string id);
        //Task<bool> DeleteAsync(string authToken, string organizationId, string id);

        //Task<bool> ActivateAsync(string id);
        //Task<bool> ActivateAsync(string authToken, string organizationId, string id);

        //Task<bool> DeactivateAsync(string id);
        //Task<bool> DeactivateAsync(string authToken, string organizationId, string id);
    }
}