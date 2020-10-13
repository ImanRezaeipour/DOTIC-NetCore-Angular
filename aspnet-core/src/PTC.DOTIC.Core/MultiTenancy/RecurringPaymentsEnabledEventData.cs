using Abp.Events.Bus;

namespace PTC.DOTIC.MultiTenancy
{
    public class RecurringPaymentsEnabledEventData : EventData
    {
        public int TenantId { get; set; }
    }
}