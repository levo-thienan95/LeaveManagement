using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using DbContext = LeaveManagement.Persistence.DatabaseContext.DbContext;

namespace LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository:GenericRepositories<LeaveRequest>,ILeaveRequestRepository
{
    public LeaveRequestRepository(DbContext context) : base(context)
    {
    }

    public Task<LeaveRequest> GetLeaveRequestDetail(int id)
    {
        return _context.LeaveRequests.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<List<LeaveRequest>> GetListLeavesRequest()
    {
        return _context.LeaveRequests.Include(q => q.LeaveType).ToListAsync();
    }

    public Task<List<LeaveRequest>> GetListLeavesRequestByUserId(string userId)
    {
        return _context.LeaveRequests
            .Where(x => x.RequestingEmployeeId == userId)
            .Include(q => q.LeaveType)
            .ToListAsync();
    }
}