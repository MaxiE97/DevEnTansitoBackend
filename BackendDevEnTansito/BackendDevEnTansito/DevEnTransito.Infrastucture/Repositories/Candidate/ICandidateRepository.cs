using BackendDevEnTansito.DevEnTransito.Domain.Entities;

namespace BackendDevEnTansito.DevEnTransito.Infrastucture.Repositories.Candidate
{
    public interface ICandidateRepository
    {
        //Task AddCandidateAsync(CandidateEntity candidate);
        Task<CandidateEntity> AddCandidateAsync(CandidateEntity candidate);
        Task DeleteCandidateAsync(int candidateId);
        Task<List<CandidateEntity>> GetAllCandidatesAsync();
        Task<CandidateEntity> GetCandidateAsync(int candidateId);
    }
}
