namespace Teference.Zoho.Api
{
    internal sealed class ZsContactPersonApi : IZsContactPersonApi
    {
        #region Variable declaration

        private IZohoClient client;

        #endregion

        #region Constructor

        public ZsContactPersonApi(IZohoClient client)
        {
            this.client = client;
        }

        #endregion
    }
}