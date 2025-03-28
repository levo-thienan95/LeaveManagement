using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using DbContext = LeaveManagement.Persistence.DatabaseContext.DbContext;

namespace LeaveManagement.Persistence.Repositories;

public class LeaveTypeRepository: GenericRepositories<LeaveType>,ILeaveTypeRepository
{
    public LeaveTypeRepository(DbContext context) : base(context)
    {
        
    }

    public async Task<bool> LeaveTypeNameUnique(string name)
    {
        return await _context.LeaveTypes.AnyAsync(q => q.Name == name);
    }

    public async Task<bool> LeaveTypeMustExist(int id)
    {
        return await _context.LeaveTypes.AnyAsync(q => q.Id == id);
    }
}