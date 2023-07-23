using CompanyWebApi.Context;
using CompanyWebApi.Models;
using CompanyWebApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApi.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ApiContext _dbContext;

        public CompanyService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            return await _dbContext.companies.ToListAsync();
        }

        public async Task<Company> GetCompanyById(int companyId)
        {
            return await _dbContext.companies.FindAsync(companyId);
        }

        public async Task<Company> CreateCompany(Company company)
        {
            _dbContext.companies.Add(company);
            await _dbContext.SaveChangesAsync();
            return company;
        }

        public async Task<Company> UpdateCompany(int companyId, Company updatedCompany)
        {
            var existingCompany = await _dbContext.companies.FindAsync(companyId);

            if (existingCompany == null)
            {
                return null;
            }

            existingCompany.CompanyName = updatedCompany.CompanyName;

            await _dbContext.SaveChangesAsync();

            return existingCompany;
        }

        public async Task<bool> DeleteCompany(int companyId)
        {
            var existingCompany = await _dbContext.companies.FindAsync(companyId);

            if (existingCompany == null)
            {
                return false;
            }

            _dbContext.companies.Remove(existingCompany);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
