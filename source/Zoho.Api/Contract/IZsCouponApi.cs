namespace Teference.Zoho.Api
{
    #region Namespace

    using System.Threading.Tasks;

    #endregion

    public interface IZsCouponApi
    {
        Task<ZsCoupon> GetAsync(string code);
        Task<ZsCoupon> GetAsync(string authToken, string organizationId, string code);

        Task<ZsCoupons> GetAllAsync();
        Task<ZsCoupons> GetAllAsync(string authToken, string organizationId);

        Task<ZsCoupon> CreateAsync(ZsCouponCreate createInput);
        Task<ZsCoupon> CreateAsync(string authToken, string organizationId, ZsCouponCreate createInput);

        Task<ZsCoupon> UpdateAsync(string code, ZsCouponUpdate updateInput);
        Task<ZsCoupon> UpdateAsync(string authToken, string organizationId, string code, ZsCouponUpdate updateInput);

        Task<bool> DeleteAsync(string code);
        Task<bool> DeleteAsync(string authToken, string organizationId, string code);

        Task<bool> ActivateAsync(string code);
        Task<bool> ActivateAsync(string authToken, string organizationId, string code);

        Task<bool> DeactivateAsync(string code);
        Task<bool> DeactivateAsync(string authToken, string organizationId, string code);
    }
}