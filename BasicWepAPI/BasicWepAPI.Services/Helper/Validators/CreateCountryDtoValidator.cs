using BasicWepAPI.Services.DTOs.CompanyDtos;
using BasicWepAPI.Services.DTOs.CountryDtos;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Services.Helper.Validators
{
    public class CreateCountryDtoValidator : AbstractValidator<CountryDto>
    {
        public CreateCountryDtoValidator()
        {
            RuleFor(dto => dto.CountryName)
           .NotEmpty().WithMessage("Country name is required.")
           .MaximumLength(20).WithMessage("Country name cannot be longer than 20 characters.");
        }
    }
}
