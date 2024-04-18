# Logger Methods
The `Logger` class in `PremiumLogger` provides the following methods for logging messages:

1. **Log(string message, LogLevel logLevel, object? caller = null):**
Logs a message at the specified log level, optionally including caller information.
- Parameters:
	- `message`: The message to be logged.
	- `logLevel`: The log level of the message.
	- `caller`: Optional parameter representing the object or method calling the logger.
2. **Log(string message, object caller)**:
Logs a message at the default log level, with caller information.
- Parameters:
	- `message`: The message to be logged.
	- `caller`: The object or method calling the logger.
3. **Log(string message)**:
Logs a message at the default log level, without caller information.
- Parameters:
	- `message`: The message to be logged.