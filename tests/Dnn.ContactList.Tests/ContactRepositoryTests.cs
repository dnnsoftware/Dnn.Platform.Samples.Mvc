// Copyright (c) DNN Software. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Dnn.ContactList.Api;
using DotNetNuke.ComponentModel;
using DotNetNuke.Data;
using Moq;
using NUnit.Framework;
// ReSharper disable UnusedVariable

// ReSharper disable InconsistentNaming

namespace Dnn.ContactList.Tests
{
    [TestFixture]
    public class ContactRepositoryTests
    {
        private const int PORTAL_InValidId = -1;
        private const int PORTAL_ValidId = 2;

        private const int CONTACT_InValidId = -1;
        private const int CONTACT_ValidId = 3;

        private string[] CONTACT_FirstNames = { "John", "Jane", "William", "Tom", "Robert"} ;
        private string[] CONTACT_LastNames = { "Smith", "Jones", "Thomas", "Evans", "Bloggs" };

        private Mock<IDataContext> _mockDataContext;
        private Mock<IRepository<Contact>> _mockRepository;

        [SetUp]
        public void SetUp()
        {
            _mockDataContext = new Mock<IDataContext>();

            _mockRepository = new Mock<IRepository<Contact>>();
            _mockDataContext.Setup(dc => dc.GetRepository<Contact>()).Returns(_mockRepository.Object);
            ComponentFactory.RegisterComponentInstance<IDataContext>(_mockDataContext.Object);
        }

        [TearDown]
        public void TearDown()
        {
            ComponentFactory.Container = new SimpleContainer();
        }

        [Test]
        public void AddContact_Throws_On_Null_Contact()
        {
            //Arrange
            var repository = new ContactRepository();

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => repository.AddContact(null));
        }

