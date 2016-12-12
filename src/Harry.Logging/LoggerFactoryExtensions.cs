using System;
#if !COREFX
using System.Diagnostics;
#endif

namespace Harry.Logging
{
    /// <summary>
    /// ILoggerFactory
    /// </summary>
    public static class LoggerFactoryExtensions
    {

        public static ILogger CreateLogger(
#if !NET20
            this
#endif
            ILoggerFactory factory, Type type)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return factory.CreateLogger(Harry.Logging.Common.TypeNameHelper.GetTypeDisplayName(type));
        }

#if !COREFX
        public static ILogger GetCurrentClassLogger(
#if !NET20
            this
#endif
            ILoggerFactory factory)
        {
            var stackFrame = new StackFrame(1, false);
            return CreateLogger(factory, stackFrame.GetMethod().DeclaringType);
        }
#endif
    }

}

