using BackendDevEnTansito.DevEnTransito.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendDevEnTansito.DevEnTransito.Infrastucture.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<JobItEntity> Jobs { get; set; }
        public DbSet<CandidateEntity> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Company only has relationships already defined in JobIt

            // Configuring JobIt with its relationship to Company
            modelBuilder.Entity<JobItEntity>()
                .HasOne(job => job.Company)
                .WithMany(company => company.Jobs)
                .HasForeignKey(job => job.CompanyId);


            // Configuring Candidate, assuming the relationship with JobIt
            modelBuilder.Entity<CandidateEntity>()
                .HasOne(candidate => candidate.JobIt)
                .WithMany(job => job.Candidates)
                .HasForeignKey(candidate => candidate.JobItId)
                .OnDelete(DeleteBehavior.Cascade); // Permite que los Candidatos se eliminen cuando se elimina un JobIt








        }

    }
}



