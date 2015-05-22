// Copyright (c) DNN Software. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
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

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public int PortalId { get; set; }

        public string Twitter { get; set; }
    }
}
