namespace Teference.Zoho.Api
{
    #region Namespace

    using System.IO;
    using System.Threading.Tasks;

    #endregion

    public interface IZsInvoiceApi
    {
        Task<ZsInvoice> GetAsync(string id);
        Task<ZsInvoice> GetAsync(string authToken, string organizationId, string id);

        Task<ZsInvoices> GetAllAsync();
        Task<ZsInvoices> GetAllAsync(string authToken, string organizationId);

        Task<ZsInvoices> GetAllAsync(ZsInvoiceFilter filterType, string filterId);
        Task<ZsInvoices> GetAllAsync(string authToken, string organizationId, ZsInvoiceFilter filterType, string filterId);

        Task<ZsInvoice> CollectCharge(string id);
        Task<ZsInvoice> CollectCharge(string authToken, string organizationId, string id);

        Task<bool> ConvertToVoid(string id);
        Task<bool> ConvertToVoid(string authToken, string organizationId, string id);

        Task<bool> ConvertToOpen(string id);
        Task<bool> ConvertToOpen(string authToken, string organizationId, string id);

        Task<bool> EmailInvoice(string id, ZsInvoiceEmailInput emailInput);
        Task<bool> EmailInvoice(string authToken, string organizationId, string id, ZsInvoiceEmailInput emailInput);

        Task<bool> WriteOff(string id);
        Task<bool> WriteOff(string authToken, string organizationId, string id);

        Task<bool> CancelWriteOff(string id);
        Task<bool> CancelWriteOff(string authToken, string organizationId, string id);

        Task<Stream> GetPdfAsync(string id);
        Task<Stream> GetPdfAsync(string authToken, string organizationId, string id);
    }
}