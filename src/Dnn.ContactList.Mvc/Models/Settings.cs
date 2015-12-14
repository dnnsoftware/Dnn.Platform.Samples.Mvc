// Copyright (c) DNN Software. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.ComponentModel;
using Newtonsoft.Json;

namespace Dnn.ContactList.Mvc.Models
{
    /// <summary>
    /// Settings class manages the settings for the module instance.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Settings
    {
        /// <summary>
        /// Settings constructor
        /// </summary>
        public Settings()
        {
            PageSize = 10;
            AllowContactCreation = true;
            
        }

        /// <summary>
        /// Number of contacts to show per page.
        /// </summary>
        [DisplayName("Page Size")]
        [JsonProperty("PageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// Allow users add/edit the contact
        /// </summary>
        [DisplayName("Allow contact creation.")]
        [JsonProperty("AllowContactCreation")]
        public bool AllowContactCreation { get; set; }
    }
}