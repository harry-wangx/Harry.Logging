using System;
using System.Collections.Generic;
using System.Text;

namespace Harry.Logging.Common
{
    static class Throw
    {
        /// <summary>
        /// 合并多个异常
        /// </summary>
        /// <param name="exceptions"></param>
        public static Exception MergeExceptions(IEnumerable<Exception> exceptions)
        {
            StringBuilder sb = new StringBuilder(1024);
            foreach (var item in exceptions)
            {
                sb.Append(item.Message
                    + Environment.NewLine
                    + item.StackTrace
                    + Environment.NewLine
                    + "----------------------------------------------------"
                    + Environment.NewLine);
            }
            return new Exception(sb.ToString());
        }
    }
}
