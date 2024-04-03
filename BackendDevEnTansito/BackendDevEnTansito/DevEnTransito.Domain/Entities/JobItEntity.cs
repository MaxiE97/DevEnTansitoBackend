using BackendDevEnTansito.DevEnTransito.Domain.Enums;

namespace BackendDevEnTansito.DevEnTransito.Domain.Entities
{
    public class JobItEntity : BaseEntity 
    {
        public string Title {  get; set; }
        
        public JobLevel Level { get; set; }



        //Relations
        public int CompanyId {  get; set; }
        public CompanyEntity Company { get; set; }
        
        public ICollection<CandidateEntity> Candidates { get; set; }

    }
}
