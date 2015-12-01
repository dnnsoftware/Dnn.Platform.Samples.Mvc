// Copyright (c) DNN Software. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Dnn.ContactList.Spa.Components
{
    public interface ISettingsService
    {
        bool IsFormEnabled(int moduleId, int tabId);

        void SaveFormEnabled(bool isEnabled, int moduleId);
    }
}
