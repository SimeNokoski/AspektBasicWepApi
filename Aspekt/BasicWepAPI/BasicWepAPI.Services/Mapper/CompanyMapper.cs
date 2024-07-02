
using BasicWepAPI.Core.Models;
using BasicWepAPI.Services.DTOs.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Services.Mapper
{
    public static class CompanyMapper
    {
        public static CompanyDto ToCompanyDto(this Company company)
        {
            return new CompanyDto
            {
                Id = company.Id,
                CompanyName = company.CompanyName
            };
        }

        public static Company ToCompany(this CompanyDto company)
        {
            return new Company
            {
                Id = company.Id,
                CompanyName = company.CompanyName
            };
        }

      
    }
}
