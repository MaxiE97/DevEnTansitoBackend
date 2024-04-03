using BackendDevEnTansito.DevEnTransito.Domain.Entities;
using BackendDevEnTansito.DevEnTransito.Infrastucture.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace BackendDevEnTansito.DevEnTransito.Infrastucture.Repositories.JobIt
{
    public class JobItRepository: IJobItRepository
    {

        
            private readonly ApplicationDbContext _context;

            public JobItRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task AddJobItAsync(JobItEntity jobIt)
            {
                await _context.Jobs.AddAsync(jobIt);
                await _context.SaveChangesAsync();
            }

            public async Task<JobItEntity> GetJobItAsync(int jobItId)
                {
                    var jobIt = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == jobItId);
                    return jobIt;

                 }

            public async Task DeleteJobItAsync(int jobItId)
                {
                    var jobIt = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == jobItId);
                    if (jobIt != null)
                    {
                        _context.Jobs.Remove(jobIt);
                        await _context.SaveChangesAsync();
                    }
                }

            public async Task<List<JobItEntity>> GetAllJobsItAsync()
                {
                    var listJobsIt = await _context.Jobs.ToListAsync();
                    return listJobsIt;
                }

        }
    

}

