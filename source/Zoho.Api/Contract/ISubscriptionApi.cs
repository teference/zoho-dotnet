namespace Teference.Zoho.Api
{
    public interface ISubscriptionApi
    {
        IZsProductApi Products { get; }
        IZsPlanApi Plans { get; }
        IZsAddonApi Addons { get; }
    }
}