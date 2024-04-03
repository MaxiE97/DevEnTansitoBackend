using BackendDevEnTansito.DevEnTransito.Domain.Entities;
using BackendDevEnTansito.DevEnTransito.Infrastucture.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BackendDevEnTansito.DevEnTransito.Infrastucture.Repositories.Candidate
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CandidateEntity> AddCandidateAsync(CandidateEntity candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
            return candidate;

        }

        public async Task<CandidateEntity> GetCandidateAsync(int candidateId)
        {
            var candidate = await _context.Candidates.FirstOrDefaultAsync(c => c.Id == candidateId);
            return candidate;

        }

        public async Task DeleteCandidateAsync(int candidateId)
        {
            var candidate = await _context.Candidates.FirstOrDefaultAsync(c => c.Id == candidateId);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CandidateEntity>> GetAllCandidatesAsync()
        {
            var listCandidatesIt = await _context.Candidates.ToListAsync();
            return listCandidatesIt;
        }

    }

}

