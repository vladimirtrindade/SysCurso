using AutoMapper;
using DTO;
using Microsoft.Extensions.DependencyInjection;
using WebUI.Models;

namespace WebUI.StartupConfigure
{
    public static class AutoMapperConfigure
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContatoViewModel, ContatoDTO>().ReverseMap();
                cfg.CreateMap<TelefoneViewModel, TelefoneDTO>().ReverseMap();
            });
            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            return services;
        }
    }
}