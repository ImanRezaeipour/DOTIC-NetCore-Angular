using System.Threading.Tasks;
using Abp.Application.Services;
using PTC.DOTIC.MultiTenancy.Payments.Dto;
using PTC.DOTIC.MultiTenancy.Payments.PayPal.Dto;

namespace PTC.DOTIC.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalPaymentId, string paypalPayerId);

        PayPalConfigurationDto GetConfiguration();

        Task CancelPayment(CancelPaymentDto input);
    }
}
