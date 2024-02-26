using Microsoft.Extensions.Logging;

namespace StructuredLogging.App;

public class LoggerAdaptor<TType> : ILoggerAdaptor<TType>
{
  private readonly ILogger<TType> _logger;

  public LoggerAdaptor(ILogger<TType> logger)
  {
    _logger = logger;
  }
  public void LogInformation(string? message, params object?[] args)
  {
    _logger.LogInformation(message,args);
  }

  public void LogWarning(string? message, params object?[] args)
  {
    _logger.LogWarning(message, args);
  }

  public void LogError(Exception? exception, string? message, params object?[] args)
  {
    _logger.LogError(exception, message,args);
  }

  public void LogCustom(long elapsedTime, TimeOnly currentTime, string className)
  {
    _logger.LogCustomInformation(elapsedTime, currentTime, className);
  }
}