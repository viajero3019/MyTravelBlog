using Microsoft.Extensions.Logging;
using MyTravelBlog.ApplicationCore.Interfaces;

namespace MyTravelBlog.Infrastructure.Logging;

public class AppLogger<T> : IAppLogger<T>
{
    private readonly ILogger<T>_logger;

    public AppLogger(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<T>();
    }

    public void LogInformation(string message, params object[] args)
    {
        _logger.LogInformation(message, args);
    }

    public void LogWarning(string message, params object[] args)
    {
        _logger.LogWarning(message, args);
    }
}