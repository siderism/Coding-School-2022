
using Final.EF.Context;
using Final.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Final.Win
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            services.AddScoped<TransactionHandler>();
            

            Application.Run(new Login());
        }
    }
}