namespace BackendDevEnTansito.DevEnTransito.Domain.Entities
{
    public class CompanyEntity : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<JobItEntity> Jobs { get; set; }

    }
}
