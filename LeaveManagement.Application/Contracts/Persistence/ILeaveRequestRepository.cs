using LeaveManagement.Domain;

namespace LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository: IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestDetail(int id);
    Task<List<LeaveRequest>> GetListLeavesRequest();
    Task<List<LeaveRequest>> GetListLeavesRequestByUserId(string userId);
}