        [Test]
        public void AddContact_Throws_On_InValid_PortalId()
        {
            //Arrange
            var repository = new ContactRepository();
            var contact = new Contact { PortalId = PORTAL_InValidId };

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => repository.AddContact(contact));
        }

        [Test]
        public void AddContact_Calls_IRepository_Insert_On_Valid_Contact()
        {
            //Arrange
            var portalId = PORTAL_ValidId;

            var repository = new ContactRepository();
            var contact = new Contact { PortalId = portalId };

            //Act
            repository.AddContact(contact);

            //Assert
            _mockRepository.Verify(r => r.Insert(contact));
        }

        [Test]
        public void AddContact_Returns_ValidId_On_Valid_Contact()
        {
            //Arrange
            var portalId = PORTAL_ValidId;
            _mockRepository.Setup(r => r.Insert(It.IsAny<Contact>()))
                            .Callback((Contact ct) => ct.ContactId = CONTACT_ValidId);

            var repository = new ContactRepository();
            var contact = new Contact { PortalId = portalId };

            //Act
            int contactId = repository.AddContact(contact);

            //Assert
            Assert.AreEqual(CONTACT_ValidId, contactId);
        }

        [Test]
        public void AddContact_Sets_ValidId_On_Valid_Contact()
        {
            //Arrange
            var portalId = PORTAL_ValidId;
            _mockRepository.Setup(r => r.Insert(It.IsAny<Contact>()))
                            .Callback((Contact ct) => ct.ContactId = CONTACT_ValidId);

            var repository = new ContactRepository();
            var contact = new Contact { PortalId = portalId };

            //Act
            int contactId = repository.AddContact(contact);

            //Assert
            Assert.AreEqual(CONTACT_ValidId, contact.ContactId);
        }

        [Test]
        public void DeleteContact_Throws_On_Null_Contact()
        {
            //Arrange
            var repository = new ContactRepository();

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => repository.DeleteContact(null));
        }

        [Test]
        public void DeleteContact_Throws_On_InValid_ContactId()
        {
            //Arrange
            var repository = new ContactRepository();
            var contact = new Contact { ContactId = CONTACT_InValidId };

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => repository.DeleteContact(contact));
        }

        [Test]
        public void DeleteContact_Calls_IRepository_Delete_On_Valid_Contact()
        {
            //Arrange
            var portalId = PORTAL_ValidId;

            var repository = new ContactRepository();
            var contact = new Contact { PortalId = portalId };

            //Act
            repository.DeleteContact(contact);

            //Assert
            _mockRepository.Verify(r => r.Delete(contact));
        }

        [Test]
        public void GetContact_Throws_On_InValid_ContactId()
        {
            //Arrange
            var repository = new ContactRepository();

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => repository.GetContact(CONTACT_InValidId, PORTAL_ValidId));
        }

        [Test]
        public void GetContact_Throws_On_InValid_PortalId()
        {
            //Arrange
            var repository = new ContactRepository();

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => repository.GetContact(CONTACT_ValidId, PORTAL_InValidId));
        }

        [Test]
        public void GetContact_Calls_IRepository_Get_On_Valid_Parameters()
        {
            //Arrange
            var portalId = PORTAL_ValidId;
            var contactId = CONTACT_ValidId;

            var repository = new ContactRepository();

            //Act
            var coontact = repository.GetContact(contactId, portalId);

            //Assert
            _mockRepository.Verify(r => r.Get(portalId));
        }

        [Test]
        public void GetContact_Returns_Contact_On_Valid_Parameters()
        {
            //Arrange
            var portalId = PORTAL_ValidId;
            var contactId = CONTACT_ValidId;

            _mockRepository.Setup(r => r.Get(portalId)).Returns(new List<Contact>()
            {
                new Contact() { ContactId = contactId},
                new Contact() {ContactId = 5 },
                new Contact() {ContactId = 15 },
                new Contact() {ContactId = 10 },
            });

            var repository = new ContactRepository();

            //Act
            var contact = repository.GetContact(contactId, portalId);

            //Assert
            Assert.IsInstanceOf<Contact>(contact);
            Assert.AreEqual(contactId, contact.ContactId);
        }

        [Test]
        public void GetContacts_Throws_On_InValid_PortalId()
        {
            //Arrange
            var repository = new ContactRepository();

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => repository.GetContacts(PORTAL_InValidId));
        }

        [Test]
        public void GetContacts_Calls_IRepository_Get_On_Valid_Parameter()
        {
            //Arrange
            var portalId = PORTAL_ValidId;

            var repository = new ContactRepository();

            //Act
            var coontact = repository.GetContacts(portalId);

            //Assert
            _mockRepository.Verify(r => r.Get(portalId));
        }

        [Test]
        public void GetContacts_Returns_Empty_List_Of_Contacts_If_No_Contacts()
        {
            //Arrange
            var portalId = PORTAL_ValidId;
;
            _mockRepository.Setup(r => r.Get(portalId))
                .Returns(GetContacts(0));
            var repository = new ContactRepository();

            //Act
            var contacts = repository.GetContacts(portalId);

            //Assert
            Assert.IsNotNull(contacts);
            Assert.AreEqual(0, contacts.Count());
        }

        [Test]
        public void GetContacts_Returns_List_Of_Contacts()
        {
            //Arrange
            var portalId = PORTAL_ValidId;
            var recordCount = 5;
            _mockRepository.Setup(r => r.Get(portalId))
                .Returns(GetContacts(recordCount));
            var repository = new ContactRepository();

            //Act
            var contacts = repository.GetContacts(portalId);

            //Assert
            Assert.AreEqual(recordCount, contacts.Count());
        }

        [Test]
        public void GetContacts_Overload_Throws_On_InValid_PortalId()
        {
            //Arrange
            var repository = new ContactRepository();

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => repository.GetContacts("", PORTAL_InValidId, 0, 5));
        }

        [Test]
        public void GetContacts_Overload_Calls_IRepository_Get_On_Valid_Parameter()
        {
            //Arrange
            var portalId = PORTAL_ValidId;

            var repository = new ContactRepository();

            //Act
            var coontact = repository.GetContacts("", portalId, 0, 5);

            //Assert
            _mockRepository.Verify(r => r.Get(portalId));
        }

        [Test]
        public void UpdateContact_Throws_On_Null_Contact()
        {
            //Arrange
            var repository = new ContactRepository();

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => repository.UpdateContact(null));
        }

        [Test]
        public void UpdateContact_Throws_On_InValid_ContactId()
        {
            //Arrange
            var repository = new ContactRepository();
            var contact = new Contact { ContactId = CONTACT_InValidId };

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => repository.UpdateContact(contact));
        }

        [Test]
        public void UpdateContact_Calls_IRepository_Update_On_Valid_Contact()
        {
            //Arrange
            var portalId = PORTAL_ValidId;

            var repository = new ContactRepository();
            var contact = new Contact { PortalId = portalId };

            //Act
            repository.UpdateContact(contact);

            //Assert
            _mockRepository.Verify(r => r.Update(contact));
        }

        private List<Contact> GetContacts(int count)
        {
            var list = new List<Contact>();

            for (int i = 1; i <= count; i++)
            {
                var index = i;
                while (index >= 5)
                {
                    index = index - 5;
                }

                list.Add(new Contact()
                                {
                                    ContactId = i,
                                    FirstName = CONTACT_FirstNames[index],
                                    LastName = CONTACT_LastNames[index],
                                });
            }

            return list;
        }
    }
}
