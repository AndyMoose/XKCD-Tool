using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XKCDLibrary;
using XKCDLibrary.DataAccess;

namespace XKCDUI
{
    public static class Startup
    {
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddMediatR(typeof(XKCDLibraryEntryPoint).Assembly);
            services.AddSingleton<DBDataAccess>();
            services.AddSingleton<APIDataAccess>();
            return services.BuildServiceProvider();
        }
    }
}
