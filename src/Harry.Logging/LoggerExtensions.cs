

using System;
using System.Collections.Generic;
using System.Globalization;
namespace Harry.Logging
{
    public static class LoggerExtensions
    {
        //------------------------------------------TRACE------------------------------------------//

        public static void Trace(
#if !NET20
            this
#endif
            ILogger logger, string message, EventId? eventId = null, Exception exception = null)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Trace, eventId == null ? 0 : eventId.Value, exception, message);
        }

        public static void Trace(
#if !NET20
            this
#endif
            ILogger logger,

#if NET20 || NET35
    LogFunc<string>
#else
    Func<string>
#endif
        func, EventId? eventId = null, Exception exception = null)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            if (logger.IsEnabled(LogLevel.Trace))
            {
                logger.Log(LogLevel.Trace, eventId == null ? 0 : eventId.Value, exception, func());
            }
        }


        //------------------------------------------DEBUG------------------------------------------//

        public static void Debug(
#if !NET20
            this
#endif
            ILogger logger, string message, EventId? eventId = null, Exception exception = null)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Debug, eventId == null ? 0 : eventId.Value, exception, message);
        }

        public static void Debug(
#if !NET20
            this
#endif
            ILogger logger,

#if NET20 || NET35
    LogFunc<string>
#else
    Func<string>
#endif
        func, EventId? eventId = null, Exception exception = null)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.Log(LogLevel.Debug, eventId == null ? 0 : eventId.Value, exception, func());
            }
        }


        //------------------------------------------Info------------------------------------------//


        public static void Info(
#if !NET20
            this
#endif
            ILogger logger, string message, EventId? eventId = null, Exception exception = null)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Info, eventId == null ? 0 : eventId.Value, exception, message);
        }

        public static void Info(
#if !NET20
            this
#endif
            ILogger logger,

#if NET20 || NET35
    LogFunc<string>
#else
    Func<string>
#endif
        func, EventId? eventId = null, Exception exception = null)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            if (logger.IsEnabled(LogLevel.Info))
            {
                logger.Log(LogLevel.Info, eventId == null ? 0 : eventId.Value, exception, func());
            }
        }

        //------------------------------------------Warn------------------------------------------//

        public static void Warn(
#if !NET20
            this
#endif
            ILogger logger, string message, EventId? eventId = null, Exception exception = null)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Warn, eventId == null ? 0 : eventId.Value, exception, message);
        }

        public static void Warn(
#if !NET20
            this
#endif
            ILogger logger,

#if NET20 || NET35
    LogFunc<string>
#else
    Func<string>
#endif
        func, EventId? eventId = null, Exception exception = null)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            if (logger.IsEnabled(LogLevel.Warn))
            {
                logger.Log(LogLevel.Warn, eventId == null ? 0 : eventId.Value, exception, func());
            }
        }

        //------------------------------------------ERROR------------------------------------------//

        public static void Error(
#if !NET20
            this
#endif
            ILogger logger, string message, EventId? eventId = null, Exception exception = null)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Error, eventId == null ? 0 : eventId.Value, exception, message);
        }

        public static void Error(
#if !NET20
            this
#endif
            ILogger logger,

#if NET20 || NET35
    LogFunc<string>
#else
    Func<string>
#endif
        func, EventId? eventId = null, Exception exception = null)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            if (logger.IsEnabled(LogLevel.Error))
            {
                logger.Log(LogLevel.Error, eventId == null ? 0 : eventId.Value, exception, func());
            }
        }

        //------------------------------------------Fatal------------------------------------------//

        public static void Fatal(
#if !NET20
            this
#endif
            ILogger logger, string message, EventId? eventId = null, Exception exception = null)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Fatal, eventId == null ? 0 : eventId.Value, exception, message);
        }

        public static void Fatal(
#if !NET20
            this
#endif
            ILogger logger,

#if NET20 || NET35
    LogFunc<string>
#else
    Func<string>
#endif
        func, EventId? eventId = null, Exception exception = null)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            if (logger.IsEnabled(LogLevel.Fatal))
            {
                logger.Log(LogLevel.Fatal, eventId == null ? 0 : eventId.Value, exception, func());
            }
        }
    }

}

