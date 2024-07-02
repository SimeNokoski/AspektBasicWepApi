using BasicWepAPI.Core.Models;
using BasicWepAPI.Services.DTOs.CountryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Services.Mapper
{
    public static class CountryMapper
    {
        public static CountryDto ToCountryDto(this Country country)
        {
            return new CountryDto
            {
                Id = country.Id,
                CountryName = country.CountryName
            };
        }

        public static Country ToAddCountry(this CountryDto countryDto)
        {
            return new Country
            {
                Id = countryDto.Id,
                CountryName = countryDto.CountryName
            };
        }

      
    }
}
