using Hr.LeaveManagement.Application.Contracts.Persistence;
using Hr.LeaveManagement.Domain;
using Hr.LeaveManagement.Persistence.DatabaseContext;

using Microsoft.EntityFrameworkCore;

namespace Hr.LeaveManagement.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(HrDatabaseContext context) : base(context) { }

    public async Task<bool> IsLeaveTypeUnique(string name)
    {
        return await _context.LeaveTypes.AnyAsync(q => q.Name == name);
    }
}
