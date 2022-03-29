using NLog;
using NLog.Web;
using System;
using System.Text;

namespace Blog.Common.Helpers
{
    public class BlogLogger
    {

        private static Logger _logger = NLogBuilder.ConfigureNLog($"nlog.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.config").GetCurrentClassLogger();
        public static void Info(string message, string componentName, string methodName)
        {
            _logger.Info(FormatLogEntry(message, componentName, methodName));
        }
        public static void Warn(string message, string componentName, string methodName)
        {
            _logger.Warn(FormatLogEntry(message, componentName, methodName));
        }
        public static void Error(System.Exception ex, string message = null)
        {
            _logger.Error(ex, message);
        }
        private static string FormatLogEntry(
                       string message,
                       string componentName, string methodName)
        {
            StringBuilder logEntry = new StringBuilder();
            logEntry.AppendFormat("ClassName={0} ", componentName);
            logEntry.AppendFormat("Method={0} ", methodName);
            logEntry.AppendFormat("Message={0}", message);
            logEntry.AppendLine();
            return logEntry.ToString();
        }

    }
}
