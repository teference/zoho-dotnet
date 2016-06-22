namespace Teference.Zoho.Api
{
    public interface ISubscriptionApi
    {
        IZsProductApi Products { get; }
        IZsPlanApi Plans { get; }
        IZsAddonApi Addons { get; }
        IZsCouponApi Coupons { get; }
        IZsCustomerApi Customers { get; }
        IZsCardApi Cards { get; }
        IZsContactPersonApi ContactPersons { get; }
        IZsSubscriptionApi Subscriptions { get; }
    }
}