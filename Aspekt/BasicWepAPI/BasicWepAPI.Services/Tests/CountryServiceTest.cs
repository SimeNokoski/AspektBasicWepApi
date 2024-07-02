using BasicWepAPI.Core.Models;
using BasicWepAPI.Core.Repositories;
using BasicWepAPI.Services.DTOs.CompanyDtos;
using BasicWepAPI.Services.DTOs.CountryDtos;
using BasicWepAPI.Services.Helper.CustomExceptions;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Services.Tests
{
    [TestClass]
    public class CountryServiceTest
    {
        private Mock<ICountryRepository> _mockCountryRepository;
        private CountryService _countryService;
        [TestInitialize]
        public void Setup()
        {
            _mockCountryRepository = new Mock<ICountryRepository>();
            _countryService = new CountryService(_mockCountryRepository.Object);
        }

        [TestMethod]
        public void GetAllCountry_Returns_AllCountries()
        {
            // Arrange
            _mockCountryRepository.Setup(repo => repo.GetAll()).Returns(new List<Country>
        {
            new Country { Id = 1, CountryName = "Macedonia" },
            new Country { Id = 2, CountryName = "Srbija" },
        });

            // Act
            var result = _countryService.GetAllCountry();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void CreateCountry_Throws_ValidationException_OnInvalidData()
        {
            // Arrange
            var invalidCompanyDto = new CountryDto
            {
                CountryName = ""
            };

            // Act & Assert
            var ex = Assert.ThrowsException<ValidationException>(() => _countryService.CreateCountry(invalidCompanyDto));
        }

        [TestMethod]
        public void GetCountryById_Returns_CountryDto_WhenCountryExists()
        {
            // Arrange
            int countryId = 1;
            _mockCountryRepository.Setup(repo => repo.GetById(countryId)).Returns(new Country { Id = countryId, CountryName = "Macedonia" });

            // Act
            var result = _countryService.GetCountryById(countryId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(countryId, result.Id);
            Assert.AreEqual("Macedonia", result.CountryName);
        }

        [TestMethod]
        public void DeleteCountry_Throws_DataNotFoundException_WhenCountryDoesNotExist()
        {
            // Arrange
            int countryId = 1;
            _mockCountryRepository.Setup(repo => repo.GetById(countryId)).Returns(new Country { Id = countryId, CountryName = "Macedonia" });

            // Act & Assert
            Assert.ThrowsException<DataNotFoundException>(() => _countryService.DeleteCountry(2));
        }
    }
}
