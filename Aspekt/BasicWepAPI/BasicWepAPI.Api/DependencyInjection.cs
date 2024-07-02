using BasicWepAPI.Core.Models;
using BasicWepAPI.Core.Repositories;
using BasicWepAPI.Core.Services;
using BasicWepAPI.Data;
using BasicWepAPI.Data.Repositories;
using BasicWepAPI.Services;
using BasicWepAPI.Services.DTOs.CompanyDtos;
using BasicWepAPI.Services.DTOs.ContactDtos;
using BasicWepAPI.Services.DTOs.CountryDtos;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;


namespace BasicWepAPI.Api
{
    public static class DependencyInjection
    {
        public static void InjectDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BasicWepApiDbContext>(options => options.UseSqlServer(connectionString));
        }


        public static void InjectRepository(this IServiceCollection services)
        {
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<ICompanyServices<CompanyDto>, CompanyService>();
            services.AddTransient<ICountryServices<CountryDto>, CountryService>();
            services.AddTransient<IContactServices<ContactDto, FilterContactsDto>, ContactService>();
        }
    }
}
