using Microsoft.Extensions.Configuration;

namespace ultimate
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