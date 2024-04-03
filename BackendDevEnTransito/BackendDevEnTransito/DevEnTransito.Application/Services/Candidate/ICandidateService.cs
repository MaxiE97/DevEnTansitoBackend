using BackendDevEnTansito.DevEnTransito.Application.DTOs;

namespace BackendDevEnTansito.DevEnTransito.Application.Services.Candidate
{
    public interface ICandidateService
    {
        Task<string> CreateCandidateAsync(CandidateDto dto, IFormFile pdfFile);
        Task DeleteCandidateAsync(int candidateId);
        Task<List<CandidateDto>> GetAllCandidatesAsync();
        Task<CandidateDto> GetCandidateAsync(int candidateId);
    }
}
