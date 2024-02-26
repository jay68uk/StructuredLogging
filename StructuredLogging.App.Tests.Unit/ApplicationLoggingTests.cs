using System.Xml.Serialization;
using NSubstitute;

namespace StructuredLogging.App.Tests.Unit;

public class ApplicationLoggingTests
{
  private readonly ApplicationLogging _sut;
  private readonly ILoggerAdaptor<ApplicationLogging> _logger = Substitute.For<ILoggerAdaptor<ApplicationLogging>>();

  public ApplicationLoggingTests()
  {
    _sut = new ApplicationLogging(_logger);
  }
  
  [Fact]
  public async Task RunAsync_ShouldLogInformation_WhenRan()
  {
    //Act
    await _sut.RunAsync(Array.Empty<string>());
    
    //Assert
    _logger.Received(1).LogInformation(Arg.Is("Application started,timer has been started: {TimerStatus}"), Arg.Any<bool>());
  }
  
  [Fact]
  public async Task RunAsync_ShouldLogWarning_WhenRan()
  {
    //Act
    await _sut.RunAsync(Array.Empty<string>());
    
    //Assert
    _logger.Received(1).LogWarning(Arg.Is("Application timestamp: {TimerElapsed}"), Arg.Any<long>());
  }
  
  [Fact]
  public async Task RunAsync_ShouldLogError_WhenRan()
  {
    //Act
    await _sut.RunAsync(Array.Empty<string>());
    
    //Assert
    _logger.Received(1).LogError(Arg.Any<TimeoutException>(),"Simulated timeout error of {TimeElapsed}ms in {ClassName}", Arg.Any<long>(), Arg.Any<string>());
  }
}