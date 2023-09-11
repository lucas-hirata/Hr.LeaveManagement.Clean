using Hr.LeaveManagement.Domain;

namespace Hr.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest?> GetLeaveResquestWithDetails(int id);
    Task<List<LeaveRequest>> GetLeaveResquestsWithDetails();
    Task<List<LeaveRequest>> GetLeaveResquestsWithDetails(string userId);
}