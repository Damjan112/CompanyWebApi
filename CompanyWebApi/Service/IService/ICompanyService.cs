using CompanyWebApi.Models;

namespace CompanyWebApi.Service.IService
{
    public interface ICompanyService
    {
        Task<List<Company>> GetAllCompanies();
        Task<Company> GetCompanyById(int companyId);
        Task<Company> CreateCompany(Company company);
        Task<Company> UpdateCompany(int companyId, Company company);
        Task<bool> DeleteCompany(int companyId);
    }
}
