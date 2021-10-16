using SacredAncariaConnectionClient.Controller;
using SacredAncariaConnectionClient.Models;
using SacredAncariaConnectionClient.Utilities;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SacredAncariaConnectionClient
{
    static class Program
    {
        internal static string Version = "1.1";
        internal static LogConsole LogConsole = null;

        private static readonly AutoResetEvent _closing = new AutoResetEvent(false);

        [STAThread]
        static void Main(string[] args)
        {
            var headless = false;
            var logLevel = LogConsole.LogLevel.Info;
            var logfileName = string.Empty;

            if (args.Contains("headless", StringComparer.OrdinalIgnoreCase))
            {
                headless = true;
            }

            if (args.Contains("debug", StringComparer.OrdinalIgnoreCase))
            {
                logLevel = LogConsole.LogLevel.Debug;
            }
            else if (args.Contains("none", StringComparer.OrdinalIgnoreCase))
            {
                logLevel = LogConsole.LogLevel.None;
            }

            if (args.Contains("filelog"))
            {
                logfileName = "SacredAncariaConnectionClient.log";
            }

            LogConsole = new LogConsole(logLevel, logfileName);

            if (!headless)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                var context = new Context();
                LogConsole.Init(context);
                var client = new Client(context);
                var firstTime = client.ReadConfiguration();
                if (firstTime)
                {
                    LogConsole.Write("Welcome to Sacred Ancaria Connection Client. Enjoy your Sacred Online!\n" +
                                              "If you plan to host a game, please be sure to read the help!", LogConsole.LogLevel.Info);
                }
                if (context.ClientPort == context.ServerPort)
                {
                    LogConsole.Write("You should not use the same port for server listening and client broadcasting. Please change them. Quitting", LogConsole.LogLevel.Error);
                    Environment.Exit(0);
                }
                client.Init();
                LogConsole.Write($"SAC Client version {Version} started. CTRL+C to close", LogConsole.LogLevel.Info);
                Console.CancelKeyPress += new ConsoleCancelEventHandler(OnExit);
                _closing.WaitOne();
                Environment.Exit(0);
            }
        }

        internal static void OnExit(object sender, ConsoleCancelEventArgs args)
        {
            _closing.Set();
        }
    }
}
