using Microsoft.Extensions.DependencyInjection;

using SOHome.Common.Services;
using SOHome.UnoApp.ViewModels;

using System;

namespace SOHome.UnoApp
{
    public class Startup
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IServiceCollection Services { get; private set; }

        public static IServiceProvider Init()
        {
            Services = new ServiceCollection();
            // Register dependencies
            Services.AddTransient<MainViewModel>();
            Services.AddTransient<IMessageService, MessageService>();

            // Build the IServiceProvider and return it
            ServiceProvider = Services.BuildServiceProvider();
            return ServiceProvider;
        }

        public static T GetService<T>() where T : class
        {
            return (T)ActivatorUtilities.GetServiceOrCreateInstance(ServiceProvider, typeof(T));
        }
    }
}
