using CompanyWebApi.Models;

namespace CompanyWebApi.Service.IService
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
        Task<Country> CreateCountry(Country country);
        Task<Country> UpdateCountry(int countryId, Country country);
        Task<bool> DeleteCountry(int countryId);
    }
}
