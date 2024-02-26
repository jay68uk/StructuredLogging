using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StructuredLogging.App;

var services = new ServiceCollection();

services.AddSingleton<ApplicationLogging>();
services.AddTransient(typeof(ILoggerAdaptor<>), typeof(LoggerAdaptor<>));

services.AddLogging(builder =>
{
  builder.AddJsonConsole(options =>
  {
    options.JsonWriterOptions = new JsonWriterOptions { Indented = true };
  });
});

var serviceProvider = services.BuildServiceProvider();

var application = serviceProvider.GetRequiredService<ApplicationLogging>();

await application.RunAsync(args);



