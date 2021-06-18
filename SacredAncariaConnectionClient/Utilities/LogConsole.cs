using SacredAncariaConnectionClient.Models;
using System;
using System.IO;

namespace SacredAncariaConnectionClient.Utilities
{
    internal class LogConsole
    {
        internal Context Context { get; private set; }
        internal LogLevel Level { get; }
        internal StreamWriter LogFile { get; }

        private bool _connection;

        internal LogConsole(LogLevel level = LogLevel.Info, string filename = null)
        {
            Level = level;
            if (!string.IsNullOrWhiteSpace(filename))
            {
                LogFile = new StreamWriter(filename, true);
            }
        }

        internal void Init(Context context)
        {
            Context = context;

            context.ServerPosted += OnServerPosted;
            context.ServerReceived += OnServerReceived;
        }

        internal void Write(string text, LogLevel level)
        {
            if (Level > level)
            {
                return;
            }

            var toWrite = $"{DateTime.UtcNow} - {text}";
            Console.Out.WriteLine(toWrite);
            if (LogFile != null)
            {
                LogFile.WriteLine(toWrite);
            }
        }

        private void OnServerReceived(object sender, EventArgs e)
        {
            if (_connection != Context.Connected)
            {
                _connection = Context.Connected;
                if (_connection)
                {
                    Program.LogConsole.Write("Connected to SAC Server", LogLevel.Info);
                }
                else
                {
                    Program.LogConsole.Write("Connected with SAC Server interrupted", LogLevel.Info);
                }
            }

            Program.LogConsole.Write("Reply from SAC Server", LogLevel.Debug);
        }

        private void OnServerPosted(object sender, EventArgs e)
        {
            Program.LogConsole.Write("Servers posted to SAC Server", LogLevel.Debug);
        }

        internal enum LogLevel
        {
            Debug = 0,
            Info = 1,
            Error = 2,
            None = 3,
        }
    }
}
