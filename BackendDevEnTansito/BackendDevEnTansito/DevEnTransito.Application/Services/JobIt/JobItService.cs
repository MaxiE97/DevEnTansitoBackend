using AutoMapper;
using BackendDevEnTansito.DevEnTransito.Application.DTOs;
using BackendDevEnTansito.DevEnTransito.Application.Services.JobIt;
using BackendDevEnTansito.DevEnTransito.Domain.Entities;
using BackendDevEnTansito.DevEnTransito.Infrastucture.Repositories.JobIt;
using System.Collections.Generic;
using System.Threading.Tasks;

public class JobItService : IJobItService
{
    private readonly IJobItRepository _jobItRepository;
    private readonly IMapper _mapper;

    public JobItService(IJobItRepository jobItRepository, IMapper mapper)
    {
        _jobItRepository = jobItRepository;
        _mapper = mapper;
    }

    public async Task AddJobItAsync(JobItDto jobItDto)
    {
        var jobIt = _mapper.Map<JobItEntity>(jobItDto);
        await _jobItRepository.AddJobItAsync(jobIt);
    }

    public async Task<JobItDto> GetJobItAsync(int jobItId)
    {
        var jobIt = await _jobItRepository.GetJobItAsync(jobItId);
        var jobItDto = _mapper.Map<JobItDto>(jobIt);
        return jobItDto;
    }

    public async Task DeleteJobItAsync(int jobItId)
    {
        await _jobItRepository.DeleteJobItAsync(jobItId);
    }

    public async Task<List<JobItDto>> GetAllJobsItAsync()
    {
        var listJobsIt = await _jobItRepository.GetAllJobsItAsync();
        var listJobsItDto = _mapper.Map<List<JobItDto>>(listJobsIt);
        return listJobsItDto;
    }
}
