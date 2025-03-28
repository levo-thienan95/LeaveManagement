using LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using LeaveManagement.Domain;

namespace LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveTypeRepository:IGenericRepository<LeaveType>
{
   Task<bool> LeaveTypeNameUnique(string name);

   Task<bool> LeaveTypeMustExist(int id);
}