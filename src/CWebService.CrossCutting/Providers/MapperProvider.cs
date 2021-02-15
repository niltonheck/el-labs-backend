using AutoMapper;
using AutoMapper.Configuration;
using SimpleInjector;
using CWebService.Application.Profiles;

namespace CWebService.CrossCutting.Providers
{
    public class MapperProvider
    {
        private readonly Container container;

        public MapperProvider(Container container)
        {
            this.container = container;
        }

        public IMapper GetMapper()
        {
            var mce = new MapperConfigurationExpression();
            mce.ConstructServicesUsing(container.GetInstance);

            mce.AddProfile<UserDataProfile>();
            mce.AddProfile<BrandProfile>();
            mce.AddProfile<ModelProfile>();
            mce.AddProfile<VehicleProfile>();
            mce.AddProfile<BookingProfile>();

            var mc = new MapperConfiguration(mce);
            mc.AssertConfigurationIsValid();

            IMapper m = new Mapper(mc, t => container.GetInstance(t));

            return m;
        }
    }
}