using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University_CRM.Domain.Entities;

namespace University_CRM.Infrastructure.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(p => p.NameArabic).HasMaxLength(100);
            builder.Property(p => p.NameEnglish).HasMaxLength(100);
            builder.Property(p => p.DescriptionArabic).HasMaxLength(1000);
            builder.Property(p => p.DescriptionEnglish).HasMaxLength(1000);
            builder.Property(p => p.CreatedBy).HasMaxLength(100);
            builder.Property(p => p.ModifiedBy).HasMaxLength(100);
            builder.Property(p => p.DeletedBy).HasMaxLength(100);

            builder.HasKey(key => key.DepartmentId);

        }
    }
}
