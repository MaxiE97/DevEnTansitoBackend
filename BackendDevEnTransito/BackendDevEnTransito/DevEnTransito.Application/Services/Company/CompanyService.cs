using AutoMapper;
using BackendDevEnTansito.DevEnTransito.Application.DTOs;
using BackendDevEnTansito.DevEnTransito.Application.Services.Company;
using BackendDevEnTansito.DevEnTransito.Domain.Entities;
using BackendDevEnTansito.DevEnTransito.Infrastucture.Repositories.Company;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;

    public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
    }

    public async Task CreateCompanyAsync(CompanyDto companyDto)
    {
        var company = _mapper.Map<CompanyEntity>(companyDto); 
        await _companyRepository.AddCompanyAsync(company);
    }

    public async Task<CompanyDto> GetCompanyAsync(int companyId)
    {
        var company = await _companyRepository.GetCompanyAsync(companyId);
        var companyDto = _mapper.Map<CompanyDto>(company);
        return companyDto;
    }

    public async Task DeleteCompanyAsync(int companyId)
    {
        await _companyRepository.DeleteCompanyAsync(companyId);
    }

    public async Task<List<CompanyDto>> GetAllCompaniesAsync()
    {
        var listCompanies = await _companyRepository.GetAllCompaniesAsync();
        var listCompaniesDto = _mapper.Map<List<CompanyDto>>(listCompanies);
        return listCompaniesDto;
    }
}
