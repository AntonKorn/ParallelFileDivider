using Microsoft.Extensions.DependencyInjection;
using ParallelFileDivider.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core.Helpers
{
    public static class MicrosoftDependencyInjectionHelper
    {
        public static void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IFileAccessor, DefaultFileAccessor>()
                .AddScoped<IFileDivider, DefaultFileDivider>()
                .AddScoped<IFileManager, DefaultFileManager>();
        }
    }
}
