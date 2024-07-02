using BasicWepAPI.Core.Models;
using BasicWepAPI.Core.Repositories;
using BasicWepAPI.Core.Services;
using BasicWepAPI.Services.DTOs.CompanyDtos;
using BasicWepAPI.Services.Helper.CustomExceptions;
using BasicWepAPI.Services.Helper.Validators;
using BasicWepAPI.Services.Mapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Services
{
    public class CompanyService : ICompanyServices<CompanyDto>
    {
        private  ICompanyRepository _companyRepository;
        private CreateCompanytoValidator _validationRules;
        private UpdateCompanyDtoValidator _updateValidator;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
            _validationRules = new CreateCompanytoValidator();
            _updateValidator = new UpdateCompanyDtoValidator();
        }
        public List<CompanyDto> GetAllCompany()
        {
            var companys = _companyRepository.GetAll().Select(x => x.ToCompanyDto()).ToList();

            return companys;
        }

        public void CreateCompany(CompanyDto items)
        {
            var validate = _validationRules.Validate(items);
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }
            var company = items.ToCompany();
            _companyRepository.Add(company);

        }

        public CompanyDto GetCompanyById(int id)
        {
            var company = _companyRepository.GetById(id);
            if(company == null)
            {
                throw new DataNotFoundException($"Company with {id} was not found");
            }
            return company.ToCompanyDto();
        }

        public void UpdateCompany(CompanyDto items)
        {
           Company companyDb = _companyRepository.GetById(items.Id);
            if (companyDb == null)
            {
                throw new DataNotFoundException($"Company with id {items.Id} was not found");
            }
            var validate = _updateValidator.Validate(items);
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }
            companyDb.CompanyName = items.CompanyName;
            _companyRepository.Update(companyDb);

        }

        public void DeleteCompany(int id)
        {
            Company company = _companyRepository.GetById(id);
            if(company == null)
            {
                throw new DataNotFoundException($"Company with {id} was not found");
            }
            _companyRepository.Delete(company.Id);
        }
    }
}
