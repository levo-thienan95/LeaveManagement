namespace LeaveManagement.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifiedTime  { get; set; }
}