using AutoMapper;
using BackendDevEnTansito.DevEnTransito.Application.DTOs;
using BackendDevEnTansito.DevEnTransito.Domain.Entities;

namespace BackendDevEnTansito.DevEnTransito.Application.Mappings
{
    public class AutoMapperConfigProfile: Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<CompanyEntity, CompanyDto>().ReverseMap();
            CreateMap<JobItEntity, JobItDto>().ReverseMap();
            CreateMap<CandidateEntity, CandidateDto>().ReverseMap();
        }
    }
}
