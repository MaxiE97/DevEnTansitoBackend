using BackendDevEnTansito.DevEnTransito.Application.DTOs;
using BackendDevEnTansito.DevEnTransito.Application.Services.Candidate;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CandidateController : ControllerBase
{
    private readonly ICandidateService _candidateService;

    public CandidateController(ICandidateService candidateService)
    {
        _candidateService = candidateService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCandidate([FromForm] CandidateDto dto, IFormFile pdfFile)
    {
        var result = await _candidateService.CreateCandidateAsync(dto, pdfFile);

        if (result == "File is not valid")
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCandidate(int id)
    {
        var candidate = await _candidateService.GetCandidateAsync(id);
        if (candidate == null)
        {
            return NotFound();
        }

        return Ok(candidate);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCandidates()
    {
        var candidates = await _candidateService.GetAllCandidatesAsync();
        return Ok(candidates);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCandidate(int id)
    {
        await _candidateService.DeleteCandidateAsync(id);
        return Ok("Candidato eliminado con éxito.");
    }
}
