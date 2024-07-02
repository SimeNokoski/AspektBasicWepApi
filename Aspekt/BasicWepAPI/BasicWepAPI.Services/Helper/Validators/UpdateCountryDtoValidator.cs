using BasicWepAPI.Services.DTOs.CountryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Services.Helper.Validators
{
    public class UpdateCountryDtoValidator : AbstractValidator<CountryDto>
    {
        public UpdateCountryDtoValidator()
        {
            RuleFor(dto => dto.CountryName)
            .NotEmpty().WithMessage("Country name is required.")
            .MaximumLength(20).WithMessage("Country name cannot be longer than 20 characters.");
        }
    }
}
