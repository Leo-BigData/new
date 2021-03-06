using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;
using MyShuttle.Client.Core.Infrastructure;
using MyShuttle.Client.Core.Infrastructure.Abstractions.Repositories;
using MyShuttle.Client.Core.Infrastructure.Abstractions.Services;
using MyShuttle.Client.Core.ServiceAgents;
using MyShuttle.Client.Core.ServiceAgents.Interfaces;
using MyShuttle.Client.Core.ViewModels;
using MyShuttle.Client.Core.ViewModels.InterfacesForDependencyInjection;
using MyShuttle.Client.W10.UniversalApp.Infrastructure;
using MyShuttle.Client.W10.UniversalApp.ViewModels;

namespace MyShuttle.Client.W10.UniversalApp.UAP
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterType<IApplicationSettingServiceSingleton, ApplicationSettingServiceSingleton>();
            Mvx.RegisterType<IApplicationStorageService, ApplicationStorageService>();
            Mvx.RegisterType<ILocationServiceSingleton, LocationServiceSingleton>();
            Mvx.RegisterType<IApplicationDataRepository, ApplicationDataRepository>();
            // Register the storage provider
            Mvx.RegisterType<IMyShuttleClient, MyShuttleClient>();

            Mvx.RegisterType<IVehiclesByDistanceViewModel, VehiclesByDistanceViewModel>();
            Mvx.RegisterType<IVehiclesByPriceViewModel, VehiclesByPriceViewModel>();
            Mvx.RegisterType<IVehiclesInMapViewModel, VehiclesInMapViewModel>();
            Mvx.RegisterType<IMyRidesViewModel, Core.ViewModels.MyRidesViewModel>();
            Mvx.RegisterType<ISettingsViewModel, Core.ViewModels.SettingsViewModel>();
            Mvx.RegisterType<IVehiclesInMapViewModel, VehiclesInMapViewModel>();

            // Services
            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsDynamic();

            // Singleton services
            CreatableTypes().EndingWith("ServiceSingleton").AsInterfaces().RegisterAsLazySingleton();

            // Set the start point
            RegisterAppStart<ViewModels.MainViewModel>();
        }
    }
}
