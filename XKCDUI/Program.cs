using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XKCDUI;
using MediatR;

namespace XKCDUI
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

            //Configure services.  Includes Data Access and Mediator for the XKCDLibrary
            var serviceProvider = Startup.ConfigureServices();

            Application.Run(new MainForm(serviceProvider.GetRequiredService<IMediator>()));
        }
    }
}
