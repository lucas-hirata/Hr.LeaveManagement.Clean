using Hr.LeaveManagement.Application.Contracts.Persistence;
using Hr.LeaveManagement.Domain;
using Hr.LeaveManagement.Persistence.DatabaseContext;

namespace Hr.LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(HrDatabaseContext context) : base(context) { }
}
