namespace Hr.LeaveManagement.Application.Contracts.Logging;

public interface IApiLogger<T>
{
    void LogInformation(string message, params object[] args);
    void LogWarning(string message, params object[] args);
}
