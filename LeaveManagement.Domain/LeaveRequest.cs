using LeaveManagement.Domain.Common;

namespace LeaveManagement.Domain;

public class LeaveRequest: BaseEntity
{
    public int Id { get; set; }

    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public LeaveType? LeaveType { get; set; }
    
    public int LeaveTypeId { get; set; }
    
    public DateTime DateRequested { get; set; }
    
    public string? RequestComment { get; set; }
    
    public bool IsApproved { get; set; } 
    
    public bool IsRejected { get; set; } 
    
    public string RequestingEmployeeId { get; set; } =string.Empty;
}