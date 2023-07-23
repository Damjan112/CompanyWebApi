using CompanyWebApi.Models;
using CompanyWebApi.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetAllCountries()
        {
            var countries = await _countryService.GetAllCountries();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountryById(int id)
        {
            var country = await _countryService.GetCountryById(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> CreateCountry([FromBody] Country country)
        {
            var createdCountry = await _countryService.CreateCountry(country);
            return CreatedAtAction(nameof(GetCountryById), new { id = createdCountry.CountryId }, createdCountry);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Country>> UpdateCountry(int id, [FromBody] Country country)
        {
            var updatedCountry = await _countryService.UpdateCountry(id, country);

            if (updatedCountry == null)
            {
                return NotFound();
            }

            return Ok(updatedCountry);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            var result = await _countryService.DeleteCountry(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
