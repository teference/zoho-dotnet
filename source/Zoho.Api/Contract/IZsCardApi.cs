namespace Teference.Zoho.Api
{
    #region Namespace

    using System.Threading.Tasks;

    #endregion

    public interface IZsCardApi
    {
        Task<ZsCard> GetAsync(string customerId, string cardId);
        Task<ZsCard> GetAsync(string authToken, string organizationId, string customerId, string cardId);

        Task<ZsCard> CreateAsync(string customerId, ZsCardCreate createInput);
        Task<ZsCard> CreateAsync(string authToken, string organizationId, string customerId, ZsCardCreate createInput);

        Task<ZsCard> UpdateAsync(string customerId, string cardId, ZsCardUpdate updateInput);
        Task<ZsCard> UpdateAsync(string authToken, string organizationId, string customerId, string cardId, ZsCardUpdate updateInput);

        Task<bool> DeleteAsync(string customerId, string cardId);
        Task<bool> DeleteAsync(string authToken, string organizationId, string customerId, string cardId);
    }
}