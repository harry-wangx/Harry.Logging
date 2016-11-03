using System;
using System.Collections.Generic;
using System.Text;

namespace Harry.Logging
{
    internal sealed class Logger : ILogger
    {

        private readonly LoggerFactory _loggerFactory;
        private readonly string _name;
        /*这个项目是参照Microsoft.Extensions.Logging写的,原项目中这里使用的ILogger数组,
        然后通过Array.Resize来给数组扩容,因为性能不如List高,所以替换为如下代码
        */
        private List<ILogger> _loggers;

        public Logger(LoggerFactory loggerFactory, string name)
        {
            _loggerFactory = loggerFactory;
            _name = name;

            var providers = loggerFactory.GetProviders();
            if (providers.Length > 0)
            {
                _loggers = new List<ILogger>(providers.Length);
                for (var index = 0; index < providers.Length; index++)
                {
                    _loggers.Add( providers[index].CreateLogger(name));
                    
                }
            }
        }


        public void Log(LogLevel logLevel, EventId eventId, Exception exception, string message)
        {
            if (_loggers == null || _loggers.Count <= 0)
            {
                return;
            }
            List<Exception> exceptions = null;

            foreach (var logger in _loggers)
            {
                try
                {
                    logger.Log(logLevel, eventId, exception, message);
                }
                catch (Exception ex)
                {
                    if (exceptions == null)
                    {
                        exceptions = new List<Exception>();
                    }

                    exceptions.Add(ex);
                }
            }

            if (exceptions != null && exceptions.Count > 0)
            {
#if NET20 || NET35
                throw Harry.Logging.Common.Throw.MergeExceptions(exceptions);
#else

                throw new AggregateException(
                    message: "An error occurred while writing to logger(s).", innerExceptions: exceptions);
#endif
            }
        }

        public void Dispose()
        {
            if (_loggers != null && _loggers.Count > 0)
            {
                List<Exception> exceptions = null;
                foreach (var item in _loggers)
                {
                    try
                    {
                        item.Dispose();
                    }
                    catch (Exception ex)
                    {
                        if (exceptions == null)
                        {
                            exceptions = new List<Exception>();
                        }

                        exceptions.Add(ex);
                    }
                }

                if (exceptions != null && exceptions.Count > 0)
                {
#if NET20 || NET35
                    throw Harry.Logging.Common.Throw.MergeExceptions(exceptions);
#else
                    throw new AggregateException(
                message: "An error occurred while writing to logger(s).",
                innerExceptions: exceptions);
#endif
                }
            }
        }


        public bool IsEnabled(LogLevel logLevel)
        {
            if (_loggers == null || _loggers.Count <= 0)
            {
                return false;
            }

            List<Exception> exceptions = null;
            foreach (var logger in _loggers)
            {
                try
                {
                    if (logger.IsEnabled(logLevel))
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    if (exceptions == null)
                    {
                        exceptions = new List<Exception>();
                    }

                    exceptions.Add(ex);
                }
            }

            if (exceptions != null && exceptions.Count > 0)
            {
#if NET20 || NET35
                throw Harry.Logging.Common.Throw.MergeExceptions(exceptions);
#else
                throw new AggregateException(
            message: "An error occurred while writing to logger(s).",
            innerExceptions: exceptions); 
#endif
            }

            return false;
        }


        internal void AddProvider(ILoggerProvider provider)
        {
            var logger = provider.CreateLogger(_name);
            if (_loggers == null)
            {
                _loggers = new List<ILogger>();
            }
            _loggers.Add(logger);
        }


    }
}
