using BasicWepAPI.Services.DTOs.ContactDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Services.Helper.Validators
{
    public class ContactValidator : AbstractValidator<ContactDto>
    {
        public ContactValidator()
        {
            RuleFor(dto => dto.ContactName)
          .NotEmpty().WithMessage("Contact name is required.")
          .MaximumLength(20).WithMessage("Contact name cannot be longer than 20 characters.");
        }
    }
}
