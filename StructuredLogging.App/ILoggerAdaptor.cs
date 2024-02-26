using Microsoft.Extensions.Logging;

namespace StructuredLogging.App;

public interface ILoggerAdaptor<TType>
{
    void LogInformation(string? message, params object?[] args);

    void LogWarning(string? message, params object?[] args);

    void LogError(Exception? exception, string? message, params object?[] args);

    void LogCustom(long elapsedTime, TimeOnly currentTime,
      string className);
}