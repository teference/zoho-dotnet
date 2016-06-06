namespace Teference.Zoho.Api
{
    #region Namespace

    using System.Threading.Tasks;

    #endregion

    public interface IZsPlanApi
    {
        Task<ZsPlans> GetAllAsync();
        Task<ZsPlans> GetAllAsync(string authToken, string organizationId);
    }
}