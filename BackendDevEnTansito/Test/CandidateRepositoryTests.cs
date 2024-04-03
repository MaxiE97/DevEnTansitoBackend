using BackendDevEnTansito.DevEnTransito.Domain.Entities;
using BackendDevEnTansito.DevEnTransito.Infrastucture.Data.Context;
using BackendDevEnTansito.DevEnTransito.Infrastucture.Repositories.Candidate;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Test
{
    public class CandidateRepositoryTests
    {
        private readonly CandidateRepository _repository;
        private readonly ApplicationDbContext _context;

        public CandidateRepositoryTests()
        {
            // Crear una instancia de la base de datos en memoria
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);
            _repository = new CandidateRepository(_context);
        }

        [Fact]
        public async Task AddCandidateAsync_WithJobItRelation_ShouldAddCandidateAndSetRelation()
        {
            // Arrange
            var jobIt = new JobItEntity { Title = "Software Developer" };
            _context.Jobs.Add(jobIt);
            await _context.SaveChangesAsync();

            var candidate = new CandidateEntity
            {
                Name = "John Doe",
                LinkedIn = "https://linkedin.com/john.doe",
                ResumeUrl = "resume.pdf",
                JobItId = jobIt.Id
            };

            // Act
            await _repository.AddCandidateAsync(candidate);

            // Assert
            var addedCandidate = await _context.Candidates
                .Include(c => c.JobIt)
                .FirstOrDefaultAsync(c => c.Name == candidate.Name);

            addedCandidate.Should().NotBeNull();
            addedCandidate.JobIt.Should().BeEquivalentTo(jobIt);
        }


        [Fact]
        public async Task AddCandidateAsync_WithoutJobItRelation_ShouldAddCandidateAndSetNullRelation()
        {
            // Arrange
            var candidate = new CandidateEntity
            {
                //Id = 1,
                Name = "John Doe",
                ResumeUrl = "resume.pdf",
                LinkedIn = "https://linkedin.com/john.doe"
            };

            // Act
            var addedCandidateId = (await _repository.AddCandidateAsync(candidate)).Id;

            // Assert
            var addedCandidate = await _context.Candidates
                //.Include(c => c.JobIt)
                .FirstOrDefaultAsync(c => c.Id == addedCandidateId);

            addedCandidate.Should().NotBeNull();
            addedCandidate.JobIt.Should().BeNull();
        }



        [Fact]
        public async Task AddCandidateAsync_WithNonExistingJobItId_ShouldThrowException()
        {
            // Arrange
            var candidate = new CandidateEntity
            {
                Name = "John Doe",
                LinkedIn = "https://linkedin.com/john.doe",
                JobItId = int.MaxValue // Un Id que no existe en la base de datos
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(() => _repository.AddCandidateAsync(candidate));
        }
    }
}