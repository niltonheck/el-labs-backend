using CWebService.Application.Interfaces;
using CWebService.Application.Services;
using CWebService.Infrastructure.Repositories;
using CWebService.Domain.Repositories;
using CWebService.CrossCutting.Providers;
using SimpleInjector;
using CWebService.Infrastructure.Contexts;
using CWebService.Infrastructure.Contexts.Interfaces;

namespace CWebService.CrossCutting.DependencyInjector {
    public class Composer {

        public Container container = new SimpleInjector.Container();

        public Composer(Container container) {
            this.container = container;
        }

        public Container Build() {   
            container.Options.ResolveUnregisteredConcreteTypes = true;
            container.Options.EnableAutoVerification = false;

            container.Register<IAuthService, AuthService>();
            container.Register<IUserService, UserService>();
            container.Register<IBookingService, BookingService>();
            container.Register<IVehicleService, VehicleService>();
            container.Register<IBrandService, BrandService>();
            container.Register<IModelService, ModelService>();
            container.Register<IModelRepository, ModelRepository>();
            container.Register<IUserRepository, UserRepository>();
            container.Register<IBookingRepository, BookingRepository>();
            container.Register<IVehicleRepository, VehicleRepository>();
            container.Register<IBrandRepository, BrandRepository>();

            container.Register<IModelContext, ModelContext>(ScopedLifestyle.Scoped);
            container.Register<IBrandContext, BrandContext>(ScopedLifestyle.Scoped);
            container.Register<IVehicleContext, VehicleContext>(ScopedLifestyle.Scoped);
            container.Register<IBookingContext, BookingContext>(ScopedLifestyle.Scoped);
            
            container.RegisterSingleton(() => GetMapper(container));

            return container;
        }

        private AutoMapper.IMapper GetMapper(Container container)
        {
            var mp = container.GetInstance<MapperProvider>();
            return mp.GetMapper();
        }
    }
}