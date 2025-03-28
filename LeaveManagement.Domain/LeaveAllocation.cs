using LeaveManagement.Domain.Common;

namespace LeaveManagement.Domain;

public class LeaveAllocation:BaseEntity
{
    public int Id { get; set; }
    
    public int NumberOfDays { get; set; }
    
    public LeaveType? LeaveType { get; set; }
    
    public int LeaveTypeId { get; set; }
    
    public int Period { get; set; }
    
    public int EmployeedId { get; set; }
}
