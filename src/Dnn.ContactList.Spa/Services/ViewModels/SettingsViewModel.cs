// Copyright (c) DNN Software. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Newtonsoft.Json;

namespace Dnn.ContactList.Spa.Services.ViewModels
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SettingsViewModel
    {
        public SettingsViewModel()
        {
            
        }

        [JsonProperty("isFormEnabled")]
        public bool IsFormEnabled { get; set; }
    }
}
