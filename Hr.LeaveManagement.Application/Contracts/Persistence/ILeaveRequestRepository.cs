using Hr.LeaveManagement.Domain;

namespace Hr.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository<T> : IGenericRepository<LeaveRequest>
{
}