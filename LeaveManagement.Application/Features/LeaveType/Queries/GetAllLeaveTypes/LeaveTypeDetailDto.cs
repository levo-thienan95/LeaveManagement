namespace LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class LeaveTypeDetailDto
{
    public int Id { get; set; }
    
    public string Name { get; set; } = String.Empty;
    
    public int DefaultDays { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime? ModifiedTime { get; set; }
}