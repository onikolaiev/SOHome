using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

using SOHome.Common.Services;
using SOHome.UnoApp.ViewModels;

using System;

namespace SOHome.UnoApp
{
    public class Startup
    {
        public static IServiceProvider Init()
        {
            var services = new ServiceCollection();
            // Register dependencies
            services.AddTransient<MainViewModel>();
            services.AddTransient<IMessageService, MessageService>();

            // Build the IServiceProvider and return it
            var provider = services.BuildServiceProvider();
            Ioc.Default.ConfigureServices(provider);
            return provider;
        }

        public static T GetService<T>() where T : class
        {
            return Ioc.Default.GetRequiredService<T>();
        }
    }
}
