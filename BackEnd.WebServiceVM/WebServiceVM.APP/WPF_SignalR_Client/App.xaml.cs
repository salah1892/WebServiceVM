using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFSignalRClient.Common;
using WPFSignalRClient.HubSevice;
using WPFSignalRClient.Services;
using WPFSignalRClient.SignalRService;
using WPFSignalRClient.ViewModel;
using WPFSignalRClient.ViewModel;

namespace WPFSignalRClient
{

    public partial class App : System.Windows.Application
    {
        public HubConnection hubConnection;
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()


            });

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<PayementViewModel>();
            services.AddSingleton<OtherViewModel>();

            //services.AddSingleton<SignalRPayementService>();
            //services.AddTransient<HubConnection, HubConnectionBuilder>();
            //services.AddTransient<HubConnection>();
            services.AddSingleton<ISignalRPayementService, SignalRPayementService>();
            services.AddSingleton<INavigationService, NavigationService>();
            //----------------------------------------------------------//
            //services.AddTransient<HubConnection>(e=>e=new HubConnectionBuilder()
            //.WithUrl("http://localhost:5187/PayementOperation")
            //.Build());
            //services.AddSignalRClient();
            // services.AddScoped < IHubContext <HubConnection>();
            // services.AddSignalR().AddHubOptions<>
            /*This Work Finally*/
            services.TryAddSingleton<HubConnection>(provider => {
                var connection = new HubConnectionBuilder()
                    //.WithUrl("http://localhost:5187/PayementOperation")//WebVM.WebAPI
                    .WithUrl("https://localhost:7061/PayementOperation")//WebVM.WebAPI
                    //.WithUrl("http://localhost:5153/PayementOperation")//WebServiceVM.WebAPI
                    .Build();
                connection.StartAsync().GetAwaiter().GetResult();
                return connection;
            });
            //----------------------------------------------------------//
            services.AddSingleton<Func<Type, ViewModelBase>>(serviceProvider =>
           viewModelType => (ViewModelBase)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {

            //hubConnection = new HubConnectionBuilder()
            //.WithUrl("http://localhost:5187/PayementOperation")
            //.Build();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
