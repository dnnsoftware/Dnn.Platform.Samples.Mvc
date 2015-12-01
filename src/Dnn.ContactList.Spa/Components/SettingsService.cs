// Copyright (c) DNN Software. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework;

namespace Dnn.ContactList.Spa.Components
{
    public class SettingsService : ServiceLocator<ISettingsService, SettingsService>, ISettingsService
    {
        private readonly IModuleController _moduleController;
        private const string IsFormEnabledKey = "IsFormEnabledKey";

        public SettingsService()
        {
            _moduleController = ModuleController.Instance;
        }
        protected override Func<ISettingsService> GetFactory()
        {
            return () => new SettingsService();
        }

        public bool IsFormEnabled(int moduleId, int tabId)
        {
            var module = _moduleController.GetModule(moduleId, tabId, true);
            var moduleSettings = module.ModuleSettings;

            return moduleSettings[IsFormEnabledKey] != null && Boolean.Parse((string) moduleSettings[IsFormEnabledKey]);
        }

        public void SaveFormEnabled(bool isEnabled, int moduleId)
        {
            _moduleController.UpdateModuleSetting(moduleId, IsFormEnabledKey, isEnabled.ToString());
        }
    }
}