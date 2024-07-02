using BasicWepAPI.Core.Models;
using BasicWepAPI.Core.Repositories;
using BasicWepAPI.Core.Services;
using BasicWepAPI.Services.DTOs.ContactDtos;
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
    public class ContactService : IContactServices<ContactDto, FilterContactsDto>
    {
        private readonly IContactRepository _contactRepository;
        private ContactValidator _validationRules;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            _validationRules = new ContactValidator();
        }
        public List<FilterContactsDto> GetContactsWithCompanyAndCountry()
        {
            var contactDb = _contactRepository.ContactWithCompanyAndCountry();
            if(contactDb == null)
            {
                throw new DataNotFoundException("contact was not found");
            }
            return contactDb.Select(x => x.ToFilterContactDto()).ToList();
        }

        public void CreateContact(ContactDto items)
        {
            Contact contact = items.ToContact();
            var validate = _validationRules.Validate(items);
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }
            _contactRepository.Add(contact);
        }

        public void DeleteContact(int id)
        {
            Contact contact = _contactRepository.GetById(id);
            if (contact == null)
            {
                throw new DataNotFoundException($"Contact with {id} was not found");
            }
            _contactRepository.Delete(contact.Id);
        }

        public List<FilterContactsDto> FilterContact(int? countryId, int? companyId)
        {

            return _contactRepository.FilterContacts(countryId, companyId).Select(x => x.ToFilterContactDto()).ToList();
        }

        public List<ContactDto> GetAllContact()
        {
            return _contactRepository.GetAll().Select(x=>x.ToContactDto()).ToList();
        }

        public Dictionary<string, int> GetCompanyStatisticsByCountryId(int countryId)
        {
            var companies = _contactRepository.GetCompanyStatisticsByCountryId(countryId);

            var companyStatistics = new Dictionary<string, int>();

            foreach (var contact in companies)
            {
                var companyName = contact.Company.CompanyName;
                if (companyStatistics.ContainsKey(companyName))
                {
                    companyStatistics[companyName]++;
                }
                else
                {
                    companyStatistics.Add(companyName, 1);
                }
            }

            return companyStatistics;
        }

        public ContactDto GetContactById(int id)
        {
            Contact contact = _contactRepository.GetById(id);
            if (contact == null)
            {
                throw new DataNotFoundException($"Contact with {id} was not found");
            }
            return contact.ToContactDto();
        }

        public void UpdateContact(ContactDto items)
        {
            Contact contact = _contactRepository.GetById(items.Id);
            if (contact == null)
            {
                throw new DataNotFoundException($"Contact with id {items.Id} was not found");
            }
            var validate = _validationRules.Validate(items);
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }
            contact.ContactName = items.ContactName;
            _contactRepository.Update(contact);

        }
    }
}
