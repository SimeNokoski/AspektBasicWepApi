using BasicWepAPI.Core.Services;
using BasicWepAPI.Services.DTOs.ContactDtos;
using BasicWepAPI.Services.Helper.CustomExceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BasicWepAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactServices<ContactDto,FilterContactsDto> _contactServices;
        public ContactController(IContactServices<ContactDto, FilterContactsDto> contactServices)
        {
            _contactServices = contactServices;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            try
            {
                Log.Information("GetAllContacts successful");
                return Ok(_contactServices.GetAllContact());
            }
            catch (Exception)
            {
                Log.Error("Error in GetAllContacts");
                return StatusCode(500, "System error occurred.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid id");
                }
                Log.Information("GetContactById successful for id {Id}", id);
                return Ok(_contactServices.GetContactById(id));
            }
            catch (DataNotFoundException ex)
            {
                Log.Error(ex, "Contact with id {Id} not found", id);
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                Log.Error("Error in GetContactById for id {Id}", id);
                return StatusCode(500, "System error occurred.");
            }

        }

        [HttpPost]
        public IActionResult CreateContact(ContactDto contactDto)
        {
            try
            {
                _contactServices.CreateContact(contactDto);
                return Ok();
            }
            catch (ValidationException ex)
            {
                Log.Error(ex, "Validation error in CreateContact");
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                Log.Error("Error in CreateContact");
                return StatusCode(500, "System error occurred.");
            }
        }

        [HttpPut]
        public IActionResult UpdateContact(ContactDto contactDto)
        {
            try
            {
                _contactServices.UpdateContact(contactDto);
                return Ok();
            }
            catch (DataNotFoundException ex)
            {
                Log.Error(ex, "Company not found in UpdateContact");
                return NotFound(ex.Message);
            }
            catch (ValidationException ex)
            {
                Log.Error(ex, "Validation error in UpdateContact");
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                Log.Error("Error in UpdateContact");
                return StatusCode(500, "System error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest($"Invalid id: {id}");
                }
                _contactServices.DeleteContact(id);
                Log.Information("DeleteContact successful for id {Id}", id);
                return Ok();
            }
            catch(DataNotFoundException ex)
            {
                Log.Error(ex, "Contact with id {Id} not found", id);
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                Log.Error("Error in DeleteContact for id {Id}", id);
                return StatusCode(500, "System error occurred.");
            }
        }

        [HttpGet("getContacts")]
        public IActionResult ContactWithCompanyAndCountry()
        {
            try
            {
                Log.Information("ContactWithCompanyAndCountry successful");
                return Ok(_contactServices.GetContactsWithCompanyAndCountry());
            }
            catch (Exception)
            {
                Log.Error("Error in ContactWithCompanyAndCountry");
                return StatusCode(500, "System error occurred.");
            }
        }

        [HttpGet("filterContacts")]
        public IActionResult FilterContacts(int? countryId, int? companyId)
        {
            try
            {
                Log.Information($"FilterContacts successful for countryId {countryId} and companyId {companyId}");
                return Ok(_contactServices.FilterContact(countryId, companyId));
            }
            catch (Exception)
            {
                Log.Error($"Error in FilterContacts for countryId {countryId} and companyId {companyId}");
                return StatusCode(500, "System error occurred.");
            }
        }

        [HttpGet("getCompanyStatisticsByCountryId")]
        public IActionResult GetCompanyStatisticsByCountryId(int id)
        {
            return Ok(_contactServices.GetCompanyStatisticsByCountryId(id));
        }
    }
}
