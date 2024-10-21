using CarModelManagements.Services;
using Microsoft.Extensions.Logging;

namespace CarManagement.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(ILogger<NotificationService> logger)
        {
            _logger = logger;
        }

        public void Notify(string message)
        {
            // For now, we will just log the message.
            _logger.LogInformation($"Notification: {message}");
        }
    }
}