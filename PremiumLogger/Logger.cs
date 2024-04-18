namespace PremiumLogger
{
    public class Logger
    {
        public string ProgramName { get; set; }
        public string ProgramNameColor { get; set; }
        public bool LogToFile { get; set; } = false;
        public string LogFilePath { get; private set; }
        public bool IsDebug { get; set; }

        public Logger(string programName = "PremiumLogger", string logFilePath = "", bool isDebug = false, string? programNameColor = null)
        {
            ProgramName = programName;
            LogFilePath = logFilePath;
            if (!string.IsNullOrEmpty(logFilePath))
            {
                SetLogFilePath(logFilePath);
                LogToFile = true;
            }
            IsDebug = isDebug;
            ProgramNameColor = programNameColor != null ? programNameColor : LogColor.GREY;
        }

        public void Log(string message, LogLevel logLevel, object? caller = null)
        {
            string logLevelColor = logLevel == LogLevel.Critical ? LogColor.RED : LogLevelExtensions.GetLogLevelColor(logLevel);
            string logLevelTitle = logLevel.ToLogLevelString();
            string currentDateTime = GetCurrentDateTime();

            string C = logLevel != LogLevel.Critical ? LogColor.NORMAL + LogColor.NOREVERSE + LogColor.NOBOLD + LogColor.NOUNDERLINE : LogColor.RED + LogColor.NOREVERSE + LogColor.NOBOLD + LogColor.NOUNDERLINE;

            string GREY = logLevel != LogLevel.Critical ? LogColor.GREY : LogColor.RED;


            string callerInfo = caller != null ? $"{C + GREY}[{caller}{C + GREY}]{C} " : "";
            string formattedLog = $"{C + GREY}[{ProgramNameColor + ProgramName}{C + GREY}]{C} " +
                                  $"{C + GREY}[{logLevelColor + logLevelTitle}{C + GREY}]{C} " +
                                  $"{C + GREY}[{currentDateTime}{GREY}]{C} " +
                                  $"{callerInfo}{message}{(logLevel == LogLevel.Critical ? LogColor.NORMAL + LogColor.NOREVERSE + LogColor.NOBOLD + LogColor.NOUNDERLINE : C)}";

            string noFormattedCallerInfo = caller != null ? $"[{caller}] " : "";
            string noFormattedLog = $"[{ProgramName}] " +
                                  $"[{logLevelTitle}] " +
                                  $"[{currentDateTime}] " +
                                  $"{noFormattedCallerInfo}{message}";

            Console.WriteLine(formattedLog);

            if (LogToFile)
            {
                LogToFileInternal(noFormattedLog);
            }
        }

        public void Log(string message, object caller)
        {
            Log(message, LogLevel.Default, caller);
        }

        public void Log(string message)
        {
            Log(message, LogLevel.Default);
        }

        private static string GetCurrentDateTime()
        {
            return $"{DateTime.Now:HH:mm:ss}";
        }

        private void LogToFileInternal(string message)
        {
            try
            {
                if (string.IsNullOrEmpty(LogFilePath))
                {
                    LogFilePath = Path.Combine(Environment.CurrentDirectory, "log.txt");
                }

                using StreamWriter writer = File.AppendText(LogFilePath);
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd} : {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while writing to log file: {ex.Message}");
            }
        }

        public void SetLogFilePath(string logFilePath)
        {
            if (Path.IsPathRooted(logFilePath))
            {
                LogFilePath = logFilePath;
            }
            else
            {
                LogFilePath = Path.Combine(Environment.CurrentDirectory, logFilePath);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Logger logger &&
                   ProgramName == logger.ProgramName &&
                   ProgramNameColor == logger.ProgramNameColor &&
                   LogToFile == logger.LogToFile &&
                   LogFilePath == logger.LogFilePath &&
                   IsDebug == logger.IsDebug;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProgramName, ProgramNameColor, LogToFile, LogFilePath, IsDebug);
        }
    }
}
