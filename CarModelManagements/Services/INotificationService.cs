namespace CarModelManagements.Services
{
    /// <summary>
    /// Defines a contract for notification services.
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Sends a notification with the specified message.
        /// </summary>
        /// <param name="message">The message to be sent in the notification.</param>
        void Notify(string message);
    }
}
