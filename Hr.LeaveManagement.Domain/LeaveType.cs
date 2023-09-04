using Hr.LeaveManagement.Domain.Common;

namespace Hr.LeaveManagement.Domain;

public record LeaveType : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}