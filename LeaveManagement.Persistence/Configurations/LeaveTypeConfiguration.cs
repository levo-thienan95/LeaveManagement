using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Persistence.Configurations;

public class LeaveTypeConfiguration:IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.HasData(
            new LeaveType
            {
                Id = 1,
                Name = "Work From Home",
                DefaultDays = 5
            });
        
        builder.Property(q => q.Name).HasMaxLength(100).IsRequired();
        
    }
}