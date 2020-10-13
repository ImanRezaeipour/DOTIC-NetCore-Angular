using PTC.DOTIC.MultiTenancy.Payments.Stripe;

namespace PTC.DOTIC.Web.Controllers
{
    public class StripeController : StripeControllerBase
    {
        public StripeController(
            StripeGatewayManager stripeGatewayManager,
            StripePaymentGatewayConfiguration stripeConfiguration)
            : base(stripeGatewayManager, stripeConfiguration)
        {
        }
    }
}
