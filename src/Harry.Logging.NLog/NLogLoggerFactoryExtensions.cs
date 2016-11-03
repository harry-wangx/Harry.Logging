
using Harry.Logging.NLog;
using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Harry.Logging
{
    public static class NLogLoggerFactoryExtensions
    {
        /// <summary>
        /// Enable NLog as logging provider for Harry.Logging.
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="fullFilePath"></param>
        /// <returns></returns>
        public static ILoggerFactory AddNLog(
#if !NET20
            this
#endif
            ILoggerFactory factory, string fullFilePath = null)
        {
#if !NET20
            //ignore this
            LogManager.AddHiddenAssembly(Assembly.Load(new AssemblyName("Harry.Logging")));

#if !NET20 && !NET35 && !NET40
            LogManager.AddHiddenAssembly(typeof(NLogLoggerFactoryExtensions).GetTypeInfo().Assembly);
#else
            LogManager.AddHiddenAssembly(Assembly.Load(new AssemblyName("Harry.Logging.NLog")));
#endif
#endif

            if (!string.IsNullOrEmpty(fullFilePath))
            {
                LogManager.Configuration = new XmlLoggingConfiguration(fullFilePath, true);
            }

            using (var provider = new NLogLoggerProvider())
            {
                factory.AddProvider(provider);
            }
            return factory;
        }

    }
}
