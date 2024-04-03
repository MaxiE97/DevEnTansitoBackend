using BackendDevEnTansito.DevEnTransito.Application.DTOs;

namespace BackendDevEnTansito.DevEnTransito.Application.Services.JobIt
{
    public interface IJobItService
    {
        Task AddJobItAsync(JobItDto jobItDto);
        Task DeleteJobItAsync(int jobItId);
        Task<List<JobItDto>> GetAllJobsItAsync();
        Task<JobItDto> GetJobItAsync(int jobItId);
    }
}
