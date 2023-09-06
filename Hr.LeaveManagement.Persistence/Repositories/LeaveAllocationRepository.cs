using Hr.LeaveManagement.Application.Contracts.Persistence;
using Hr.LeaveManagement.Domain;
using Hr.LeaveManagement.Persistence.DatabaseContext;

namespace Hr.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(HrDatabaseContext context) : base(context) { }
}
