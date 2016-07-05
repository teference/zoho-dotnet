namespace Zoho.ApiTest
{
    using System;
    using System.Threading.Tasks;
    using Teference.Zoho.Api;

    public class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            Task.Run(async () => await program.DoTask());
            Console.ReadLine();
        }

        private async Task DoTask()
        {
            IZohoClient zohoClient =
            new ZohoClient(new ZohoConfig
            {
                AuthToken = Environment.GetEnvironmentVariable("ZohoAuthToken", EnvironmentVariableTarget.User),
                OrganizationId = Environment.GetEnvironmentVariable("ZohoOrgId", EnvironmentVariableTarget.User)
            });

            try
            {
            }
            catch (Exception exception)
            {
            }
        }
    }
}