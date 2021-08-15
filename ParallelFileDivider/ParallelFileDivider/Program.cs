using Microsoft.Extensions.DependencyInjection;
using ParallelFileDivider.Core;
using ParallelFileDivider.Core.Contracts;
using ParallelFileDivider.Core.Helpers;
using ParallelFileDivider.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelFileDivider
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                Application.Run(serviceProvider.GetRequiredService<MainForm>());
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            MicrosoftDependencyInjectionHelper.RegisterServices(services);
            services.AddScoped<MainForm>();
        }
    }
}
