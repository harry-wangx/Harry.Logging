
using Harry.Logging.Log4Net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Harry.Logging
{
    public static class Log4NetLoggerFactoryExtensions
    {
        /// <summary>
        /// Enable Log4Net as logging provider for Harry.Logging.
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="fullFilePath"></param>
        /// <returns></returns>
        public static ILoggerFactory AddLog4Net(
#if !NET20
            this
#endif
            ILoggerFactory factory, string fullFilePath = null)
        {

            if (!string.IsNullOrEmpty(fullFilePath))
            {
                XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(fullFilePath));
            }

            using (var provider = new Log4NetLoggerProvider())
            {
                factory.AddProvider(provider);
            }
            return factory;
        }

    }
}
