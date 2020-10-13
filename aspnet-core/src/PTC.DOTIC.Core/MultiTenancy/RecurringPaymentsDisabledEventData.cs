using Abp.Events.Bus;

namespace PTC.DOTIC.MultiTenancy
{
    public class RecurringPaymentsDisabledEventData : EventData
    {
        public int TenantId { get; set; }

        public int EditionId { get; set; }
    }
}
