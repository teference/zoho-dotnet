namespace Teference.Zoho.Api
{
    #region Namespace

    using System.Threading.Tasks;

    #endregion

    public interface IZsHostedPageApi
    {
        Task<ZsHostedPageDetail> GetAsync(string hostedPageId);
        Task<ZsHostedPageDetail> GetAsync(string authToken, string organizationId, string hostedPageId);

        Task<ZsHostedPages> GetAllAsync();
        Task<ZsHostedPages> GetAllAsync(string authToken, string organizationId);

        Task<ZsHostedPage> UpdateSubscriptionAsync(ZsHostedPageUpdateSubscriptionInput hostedPageUpdateSubscription);
        Task<ZsHostedPage> UpdateSubscriptionAsync(string authToken, string organizationId, ZsHostedPageUpdateSubscriptionInput hostedPageUpdateSubscription);

        Task<ZsHostedPage> UpdateCardAsync(ZsHostedPageUpdateCardInput hostedPageUpdateCard);
        Task<ZsHostedPage> UpdateCardAsync(string authToken, string organizationId, ZsHostedPageUpdateCardInput hostedPageUpdateCard);
    }
}