using Microsoft.Extensions.Configuration;
using NLog;

namespace ProjectA
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            NLog.LogManager.LoadConfiguration("settings/NLog.config");
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info($"开始初始化程序，日志模块初始化成功。");

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("settings/application.json", true, true);
            var root = builder.Build();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new main(root,logger));
        }
    }
}