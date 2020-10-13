using System;
using System.Threading.Tasks;
using Abp;
using Abp.Localization;
using Abp.Notifications;
using PTC.DOTIC.Authorization.Users;
using PTC.DOTIC.MultiTenancy;

namespace PTC.DOTIC.Notifications
{
    public class AppNotifier : DOTICDomainServiceBase, IAppNotifier
    {
        private readonly INotificationPublisher _notificationPublisher;

        public AppNotifier(INotificationPublisher notificationPublisher)
        {
            _notificationPublisher = notificationPublisher;
        }

        public async Task WelcomeToTheApplicationAsync(User user)
        {
            await _notificationPublisher.PublishAsync(
                AppNotificationNames.WelcomeToTheApplication,
                new MessageNotificationData(L("WelcomeToTheApplicationNotificationMessage")),
                severity: NotificationSeverity.Success,
                userIds: new[] { user.ToUserIdentifier() }
                );
        }

        public async Task NewUserRegisteredAsync(User user)
        {
            var notificationData = new LocalizableMessageNotificationData(
                new LocalizableString(
                    "NewUserRegisteredNotificationMessage",
                    DOTICConsts.LocalizationSourceName
                    )
                );

            notificationData["userName"] = user.UserName;
            notificationData["emailAddress"] = user.EmailAddress;

            await _notificationPublisher.PublishAsync(AppNotificationNames.NewUserRegistered, notificationData, tenantIds: new[] { user.TenantId });
        }

        public async Task NewTenantRegisteredAsync(Tenant tenant)
        {
            var notificationData = new LocalizableMessageNotificationData(
                new LocalizableString(
                    "NewTenantRegisteredNotificationMessage",
                    DOTICConsts.LocalizationSourceName
                    )
                );

            notificationData["tenancyName"] = tenant.TenancyName;
            await _notificationPublisher.PublishAsync(AppNotificationNames.NewTenantRegistered, notificationData);
        }

        public async Task GdprDataPrepared(UserIdentifier user, Guid binaryObjectId)
        {
            var notificationData = new LocalizableMessageNotificationData(
                new LocalizableString(
                    "GdprDataPreparedNotificationMessage",
                    DOTICConsts.LocalizationSourceName
                )
            );

            notificationData["binaryObjectId"] = binaryObjectId;

            await _notificationPublisher.PublishAsync(AppNotificationNames.GdprDataPrepared, notificationData, userIds: new[] { user });
        }

        //This is for test purposes
        public async Task SendMessageAsync(UserIdentifier user, string message, NotificationSeverity severity = NotificationSeverity.Info)
        {
            await _notificationPublisher.PublishAsync(
                "App.SimpleMessage",
                new MessageNotificationData(message),
                severity: severity,
                userIds: new[] { user }
                );
        }

        public async Task TenantsMovedToEdition(UserIdentifier user, string sourceEditionName, string targetEditionName)
        {
            var notificationData = new LocalizableMessageNotificationData(
                new LocalizableString(
                    "TenantsMovedToEditionNotificationMessage",
                    DOTICConsts.LocalizationSourceName
                )
            );

            notificationData["sourceEditionName"] = sourceEditionName;
            notificationData["targetEditionName"] = targetEditionName;

            await _notificationPublisher.PublishAsync(AppNotificationNames.TenantsMovedToEdition, notificationData, userIds: new[] { user });
        }

        public Task<TResult> TenantsMovedToEdition<TResult>(UserIdentifier argsUser, int sourceEditionId, int targetEditionId)
        {
            throw new NotImplementedException();
        }
    }
}