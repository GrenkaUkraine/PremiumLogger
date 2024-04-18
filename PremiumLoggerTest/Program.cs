using PremiumLogger;

public class Program
{
    private static void Main(string[] args)
    {
        Logger logger = new("LoggerTest")
        {
            LogToFile = true
        };

        logger.Log("test log");
        logger.Log("test error log", LogLevel.Error);
        logger.Log("test info log with caller", LogLevel.Info, new Program());
        logger.Log("test critical log with caller", LogLevel.Critical, new Program());
    }
}
