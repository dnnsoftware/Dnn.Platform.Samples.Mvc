// Copyright (c) DNN Software. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Caching;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Dnn.ContactList.Api
{
    [Serializable]
    [TableName("Contacts")]
    [PrimaryKey("ContactID", "ContactId")]
    [Cacheable("Contacts", CacheItemPriority.Normal, 20)]
    [Scope("PortalId")]
    public class Contact
    {
        public Contact()
        {
            ContactId = -1;
        }

        public int ContactId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Phone]
        public string Phone { get; set; }

        public int PortalId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Twitter { get; set; }
    }
}
