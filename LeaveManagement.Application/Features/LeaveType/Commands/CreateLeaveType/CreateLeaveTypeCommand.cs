using System.Security.AccessControl;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommand:IRequest<int>
{
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
   
   public int DefaultDays { get; set; }
}