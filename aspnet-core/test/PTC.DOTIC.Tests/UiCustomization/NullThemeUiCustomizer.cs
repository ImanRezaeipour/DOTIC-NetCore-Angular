﻿using System.Threading.Tasks;
using Abp;
using PTC.DOTIC.Configuration.Dto;
using PTC.DOTIC.UiCustomization;
using PTC.DOTIC.UiCustomization.Dto;

namespace PTC.DOTIC.Tests.UiCustomization
{
    public class NullThemeUiCustomizer : IUiCustomizer
    {
        public async Task<UiCustomizationSettingsDto> GetUiSettings()
        {
            return new UiCustomizationSettingsDto();
        }

        public Task UpdateUserUiManagementSettingsAsync(UserIdentifier user, ThemeSettingsDto settings)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateTenantUiManagementSettingsAsync(int tenantId, ThemeSettingsDto settings)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateApplicationUiManagementSettingsAsync(ThemeSettingsDto settings)
        {
            throw new System.NotImplementedException();
        }

        public Task<ThemeSettingsDto> GetHostUiManagementSettings()
        {
            throw new System.NotImplementedException();
        }

        public Task<ThemeSettingsDto> GetTenantUiCustomizationSettings(int tenantId)
        {
            throw new System.NotImplementedException();
        }
    }
}