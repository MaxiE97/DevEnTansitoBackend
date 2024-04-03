using BackendDevEnTansito.DevEnTransito.Application.DTOs;
using BackendDevEnTansito.DevEnTransito.Application.Services.Company;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CompanyDto companyDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _companyService.CreateCompanyAsync(companyDto);

        return Ok("Creación de la compañía exitosa.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompany(int id)
    {
        var company = await _companyService.GetCompanyAsync(id);
        if (company == null)
        {
            return NotFound();
        }

        return Ok(company);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCompanies()
    {
        var companies = await _companyService.GetAllCompaniesAsync();
        return Ok(companies);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        await _companyService.DeleteCompanyAsync(id);
        return Ok("Compañía eliminada con éxito.");
    }
}
