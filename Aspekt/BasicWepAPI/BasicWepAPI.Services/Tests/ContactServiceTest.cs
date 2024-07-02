using BasicWepAPI.Core.Models;
using BasicWepAPI.Core.Repositories;
using BasicWepAPI.Core.Services;
using BasicWepAPI.Services.DTOs.CompanyDtos;
using BasicWepAPI.Services.DTOs.ContactDtos;
using BasicWepAPI.Services.Helper.CustomExceptions;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Services.Tests
{
    [TestClass]
    public class ContactServiceTest
    {
        private Mock<IContactRepository> _mockContactRepository;
        private ContactService _contactService;
        [TestInitialize]
        public void Setup()
        {
            _mockContactRepository = new Mock<IContactRepository>();
            _contactService = new ContactService(_mockContactRepository.Object);
        }

        [TestMethod]
        public void GetAllContact_Returns_AllContacts()
        {
            // Arrange
            _mockContactRepository.Setup(repo => repo.GetAll()).Returns(new List<Contact>
        {
            new Contact { Id = 1, ContactName = "Aspekt",CompanyId = 1,CountryId = 1},
            new Contact { Id = 2, ContactName = "Samsung", CompanyId = 2,CountryId =2 },
        });

            // Act
            var result = _contactService.GetAllContact();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }


        [TestMethod]
        public void CreateContact_Throws_ValidationException_OnInvalidData()
        {
            // Arrange

            var invalidCompanyDto = new ContactDto
            {
                ContactName = "",
                CompanyId = 1,
                CountryId = 1,
            };

            // Act & Assert
            var ex = Assert.ThrowsException<ValidationException>(() => _contactService.CreateContact(invalidCompanyDto));
        }

        [TestMethod]
        public void GetContactById_Returns_ContactDto_WhenContactExists()
        {
            // Arrange
            int contactId = 1;
            _mockContactRepository.Setup(repo => repo.GetById(contactId)).Returns(new Contact { Id = contactId, CompanyId = 1, ContactName = "ContactName", CountryId = 1 });

            // Act
            var result = _contactService.GetContactById(contactId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(contactId, result.Id);
            Assert.AreEqual("ContactName", result.ContactName);
        }

        [TestMethod]
        public void DeleteContact_Throws_DataNotFoundException_WhenContactDoesNotExist()
        {
            // Arrange
            int contactId = 1;
            _mockContactRepository.Setup(repo => repo.GetById(contactId)).Returns(new Contact { Id = contactId, ContactName = "ContactName", CompanyId = 1, CountryId = 1 });

            // Act & Assert
            Assert.ThrowsException<DataNotFoundException>(() => _contactService.DeleteContact(2));
        }


        [TestMethod]
        public void FilterContact_WithCountryIdAndCompanyId_ReturnsFilteredContacts()
        {
            // Arrange
            int countryId = 1;
            int companyId = 1;

            var testData = new List<Contact>
            {
                new Contact { Id = 1, ContactName = "Sime", CompanyId = 1, CountryId = 1, Company = new Company { CompanyName = "Nike" }, Country = new Country { CountryName = "USA" } },
                new Contact { Id = 2, ContactName = "Nokoski", CompanyId = 2, CountryId = 2, Company = new Company { CompanyName = "Lidl" }, Country = new Country { CountryName = "Germany" } },
                new Contact { Id = 3, ContactName = "Bojan", CompanyId = 1, CountryId = 1, Company = new Company { CompanyName = "Kiper" }, Country = new Country { CountryName = "Macedonia" } }
            };

            _mockContactRepository.Setup(x => x.FilterContacts(countryId, companyId)).Returns(
                testData.Where(c => c.CountryId == countryId && c.CompanyId == companyId).ToList());

            // Act
            var result = _contactService.FilterContact(countryId, companyId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }


        [TestMethod]
        public void GetContactsWithCompanyAndCountry_ReturnsFilteredContacts()
        {
            // Arrange

            var testData = new List<Contact>
            {
                  new Contact { Id = 1, ContactName = "Sime", CompanyId = 1, CountryId = 1, Company = new Company { CompanyName = "Name1" }, Country = new Country { CountryName = "Srbija" } },
                  new Contact { Id = 2, ContactName = "Nokoski", CompanyId = 2, CountryId = 2, Company = new Company { CompanyName = "Name2" }, Country = new Country { CountryName = "Macedonia" } }
             };

            _mockContactRepository.Setup(x => x.ContactWithCompanyAndCountry()).Returns(testData);

            // Act
            var result = _contactService.GetContactsWithCompanyAndCountry();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);

        }
    }
}
