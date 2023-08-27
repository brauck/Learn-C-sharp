// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/interpolated-string-handler

using MyNamespace;

var logger = new Logger() { EnabledLevel = LogLevel.Warning };
var time = DateTime.Now;

/*logger.LogMessage(LogLevel.Error, $"Error Level. CurrentTime: {time}. This is an error. It will be printed.");
logger.LogMessage(LogLevel.Trace, $"Trace Level. CurrentTime: {time}. This won't be printed.");
logger.LogMessage(LogLevel.Warning, "Warning Level. This warning is a string, not an interpolated string expression.");*/

logger.LogMessage(LogLevel.Error, $"Error Level. CurrentTime: {time}. The time doesn't use formatting.");
logger.LogMessage(LogLevel.Error, $"Error Level. CurrentTime: {time:t}. This is an error. It will be printed.");
logger.LogMessage(LogLevel.Trace, $"Trace Level. CurrentTime: {time:t}. This won't be printed.");

int index = 0;
int numberOfIncrements = 0;
for (var level = LogLevel.Critical; level <= LogLevel.Trace; level++)
{
    Console.WriteLine(level);
    logger.LogMessage(level, $"{level}: Increment index a few times {index++}, {index++}, {index++}, {index++}, {index++}");
    numberOfIncrements += 5;
}
Console.WriteLine($"Value of index {index}, value of numberOfIncrements: {numberOfIncrements}");