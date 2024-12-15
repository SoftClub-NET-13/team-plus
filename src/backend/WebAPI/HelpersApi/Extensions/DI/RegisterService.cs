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
            x.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            x.LogTo(Console.WriteLine);
        });

        //fluent validation ? for automatic validation ,need use mediatr.
        //builder.Services.AddValidatorsFromAssembly(typeof(Application.Application).Assembly);

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

        app.UseStaticFiles();
        app.UseExceptionHandler("/error");
        app.MapControllers();

        app.Run();

        return app;
    }
}