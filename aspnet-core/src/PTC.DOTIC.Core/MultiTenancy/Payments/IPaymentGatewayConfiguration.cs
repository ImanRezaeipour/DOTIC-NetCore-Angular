using Abp.Dependency;

namespace PTC.DOTIC.MultiTenancy.Payments
{
    public interface IPaymentGatewayConfiguration: ITransientDependency
    {
        bool IsActive { get; }

        bool SupportsRecurringPayments { get; }

        SubscriptionPaymentGatewayType GatewayType { get; }
    }
}
