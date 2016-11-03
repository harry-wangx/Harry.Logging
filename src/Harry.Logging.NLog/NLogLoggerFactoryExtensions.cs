
using Harry.Logging.NLog;
using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Reflection;
using _Nlog = NLog;

namespace Harry.Logging
{
    public static class NLogLoggerFactoryExtensions
    {

        public static ILoggerFactory AddNLog(
#if !NET20
            this
#endif
            ILoggerFactory factory, string configurationFilePath = null)
        {
#if !NET20
            //ignore this
            _Nlog.LogManager.AddHiddenAssembly(Assembly.Load(new AssemblyName("Harry.Logging")));

    #if !NET20 && !NET35 && !NET40
            _Nlog.LogManager.AddHiddenAssembly(typeof(NLogLoggerFactoryExtensions).GetTypeInfo().Assembly);
    #else
            _Nlog.LogManager.AddHiddenAssembly(Assembly.Load(new AssemblyName("Harry.Logging.NLog")));
    #endif
#endif

            using (var provider = new NLogLoggerProvider())
            {
                factory.AddProvider(provider);
            }
            return factory;
        }


    }
}
