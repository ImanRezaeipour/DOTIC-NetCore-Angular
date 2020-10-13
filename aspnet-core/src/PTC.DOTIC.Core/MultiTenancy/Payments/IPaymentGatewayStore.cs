using System.Collections.Generic;

namespace PTC.DOTIC.MultiTenancy.Payments
{
    public interface IPaymentGatewayStore
    {
        List<PaymentGatewayModel> GetActiveGateways();
    }
}
