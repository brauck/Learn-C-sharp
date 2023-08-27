using System.Runtime.CompilerServices;
using System.Text;

namespace MyNamespace
{
    public enum LogLevel
    {
        Off,
        Critical,
        Error,
        Warning,
        Information,
        Trace
    }

    public class Logger
    {
        public LogLevel EnabledLevel { get; init; } = LogLevel.Error;

        public void LogMessage(LogLevel level, string msg)
        {
            if (EnabledLevel < level) return;
            Console.WriteLine(msg);
        }

        public void LogMessage(LogLevel level, [InterpolatedStringHandlerArgument("", "level")] LogInterpolatedStringHandler builder)
        {
            if (EnabledLevel < level) return;
            Console.WriteLine(builder.GetFormattedText());
        }
    }

    [InterpolatedStringHandler]
    public ref struct LogInterpolatedStringHandler
    {
        // Storage for the built-up string
        StringBuilder builder;

        private readonly bool enabled;

        public LogInterpolatedStringHandler(int literalLength, int formattedCount, Logger logger, LogLevel level, out bool isEnabled)
        {
            isEnabled = logger.EnabledLevel >= level;
            Console.WriteLine($"\tliteral length: {literalLength}, formattedCount: {formattedCount}");
            builder = isEnabled ? new StringBuilder(literalLength) : default!;
        }

        /*public LogInterpolatedStringHandler(int literalLength, int formattedCount, Logger logger, LogLevel logLevel)
        {
            enabled = logger.EnabledLevel >= logLevel;
            builder = new StringBuilder(literalLength);
            Console.WriteLine($"\tliteral length: {literalLength}, formattedCount: {formattedCount}");
        }*/

        /*public LogInterpolatedStringHandler(int literalLength, int formattedCount)
        {
            builder = new StringBuilder(literalLength);
            Console.WriteLine($"\tliteral length: {literalLength}, formattedCount: {formattedCount}");
        }*/

        public void AppendLiteral(string s)
        {
            Console.WriteLine($"\tAppendLiteral called: {{{s}}}");
            //if (!enabled) return;

            builder.Append(s);
            Console.WriteLine($"\tAppended the literal string");
        }

        public void AppendFormatted<T>(T t)
        {
            Console.WriteLine($"\tAppendFormatted called: {{{t}}} is of type {typeof(T)}");
            //if (!enabled) return;

            builder.Append(t?.ToString());
            Console.WriteLine($"\tAppended the formatted object");
        }

        public void AppendFormatted<T>(T t, string format) where T : IFormattable
        {
            Console.WriteLine($"\tAppendFormatted (IFormattable version) called: {t} with format {{{format}}} is of type {typeof(T)},");

            builder.Append(t?.ToString(format, null));
            Console.WriteLine($"\tAppended the formatted object");
        }

        internal string GetFormattedText() => builder.ToString();
    }
}