using BasicWepAPI.Core.Models;
using BasicWepAPI.Core.Repositories;
using BasicWepAPI.Core.Services;
using BasicWepAPI.Services.DTOs.CompanyDtos;
using BasicWepAPI.Services.Helper.CustomExceptions;
using FluentValidation;
using FluentValidation.Results;
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
    public class CompanyServiceTest
    {
        private Mock<ICompanyRepository> _mockCompanyRepository;
        private CompanyService _companyService;
        [TestInitialize]
        public void Setup()
        {
            _mockCompanyRepository = new Mock<ICompanyRepository>();
            _companyService = new CompanyService(_mockCompanyRepository.Object);
        }
        [TestMethod]
        public void GetAllCompany_Returns_AllCompanies()
        {
            // Arrange
            _mockCompanyRepository.Setup(repo => repo.GetAll()).Returns(new List<Company>
        {
            new Company { Id = 1, CompanyName = "Name1" },
            new Company { Id = 2, CompanyName = "Name2" },
        });

            // Act
            var result = _companyService.GetAllCompany();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void CreateCompany_Throws_ValidationException_OnInvalidData()
        {
            // Arrange
            var invalidCompanyDto = new CompanyDto
            {
                CompanyName = ""
            };

            // Act & Assert
            var ex = Assert.ThrowsException<ValidationException>(() => _companyService.CreateCompany(invalidCompanyDto));
        }

        [TestMethod]
        public void GetCompanyById_Returns_CompanyDto_WhenCompanyExists()
        {
            // Arrange
            int companyId = 1;
            _mockCompanyRepository.Setup(repo => repo.GetById(companyId)).Returns(new Company { Id = companyId, CompanyName = "Aspekt" });

            // Act
            var result = _companyService.GetCompanyById(companyId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(companyId, result.Id);
            Assert.AreEqual("Aspekt", result.CompanyName);
        }

        [TestMethod]
        public void DeleteCompany_Throws_DataNotFoundException_WhenCompanyDoesNotExist()
        {
            // Arrange
            int companyId = 1;
            _mockCompanyRepository.Setup(repo => repo.GetById(companyId)).Returns(new Company { Id = companyId, CompanyName = "Aspekt" });

            // Act & Assert
            Assert.ThrowsException<DataNotFoundException>(() => _companyService.DeleteCompany(2));
        }


    }
}
