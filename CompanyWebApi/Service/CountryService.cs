using CompanyWebApi.Context;
using CompanyWebApi.Models;
using CompanyWebApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApi.Service
{
    public class CountryService : ICountryService
    {
        private readonly ApiContext _dbContext;

        public CountryService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Country>> GetAllCountries()
        {
            return await _dbContext.countries.ToListAsync();
        }

        public async Task<Country> GetCountryById(int countryId)
        {
            return await _dbContext.countries.FindAsync(countryId);
        }

        public async Task<Country> CreateCountry(Country country)
        {
            _dbContext.countries.Add(country);
            await _dbContext.SaveChangesAsync();
            return country;
        }

        public async Task<Country> UpdateCountry(int countryId, Country updatedCountry)
        {
            var existingCountry = await _dbContext.countries.FindAsync(countryId);

            if (existingCountry == null)
            {
                return null;
            }

            existingCountry.CountryName = updatedCountry.CountryName;

            await _dbContext.SaveChangesAsync();

            return existingCountry;
        }

        public async Task<bool> DeleteCountry(int countryId)
        {
            var existingCountry = await _dbContext.countries.FindAsync(countryId);

            if (existingCountry == null)
            {
                return false;
            }

            _dbContext.countries.Remove(existingCountry);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
