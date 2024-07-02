using BasicWepAPI.Core.Models;
using BasicWepAPI.Services.DTOs.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Services.Mapper
{
    public static class ContactMapper
    {
        public static ContactDto ToContactDto(this Contact contact)
        {
            return new ContactDto
            {
                Id = contact.Id,
                ContactName = contact.ContactName,
                CompanyId = contact.CompanyId,
                CountryId = contact.CountryId,
            };
        }

        public static Contact ToContact(this ContactDto contactDto)
        {
            return new Contact
            {
                Id = contactDto.Id, 
                ContactName = contactDto.ContactName,
                CompanyId = contactDto.CompanyId,
                CountryId = contactDto.CountryId,
            };
        }

      public static FilterContactsDto ToFilterContactDto(this Contact contact)
        {
            return new FilterContactsDto
            {
                CompanyId = contact.CompanyId,
                ContactId = contact.Id,
                CountryId = contact.CountryId,
                CompanyName = contact.Company.CompanyName,
                ContactName = contact.ContactName,
                CountryName = contact.Country.CountryName
            };
        }


    }
}
