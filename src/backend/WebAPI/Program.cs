using System.Reflection;
using FluentValidation;
using WebAPI.HelpersApi.Extensions.FluentValidation;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddMediatR(x => { x.AddOpenBehavior(typeof(ValidationBehavior<,>)); });
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.MapControllers();

app.Run();