using Domain.Common.AutoMapper;
using Domain.Common.Helper;
using Domain.Service.DomainService.Interface;
using Domain.Service.DomainService;
using Domain.Service.Service;
using Domain.Service.Service.Interface;
using Infrastructure.Core.Repository;
using Infrastructure.Core.Repository.Interface;
using Infrastructure.Core.UnitOfWork;
using Infrastructure.Core.UnitOfWork.Interface;

namespace Applicacion.Tecnofactory.WebApi.Handlers
{
    public static class DependencyInyectionHandler
    {
        public static void DependencyInyectionConfig(IServiceCollection services)
        {
            //Infrastructure
            services.AddTransient(typeof(IBaseModel<>), typeof(BaseModel<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Service
            //services.AddScoped<IUserDomainService, UserDomainService>();
            //services.AddScoped<IAuthDomainService, AuthDomainService>();

            services.AddHttpClient<IMockyService, MockyService>();
            services.AddTransient<IMockyService, MockyService>();
            services.AddSingleton<TransformJSONtoXMLHelper>();
            services.AddTransient<IOrderService, OrderService>();

            //AutoMapper
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

        }
    }
}
