using MediatR;

namespace LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public record GetLeaveTypeDetailQuery(int id):IRequest<LeaveTypeDetailDto>;