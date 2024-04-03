using BackendDevEnTansito.DevEnTransito.Domain.Enums;

namespace BackendDevEnTansito.DevEnTransito.Application.DTOs
{
    public class JobItDto
    {
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        public int CompanyId { get; set; }


    }
}
