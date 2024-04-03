using BackendDevEnTansito.DevEnTransito.Domain.Entities;
using BackendDevEnTansito.DevEnTransito.Infrastucture.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BackendDevEnTansito.DevEnTransito.Infrastucture.Repositories.Company
{


    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCompanyAsync(CompanyEntity company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task<CompanyEntity> GetCompanyAsync(int companyId)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == companyId);
            return company;

        }

        public async Task DeleteCompanyAsync(int companyId)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == companyId);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CompanyEntity>> GetAllCompaniesAsync()
        {
            var listCompanies = await _context.Companies.ToListAsync();
            return listCompanies;
        }

    }
}



