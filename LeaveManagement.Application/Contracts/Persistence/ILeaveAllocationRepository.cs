using LeaveManagement.Domain;

namespace LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveAllocationRepository: IGenericRepository<LeaveAllocation>
{
    Task<LeaveAllocation> GetLeaveAllocationDetails(int id);
    Task<List<LeaveAllocation>> GetListLeavesAllocationDetails();
    Task<List<LeaveAllocation>> GetListLeavesAllocationDetailsByUser(int userId);
    Task<bool> AllocationExist(int id, int leaveTypeId, int period);
    Task AddAllocation(List<LeaveAllocation> leaveAllocations);
    Task<LeaveAllocation> GetUserAllocation(int userId, int leaveTypeId);
}