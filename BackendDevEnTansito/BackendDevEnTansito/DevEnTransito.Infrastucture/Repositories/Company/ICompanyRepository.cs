namespace BackendDevEnTansito.DevEnTransito.Infrastucture.Repositories.Company


{
    using BackendDevEnTansito.DevEnTransito.Domain.Entities;

    public interface ICompanyRepository
    {
        Task AddCompanyAsync(CompanyEntity company);
        Task DeleteCompanyAsync(int companyId);
        Task<CompanyEntity> GetCompanyAsync(int companyId);
        Task<List<CompanyEntity>> GetAllCompaniesAsync();        

    }

}
