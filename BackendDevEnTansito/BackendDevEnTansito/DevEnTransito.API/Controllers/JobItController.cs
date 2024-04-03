using BackendDevEnTansito.DevEnTransito.Application.DTOs;
using BackendDevEnTansito.DevEnTransito.Application.Services.JobIt;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class JobItController : ControllerBase
{
    private readonly IJobItService _jobItService;

    public JobItController(IJobItService jobItService)
    {
        _jobItService = jobItService;
    }

    [HttpPost]
    public async Task<IActionResult> AddJobIt([FromBody] JobItDto jobItDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _jobItService.AddJobItAsync(jobItDto);

        return Ok("JobIt creado exitosamente.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetJobIt(int id)
    {
        var jobIt = await _jobItService.GetJobItAsync(id);
        if (jobIt == null)
        {
            return NotFound();
        }

        return Ok(jobIt);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllJobsIt()
    {
        var jobsIt = await _jobItService.GetAllJobsItAsync();
        return Ok(jobsIt);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJobIt(int id)
    {
        await _jobItService.DeleteJobItAsync(id);
        return Ok("JobIt eliminado con éxito.");
    }
}
