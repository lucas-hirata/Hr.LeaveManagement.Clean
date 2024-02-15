using Hr.LeaveManagement.Domain;
using Hr.LeaveManagement.Persistence.DatabaseContext;

using Microsoft.EntityFrameworkCore;

using Shouldly;

namespace Hr.LeaveManagement.Persistence.IntegrationTests;

public class HrDatabaseContextTests
{
    private readonly HrDatabaseContext _hrDatabaseContext;

    public HrDatabaseContextTests()
	{
		var dbOptions = new DbContextOptionsBuilder<HrDatabaseContext>()
			.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

		_hrDatabaseContext = new HrDatabaseContext(dbOptions);
	}

	[Fact]
	public async Task Save_SetDateCreatedValue()
	{
		// Arrange
		var leaveType = new LeaveType
		{
			Id = 1,
			DefaultDays = 1,
			Name = "Test",
		};

		// Act
		await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
        await _hrDatabaseContext.SaveChangesAsync();

		// Assert
		leaveType.CreatedAt.ShouldNotBeNull();
    }

    [Fact]
    public async Task Save_SetDateModifiedValue()
    {
        // Arrange
        var leaveType = new LeaveType
        {
            Id = 1,
            DefaultDays = 1,
            Name = "Test",
        };

        // Act
        await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
        await _hrDatabaseContext.SaveChangesAsync();

        // Assert
        leaveType.ModifiedAt.ShouldNotBeNull();
    }
}
