using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using DbContext = LeaveManagement.Persistence.DatabaseContext.DbContext;

namespace LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepositories<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(DbContext context) : base(context)
    {
    }

    public async Task<LeaveAllocation> GetLeaveAllocationDetails(int id)
    {
        return await _context.LeaveAllocations.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<LeaveAllocation>> GetListLeavesAllocationDetails()
    {
        return await _context.LeaveAllocations.Include(x => x.LeaveType).AsNoTracking().ToListAsync();
    }

    public async Task<List<LeaveAllocation>> GetListLeavesAllocationDetailsByUser(int userId)
    {
        return await _context.LeaveAllocations.Where(x => x.EmployeedId == userId).Include(x => x.LeaveType).ToListAsync();
    }

    public async Task<bool> AllocationExist(int userId, int leaveTypeId, int period)
    {
        return await _context.LeaveAllocations.AnyAsync(x => x.EmployeedId == userId
                                                             && x.LeaveTypeId == leaveTypeId
                                                             && x.Period == period);
    }

    public async Task AddAllocation(List<LeaveAllocation> leaveAllocations)
    {
        await _context.LeaveAllocations.AddRangeAsync(leaveAllocations);
    }

    public Task<LeaveAllocation> GetUserAllocation(int userId, int leaveTypeId)
    {
        return _context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeedId == userId && q.LeaveTypeId == leaveTypeId);
    }
}