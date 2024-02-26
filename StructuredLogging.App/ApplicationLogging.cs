using System.Diagnostics;

namespace StructuredLogging.App;

public class ApplicationLogging
{
  private readonly ILoggerAdaptor<ApplicationLogging> _logger;

  public ApplicationLogging(ILoggerAdaptor<ApplicationLogging> logger)
  {
    _logger = logger;
  }

  public async Task RunAsync(string[] args)
  {
    var timer = SimpleLogInformation();

    await Task.Delay(1000);
    
    SimpleLogWarning(timer);
    
    await Task.Delay(1000);
    
    SimpleLogError(timer);
    
    await Task.Delay(1000);

    SourceGeneratedLog(timer, TimeOnly.FromDateTime(DateTime.Now), nameof(ApplicationLogging));
  }

  private void SourceGeneratedLog(Stopwatch timer, TimeOnly fromDateTime, string applicationLoggingName)
  {
    _logger.LogCustom(timer.ElapsedMilliseconds,fromDateTime,applicationLoggingName);
  }

  private void SimpleLogError(Stopwatch timer)
  {
    _logger.LogError(new TimeoutException("App timed out!"), "Simulated timeout error of {TimeElapsed}ms in {ClassName}",
      timer.ElapsedMilliseconds, nameof(ApplicationLogging));
  }

  private void SimpleLogWarning(Stopwatch timer)
  {
    _logger.LogWarning("Application timestamp: {TimerElapsed}", timer.ElapsedMilliseconds);
  }

  private Stopwatch SimpleLogInformation()
  {
    var timer = Stopwatch.StartNew();
    _logger.LogInformation("Application started,timer has been started: {TimerStatus}", timer.IsRunning);
    return timer;
  }
}