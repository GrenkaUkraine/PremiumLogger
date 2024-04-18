namespace PremiumLogger
{
    public enum LogLevel
    {
        Debug = -1,

        Log = 0,
        Default = 0,

        Information = 1,
        Info = 1,

        Success = 2,

        Warning = 3,
        Warn = 3,

        Error = 4,

        Critical = 5,
    }

    public static class LogLevelExtensions
    {
        public static string ToLogLevelString(this LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Debug:
                    return "DEBUG";
                case LogLevel.Default:
                    return "LOG";
                case LogLevel.Information:
                    return "INFO";
                case LogLevel.Success:
                    return "SUCCESS";
                case LogLevel.Warning:
                    return "WARNING";
                case LogLevel.Error:
                    return "ERROR";
                case LogLevel.Critical:
                    return "CRITICAL";
                default:
                    return "UNKNOWN";
            }
        }

        public static string GetLogLevelColor(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Debug:
                    return LogColor.CYAN;
                case LogLevel.Information:
                    return LogColor.BLUE;
                case LogLevel.Success:
                    return LogColor.GREEN;
                case LogLevel.Warning:
                    return LogColor.YELLOW;
                case LogLevel.Error:
                    return LogColor.RED;
                case LogLevel.Critical:
                    return LogColor.RED + LogColor.BOLD;
                default:
                    return LogColor.NORMAL;
            }
        }
    }
}
