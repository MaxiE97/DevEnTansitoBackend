using System.ComponentModel.DataAnnotations;

namespace BackendDevEnTansito.DevEnTransito.Application.DTOs
{
    public class CandidateDto
    {
        public string Name { get; set; }
        public string LinkedIn { get; set; }
        public string ResumeUrl { get; set; }
        public int MatchCompany { get; set; }
        public DateTime ScheduledInterviewDate { get; set; }

        [MaxLength(10485760)] // 10 MB en bytes 
        public byte[]? CV { get; set; }
        public string Notes { get; set; }
        public bool IsDone { get; set; } = false;

        public int JobItId { get; set; }

    }
}
