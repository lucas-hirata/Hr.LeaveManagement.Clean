using AutoMapper;

using Hr.LeaveManagement.Application.Contracts.Logging;
using Hr.LeaveManagement.Application.Contracts.Persistence;
using Hr.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using Hr.LeaveManagement.Application.MappingProfiles;
using Hr.LeaveManagement.Application.UnitTests.Mocks;

using Moq;

using Shouldly;

namespace Hr.LeaveManagement.Application.UnitTests.Features.LeaveTypes.Commands;

public class CreateLeaveTypeCommandHandlerTests
{
    private readonly Mock<ILeaveTypeRepository> _leaveTypeRepositoryMock;
    private IMapper _mapper;
    private Mock<IApiLogger<CreateLeaveTypeCommandHandler>> _mockApiLogger;

    public CreateLeaveTypeCommandHandlerTests()
    {
        var mapperConfig = new MapperConfiguration(c => c.AddProfile<LeaveTypeProfile>());
        _mapper = mapperConfig.CreateMapper();
        _leaveTypeRepositoryMock = MockLeaveTypeRepository.GetMockLeaveTypeRepository();
        _mockApiLogger = new Mock<IApiLogger<CreateLeaveTypeCommandHandler>>();
    }

    [Fact]
    public async Task CreateLeaveTypeTest()
    {
        CreateLeaveTypeCommandHandler handler = new(_mapper, _leaveTypeRepositoryMock.Object);

        var result = await handler.Handle(new CreateLeaveTypeCommand { Name = "Test Create", DefaultDays = 5 }, CancellationToken.None);

        result.ShouldBe(4);

        var data = await _leaveTypeRepositoryMock.Object.GetByIdAsync(4);
        data.ShouldNotBeNull();
    }
}
