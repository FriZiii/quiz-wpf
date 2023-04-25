using Microsoft.Extensions.DependencyInjection;
using Quiz.Core.Core;
using Quiz.Core.Services;
using Quiz.Core.ViewModels;
using System;
using System.Windows;

namespace Quiz
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>(),
            });
            services.AddSingleton<MainWindowViewModel>();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<SearchViewModel>();
            services.AddSingleton<CreateViewModel>();
            services.AddSingleton<AnswearingViewModel>();
            services.AddSingleton<EditViewModel>();

            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
