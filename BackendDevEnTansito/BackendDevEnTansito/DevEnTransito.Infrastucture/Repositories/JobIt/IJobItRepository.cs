using BackendDevEnTansito.DevEnTransito.Domain.Entities;

namespace BackendDevEnTansito.DevEnTransito.Infrastucture.Repositories.JobIt
{
    public interface IJobItRepository
    {
        Task AddJobItAsync(JobItEntity jobIt);
        Task DeleteJobItAsync(int jobItId);
        Task<List<JobItEntity>> GetAllJobsItAsync();
        Task<JobItEntity> GetJobItAsync(int jobItId);
    }
}
