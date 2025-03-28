using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.AccessControl;
using LeaveManagement.Domain.Common;

namespace LeaveManagement.Domain;

public class LeaveType:BaseEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public int DefaultDays { get; set; }
}