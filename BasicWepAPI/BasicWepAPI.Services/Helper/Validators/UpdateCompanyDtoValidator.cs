using BasicWepAPI.Services.DTOs.CompanyDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Services.Helper.Validators
{
    public class UpdateCompanyDtoValidator : AbstractValidator<CompanyDto>
    {
        public UpdateCompanyDtoValidator()
        {
            RuleFor(dto => dto.CompanyName)
           .NotEmpty().WithMessage("Company name is required.")
           .MaximumLength(20).WithMessage("Company name cannot be longer than 20 characters.");
        }
    }
}
