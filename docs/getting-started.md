# Getting Started with PremiumLogger

Welcome to the `PremiumLogger` documentation! This guide will help you get started with using the `PremiumLogger` library to work with logging.

## Installation

To use `PremiumLogger` in your project, you need to install it first. There are a couple of ways to do this:

### NuGet Package Manager

You can install `PremiumLogger` using the **NuGet Package Manager**. Open the **Package Manager Console** and run the following command:

```sh
Install-Package PremiumLogger
```

## Basic Usage

Here's a simple example of how to use `PremiumLogger` in your application:

```cscsharp
using PremiumLogger;

// Create a logger instance
Logger logger = new Logger("MyProgram", "log.txt", isDebug: true);

// Log messages
logger.Log("This is a debug message", LogLevel.Debug);
logger.Log("This is an information message", LogLevel.Information);
logger.Log("This is a warning message", LogLevel.Warning);
logger.Log("This is an error message", LogLevel.Error);
logger.Log("This is a critical message", LogLevel.Critical);
```

## Next Steps

Congratulations! You've successfully installed `PremiumLogger` and learned the basics of using it in your application. Now you can explore more advanced features and functionalities provided by the library to suit your needs.

For more information about available [methods](methods.md), [log-level-enum](log-level-enum.md), and [log-color-class](log-color-class.md), please refer to the rest of our documentation.

## Conclusion
This "Getting Started" guide has provided you with the fundamental steps to begin using PremiumLogger in your .NET projects. Feel free to explore the library further and utilize its capabilities to enhance your logging.

If you have any questions or encounter any issues, don't hesitate to refer to our documentation or reach out to our support team.

Happy coding!