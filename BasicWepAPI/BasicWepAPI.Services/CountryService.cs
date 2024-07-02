using BasicWepAPI.Core.Models;
using BasicWepAPI.Core.Repositories;
using BasicWepAPI.Core.Services;
using BasicWepAPI.Services.DTOs.CountryDtos;
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
    public class CountryService : ICountryServices<CountryDto>
    {
        private readonly ICountryRepository _countryRepository;
        private CreateCountryDtoValidator _validationRules;
        private UpdateCountryDtoValidator _updateValidator;
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
            _validationRules = new CreateCountryDtoValidator();
            _updateValidator = new UpdateCountryDtoValidator();
        }
        public void CreateCountry(CountryDto items)
        {
            var validate = _validationRules.Validate(items);
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }
            Country country = items.ToAddCountry();
            _countryRepository.Add(country);
            
        }

        public void DeleteCountry(int id)
        {
            Country country = _countryRepository.GetById(id);
            if (country == null)
            {
                throw new DataNotFoundException($"Country with {id} was not found");
            }
            _countryRepository.Delete(country.Id);
        }

        public List<CountryDto> GetAllCountry()
        {
            return _countryRepository.GetAll().Select(x=>x.ToCountryDto()).ToList();
        }

        public CountryDto GetCountryById(int id)
        {
            Country country = _countryRepository.GetById(id);
            if (country == null)
            {
                throw new DataNotFoundException($"Company with {id} was not found");
            }
            return country.ToCountryDto();
        }

        public void UpdateCountry(CountryDto items)
        {
            Country country = _countryRepository.GetById(items.Id);
            if (country == null)
            {
                throw new DataNotFoundException($"Country with id {items.Id} was not found");
            }
            var validate = _updateValidator.Validate(items);
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }
            country.CountryName = items.CountryName;
            _countryRepository.Update(country);
        }
    }
}
