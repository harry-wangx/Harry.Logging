using NLog.Config;
using System;
using _Nlog = NLog;
namespace Harry.Logging.NLog
{
    public static class LogManager
    {
#if !NET20
        /// <summary>
        /// 指定Nlog配置文件路径
        /// </summary>
        /// <param name="fullFilePath">配置文件完整路径</param>
        public static void ConfigureNLog(string fullFilePath)
        {
            _Nlog.LogManager.Configuration = new XmlLoggingConfiguration(fullFilePath, true);
        }
#endif
    }
}
