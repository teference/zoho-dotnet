namespace Teference.Zoho.Api
{
    #region Namespace

    using System.Threading.Tasks;

    #endregion

    public interface IZsHostedPageApi
    {
        Task<ZsHostedPageDetail> GetAsync(string hostedPageId);
        Task<ZsHostedPageDetail> GetAsync(string apiBaseUrl, string authToken, string organizationId, string hostedPageId);

        Task<ZsHostedPages> GetAllAsync(ZsPage page = null);
        Task<ZsHostedPages> GetAllAsync(string apiBaseUrl, string authToken, string organizationId, ZsPage page = null);

        Task<ZsHostedPage> CreateSubscriptionAsync(ZsHostedPageCreateSubscriptionInput hostedPageCreateSubscription);
        Task<ZsHostedPage> CreateSubscriptionAsync(string apiBaseUrl, string authToken, string organizationId, ZsHostedPageCreateSubscriptionInput hostedPageCreateSubscription);

        Task<ZsHostedPage> UpdateSubscriptionAsync(ZsHostedPageUpdateSubscriptionInput hostedPageUpdateSubscription);
        Task<ZsHostedPage> UpdateSubscriptionAsync(string apiBaseUrl, string authToken, string organizationId, ZsHostedPageUpdateSubscriptionInput hostedPageUpdateSubscription);

        Task<ZsHostedPage> UpdateCardAsync(ZsHostedPageUpdateCardInput hostedPageUpdateCard);
        Task<ZsHostedPage> UpdateCardAsync(string apiBaseUrl, string authToken, string organizationId, ZsHostedPageUpdateCardInput hostedPageUpdateCard);

        Task<ZsHostedPage> BuyOneTimeAddonAsync(ZsHostedPageBuyAddonInput hostedPageBuyAddon);
        Task<ZsHostedPage> BuyOneTimeAddonAsync(string apiBaseUrl, string authToken, string organizationId, ZsHostedPageBuyAddonInput hostedPageBuyAddon);
    }
}