using System.Reflection;
using Application.Contracts.Repositories;
using Application.Contracts.Repositories.BaseRepository;
using Application.Contracts.Repositories.BaseRepository.Crud;
using Application.Contracts.Services;
using FluentValidation;
using Infrastructure.DataAccess;
using Infrastructure.ImplementationContract.Repositories;
using Infrastructure.ImplementationContract.Repositories.BaseRepository;
using Infrastructure.ImplementationContract.Repositories.BaseRepository.Crud;
using Infrastructure.ImplementationContract.Services;
using Microsoft.EntityFrameworkCore;
using WebAPI.HelpersApi.Extensions.FluentValidation;

namespace WebAPI.HelpersApi.Extensions.DI;

public static class RegisterService
{
    public static IServiceCollection AddServices(this WebApplicationBuilder builder)
    {
        //registration swagger
        builder.Services.AddSwaggerGen();

        //registration controller
        builder.Services.AddControllers();


        builder.Services.AddDbContext<DataContext>(x =>
        {
            x.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
            // x.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            x.LogTo(Console.WriteLine);
        });

        //fluent validation with mediatr

        builder.Services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssembly(Assembly.GetCallingAssembly());
            x.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        builder.Services.AddValidatorsFromAssembly(Assembly.GetCallingAssembly());

        //registration generic repository
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddScoped(typeof(IGenericAddRepository<>), typeof(GenericAddRepository<>));
        builder.Services.AddScoped(typeof(IGenericUpdateRepository<>), typeof(GenericUpdateRepository<>));
        builder.Services.AddScoped(typeof(IGenericDeleteRepository<>), typeof(GenericDeleteRepository<>));
        builder.Services.AddScoped(typeof(IGenericFindRepository<>), typeof(GenericFindRepository<>));

        //registration repository
        builder.Services.AddScoped<ISpecializationRepository, SpecializationRepository>();

        //registration services
        builder.Services.AddScoped<ISpecializationService, SpecializationService>();

        return builder.Services;
    }

    public static WebApplication UseMiddlewares(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseExceptionHandler("/error");
        app.UseStaticFiles();
        app.MapControllers();

        app.Run();

        return app;
    }
}