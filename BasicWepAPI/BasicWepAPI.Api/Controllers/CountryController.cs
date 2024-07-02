using BasicWepAPI.Core.Services;
using BasicWepAPI.Services.DTOs.CountryDtos;
using BasicWepAPI.Services.Helper.CustomExceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BasicWepAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryServices<CountryDto> _countryServices;
        public CountryController(ICountryServices<CountryDto> countryServices)
        {
            _countryServices = countryServices;
        }

        [HttpGet]
        public IActionResult GetAllCountry()
        {
            try
            {
                Log.Information("GetAllCountry successful");
                return Ok(_countryServices.GetAllCountry());
            }
            catch (Exception)
            {
                Log.Error("Error in GetAllCountry");
                return StatusCode(500, "System error occurred.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid id");
                }
                Log.Information("GetCountryById successful for id {Id}", id);
                return Ok(_countryServices.GetCountryById(id));
            }
            catch(DataNotFoundException ex)
            {
                Log.Error(ex, "Country with id {Id} not found", id);
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                Log.Error("Error in GetCountryById for id {Id}", id);
                return StatusCode(500, "System error occurred.");
            }
        }

        [HttpPost]
        public IActionResult AddCountry(CountryDto country)
        {
            try
            {
                _countryServices.CreateCountry(country);
                Log.Information("CreateCountry successful");
                return Ok();
            }
            catch (ValidationException ex)
            {
                Log.Error(ex, "Validation error in CreateCountry");
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                Log.Error("Error in CreateCountry");
                return StatusCode(500, "System error occurred.");
            }
        }

        [HttpPut]
        public IActionResult UpdateCountry(CountryDto country)
        {
            try
            {
                _countryServices.UpdateCountry(country);
                return Ok();
            }
            catch (DataNotFoundException ex)
            {
                Log.Error(ex, "Country not found in UpdateCountry");
                return NotFound(ex.Message);
            }
            catch (ValidationException ex)
            {
                Log.Error(ex, "Validation error in UpdateCountry");
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                Log.Error("Error in UpdateCountry");
                return StatusCode(500, "System error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid id");
                }
                _countryServices.DeleteCountry(id);
                Log.Information("DeleteCountry successful for id {Id}", id);
                return Ok();
            }
            catch(DataNotFoundException ex)
            {
                Log.Error(ex, "Country with id {Id} not found", id);
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                Log.Error("Error in DeleteCountry for id {Id}", id);
                return StatusCode(500, "System error occurred.");
            }
        }
    }
}
