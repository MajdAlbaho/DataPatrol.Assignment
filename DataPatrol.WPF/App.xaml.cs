using System;
using System.Windows;
using DataPatrol.Services.GeneratorServices;
using DataPatrol.Services.IGeneratorServices;
using DataPatrol.WPF.MainWindow;
using DataPatrol.WPF.MainWindow.ListenerComponent;
using Microsoft.Extensions.DependencyInjection;

namespace DataPatrol.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e) {
            var services = new ServiceCollection();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<ListenerViewModel>();
            services.AddTransient<ISendApiRequestService, SendApiRequestService>();

            var serviceProvider = services.BuildServiceProvider();
            var viewModel = serviceProvider.GetService<MainWindowViewModel>();
            if (viewModel?.GetView() is MainWindowView mainWindow)
                mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
