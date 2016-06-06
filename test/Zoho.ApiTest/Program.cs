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

//var result3 = await zohoClient.Subscription.Plans.CreateAsync(new ZsPlanCreate
//{
//    Code = "plancode01",
//    Name = "Plan Code 01",
//    RecurringPrice = 30.50,
//    Interval = 1,
//    IntervalUnit = ZsIntervalUnit.Yearly,
//    BillingCycles = 24,
//    TrailPeriod = 120,
//    SetupFee = 12.12,
//    Description = "Plan code description 01",
//    ProductId = "244077000000072123"
//});

//var addonAddResult = await zohoClient.Subscription.Addons.CreateAsync(new ZsAddonCreate
//{
//    Code = "addcode01",
//    Name = "Code Addon Demo 01",
//    UnitName = "testunit",
//    PricingScheme = ZsAddonPricingScheme.Package,
//    PriceBrackets = new List<ZsPriceBracket> { new ZsPriceBracket { Price = 12, StartQuantity = 1, EndQuantity = 5 } },
//    Type = ZsAddonType.Recurring,
//    IntervalUnit = ZsAddonIntervalUnit.Monthly,
//    //IsApplicableToAllPlans = false,
//    //Plans = new List<string> { "Test", },
//    ProductId = "244077000000072123",
//    Description = "Addon code 1 description updated1"
//});

//var productUpdateResult = await zohoClient.Subscription.Products.UpdateAsync("244077000000072123", new Teference.Zoho.Api.ZsProductInput { Name = "Test", Description = "Test descritpion", Emails = new List<string> { "test@test.com", "test1@test.com" }, RedirectUrl = "http://test.com" });