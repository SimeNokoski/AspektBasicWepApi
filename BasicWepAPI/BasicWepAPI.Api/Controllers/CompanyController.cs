using BasicWepAPI.Core.Models;
using BasicWepAPI.Core.Services;
using BasicWepAPI.Services.DTOs.CompanyDtos;
using BasicWepAPI.Services.Helper.CustomExceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BasicWepAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyServices<CompanyDto> _services;
        public CompanyController(ICompanyServices<CompanyDto> services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAllCompany()
        {
            try
            {
                Log.Information("GetAllCompany successful");
                return Ok(_services.GetAllCompany());
            }
            catch (Exception)
            {
                Log.Error("Error in GetAllCompany");
                return StatusCode(500, "System error occurred.");
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetBuId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid id");
                }
                Log.Information("GetCompanyById successful for id {Id}", id);
                return Ok(_services.GetCompanyById(id));
            }
            catch (DataNotFoundException ex)
            {
                Log.Error(ex, "Company with id {Id} not found", id);
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                Log.Error("Error in GetCompanyById for id {Id}", id);
                return StatusCode(500, "System error occurred.");
            }
        }


        [HttpPost]
        public IActionResult CreateCompany(CompanyDto company)
        {
            try
            {
                _services.CreateCompany(company);
                Log.Information("CreateCompany successful");
                return Ok();
            }
            catch (ValidationException ex)
            {
                Log.Error(ex, "Validation error in CreateCompany");
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                Log.Error("Error in CreateCompany");
                return StatusCode(500, "System error occurred.");
            }
        }

        [HttpPut]
        public IActionResult UpdateCompany(CompanyDto companyDto)
        {
            try
            {
                _services.UpdateCompany(companyDto);
                Log.Information("UpdateCompany successful");
                return Ok();
            }
            catch(DataNotFoundException ex)
            {
                Log.Error(ex, "Company not found in UpdateCompany");
                return NotFound(ex.Message);
            }
            catch(ValidationException ex)
            {
                Log.Error(ex, "Validation error in UpdateCompany");
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                Log.Error("Error in UpdateCompany");
                return StatusCode(500, "System error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid id");
                }
                _services.DeleteCompany(id);
                Log.Information("DeleteCompany successful for id {Id}", id);
                return Ok();
            }
            catch (DataNotFoundException ex)
            {
                Log.Error(ex, "Company not found in DeleteCompany");
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                Log.Error("Error in DeleteCompany for id {Id}", id);
                return StatusCode(500, "System error occurred.");
            }
        }
    }
}
