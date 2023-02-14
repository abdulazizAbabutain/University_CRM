namespace University_CRM.Domain.Common
{
    public class AuditEntity
    {
        public string? CreatedBy { get; private set; }
        public DateTimeOffset? CreatedDate { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTimeOffset? ModifiedDate { get; private set; }
        public string? DeletedBy { get; private set; }
        public DateTimeOffset? DeletedDate { get; private set; }
        public bool IsDeleted { get; private set; }

        public void AddEntity()
        {
            CreatedDate = DateTimeOffset.Now;
        }
        public void ModifiedEntity()
        {
            ModifiedDate = DateTimeOffset.Now;
        }
        public void DeletedEntity()
        {
            DeletedDate = DateTimeOffset.Now;
            IsDeleted= true;
        }
    }
}
