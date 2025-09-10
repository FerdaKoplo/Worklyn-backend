namespace Worklyn_backend.Domain.Entities
{
    public class RecruitmentCandidate : BaseEntity
    {
        public Guid CandidateId { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ResumeUrl { get; set; }
        public string Status { get; set; }
    }
}
