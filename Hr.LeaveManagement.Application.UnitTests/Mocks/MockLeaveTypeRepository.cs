using Hr.LeaveManagement.Application.Contracts.Persistence;
using Hr.LeaveManagement.Domain;

using Moq;

namespace Hr.LeaveManagement.Application.UnitTests.Mocks;

public class MockLeaveTypeRepository
{
    public static Mock<ILeaveTypeRepository> GetMockLeaveTypeRepository()
    {
        var leaveTypes = new List<LeaveType>
        {
            new() { Id = 1, DefaultDays = 10, Name = "Test Vacation"},
            new() { Id = 2, DefaultDays = 15, Name = "Test Sick"},
            new() { Id = 3, DefaultDays = 15, Name = "Test Maternity"}
        };

        var mockRepo = new Mock<ILeaveTypeRepository>();
        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(leaveTypes);

        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((int id) => leaveTypes.FirstOrDefault(l => l.Id == id));

        mockRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveType>()))
            .Returns((LeaveType leaveType) =>
            {
                leaveType.Id = leaveTypes.Count + 1;
                leaveTypes.Add(leaveType);
                return Task.CompletedTask;
            });

        mockRepo.Setup(r => r.IsLeaveTypeUnique(It.IsAny<string>()))
            .ReturnsAsync((string name) => !leaveTypes.Any(l => l.Name == name));

        return mockRepo;
    }
}
