using TemplateDDD.Domain.Interfaces;
using TemplateDDD.Domain.Interfaces.Services;
using TemplateDDD.Infra.Context;
using TemplateDDD.Infra.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemplateDDD.Service.Services;

namespace TemplateDDD.Application.DI
{
    public static class Initializer
    {
        public static void Configuracao(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Default");
            serviceCollection.AddScoped(typeof(IUserService), typeof(UserService));
            //serviceCollection.AddScoped(typeof(IProcessoService), typeof(ProcessoService));
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            serviceCollection.AddDbContext<MyContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }
    }
}

