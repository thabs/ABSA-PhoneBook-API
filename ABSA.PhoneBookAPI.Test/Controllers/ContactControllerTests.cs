using Microsoft.AspNetCore.Mvc;
using ABSA.PhoneBookAPI.Models;
using ABSA.PhoneBookAPI.Data.Models;
using ABSA.PhoneBookAPI.Controllers;
using ABSA.PhoneBookAPI.Services;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace ABSA.PhoneBookAPI.Test.Controllers
{
    public class ContactControllerTests
    {
        private readonly Mock<IContactService> _contactServiceMock = new Mock<IContactService>();

        private readonly ContactController _instance;

        public ContactControllerTests()
        {
            _instance = new ContactController(_contactServiceMock.Object);
        }

        #region Get All Contacts Test
        // <summary>
        ///     Tests that <see cref="ContactController.GetAllContacts()" /> returns all contacts.
        /// </summary>
        [Fact]
        public async void GetAllContactsTest()
        {
            var expectedContacts = new List<Contact>
            {
                new Contact {
                    Id = 0,
                    Title = "Prof",
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@email.com",
                    MobileNumber = "0123456789"
                },
                new Contact {
                    Id = 1,
                    Title = "Dr",
                    FirstName = "User",
                    LastName = "Two",
                    Email = "user.two@email.com",
                    MobileNumber = "0987654321"
                },
            };

            //! Mock the service
            _contactServiceMock.Setup(_ => _.GetAllContactsAsync()).ReturnsAsync(expectedContacts);
            var response = Assert.IsType<OkObjectResult>(await _instance.GetAllContacts());
            var data = Assert.IsAssignableFrom<List<Contact>>(response.Value);

            Assert.NotNull(data);
            Assert.Equal(2, data.Count);
            Assert.Equal(0, data[0].Id);
            Assert.Equal("Prof", data[0].Title);
            Assert.Equal("John", data[0].FirstName);
            Assert.Equal("Doe", data[0].LastName);
            Assert.Equal("john.doe@email.com", data[0].Email);
            Assert.Equal("0123456789", data[0].MobileNumber);
        }
                
        #endregion
        
        #region Create Contact Test   
        // <summary>
        ///     Tests that <see cref="ContactController.CreateContact(ContactRequest)" /> creates the new contact.
        /// </summary>
        [Fact]
        public async void CreateContactTest()
        {
            var request = new ContactRequest
            {
                Title = "Prof",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                MobileNumber = "0123456789"
            };

            var expectedContact =  new Contact 
            {
                Id = 0,
                Title = "Prof",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                MobileNumber = "0123456789"
            };

            //! Mock the service
            _contactServiceMock.Setup(_ => _.AddContactAsync(It.IsAny<Contact>())).ReturnsAsync(expectedContact);
            var response = Assert.IsType<OkObjectResult>(await _instance.CreateContact(request));
            var data = Assert.IsAssignableFrom<Contact>(response.Value);

            Assert.NotNull(data);
            Assert.Equal(0, data.Id);
            Assert.Equal("Prof", data.Title);
            Assert.Equal("John", data.FirstName);
            Assert.Equal("Doe", data.LastName);
            Assert.Equal("john.doe@email.com", data.Email);
            Assert.Equal("0123456789", data.MobileNumber);
        }
        #endregion

        #region Update Contact Test   
        // <summary>
        ///     Tests that <see cref="ContactController.UpdateContact" /> updates the contact.
        /// </summary>
        [Fact]
        public async void UpdateContactTest()
        {
            var request = new ContactRequest
            {
                Title = "Prof",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                MobileNumber = "0123456789"
            };

            var expectedContact =  new Contact 
            {
                Id = 99,
                Title = "Prof",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                MobileNumber = "0123456789"
            };

            //! Mock the service
            _contactServiceMock.Setup(_ => _.UpdateContactAsync(It.IsAny<Contact>())).ReturnsAsync(expectedContact);
            var response = Assert.IsType<OkObjectResult>(await _instance.UpdateContact(It.IsAny<int>(), request));
            var data = Assert.IsAssignableFrom<Contact>(response.Value);

            Assert.NotNull(data);
            Assert.Equal(99, data.Id);
            Assert.Equal("Prof", data.Title);
            Assert.Equal("John", data.FirstName);
            Assert.Equal("Doe", data.LastName);
            Assert.Equal("john.doe@email.com", data.Email);
            Assert.Equal("0123456789", data.MobileNumber);
        }
        #endregion

        #region Delete Contact Test   
        // <summary>
        ///     Tests that <see cref="ContactController.DeleteContact" /> deletes the contact.
        /// </summary>
        [Fact]
        public async void DeleteContactTest()
        {
            var expectedContact =  new Contact 
            {
                Id = 100,
                Title = "Prof",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                MobileNumber = "0123456789"
            };

            //! Mock the service
            _contactServiceMock.Setup(_ => _.DeleteContactByIdAsync(It.IsAny<int>())).ReturnsAsync(expectedContact);
            var response = Assert.IsType<OkObjectResult>(await _instance.DeleteContact(It.IsAny<int>()));
            var data = Assert.IsAssignableFrom<Contact>(response.Value);

            Assert.NotNull(data);
            Assert.Equal(100, data.Id);
            Assert.Equal("Prof", data.Title);
            Assert.Equal("John", data.FirstName);
            Assert.Equal("Doe", data.LastName);
            Assert.Equal("john.doe@email.com", data.Email);
            Assert.Equal("0123456789", data.MobileNumber);
        }
        #endregion
    }
}