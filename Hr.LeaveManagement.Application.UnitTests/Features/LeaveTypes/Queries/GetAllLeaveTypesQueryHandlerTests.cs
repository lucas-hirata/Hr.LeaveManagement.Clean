using AutoMapper;

using Hr.LeaveManagement.Application.Contracts.Logging;
using Hr.LeaveManagement.Application.Contracts.Persistence;
using Hr.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using Hr.LeaveManagement.Application.MappingProfiles;
using Hr.LeaveManagement.Application.UnitTests.Mocks;

using Moq;

using Shouldly;

namespace Hr.LeaveManagement.Application.UnitTests.Features.LeaveTypes.Queries;

public class GetAllLeaveTypesQueryHandlerTests
{
    private readonly Mock<ILeaveTypeRepository> _leaveTypeRepositoryMock;
    private IMapper _mapper;
    private Mock<IApiLogger<GetAllLeaveTypesQueryHandler>> _mockApiLogger;

    public GetAllLeaveTypesQueryHandlerTests()
    {
        _leaveTypeRepositoryMock = MockLeaveTypeRepository.GetMockLeaveTypeRepository();
        var mapperConfig = new MapperConfiguration(c => c.AddProfile<LeaveTypeProfile>());
        _mapper = mapperConfig.CreateMapper();
        _mockApiLogger = new Mock<IApiLogger<GetAllLeaveTypesQueryHandler>>();
    }

    [Fact]
    public async Task GetAllLeaveTypesTest()
    {
        GetAllLeaveTypesQueryHandler handler = new (
            _mapper,
            _leaveTypeRepositoryMock.Object,
            _mockApiLogger.Object);

        var result = await handler.Handle(new GetAllLeaveTypesQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<LeaveTypeDto>>();
        result.Count().ShouldBe(3);
    }
}
