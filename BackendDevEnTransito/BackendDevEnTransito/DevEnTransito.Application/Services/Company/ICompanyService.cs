using BackendDevEnTansito.DevEnTransito.Application.DTOs;

namespace BackendDevEnTansito.DevEnTransito.Application.Services.Company
{
    public interface ICompanyService
    {
        Task CreateCompanyAsync(CompanyDto companyDto);
        Task DeleteCompanyAsync(int companyId);
        Task<CompanyDto> GetCompanyAsync(int companyId);
        Task<List<CompanyDto>> GetAllCompaniesAsync();
    }

}
