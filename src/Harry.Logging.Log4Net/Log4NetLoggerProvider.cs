
namespace Harry.Logging.Log4Net
{
    /// <summary>
    /// Provider logger for Log4Net.
    /// </summary>
    public class Log4NetLoggerProvider : Logging.ILoggerProvider
    {
        /// <summary>
        /// <see cref="Log4NetLoggerProvider"/> with default options.
        /// </summary>
        public Log4NetLoggerProvider()
        {
        }

        /// <summary>
        /// Create a logger with the name <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Name of the logger to be created.</param>
        /// <returns>New Logger</returns>
        public Logging.ILogger CreateLogger(string name)
        {
            return new Log4NetLogger(log4net.LogManager.GetLogger(name));
        }

        /// <summary>
        /// Cleanup
        /// </summary>
        public void Dispose()
        {
        }
    }
}


