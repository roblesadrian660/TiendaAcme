using Applicacion.Tecnofactory.WebApi.Handlers;
using Infrastructure.Core.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ContextSQL>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringSQLServer")));
JwtConfigurationHandler.ConfigureJwtAuthentication(builder.Services, builder.Configuration);
DependencyInyectionHandler.DependencyInyectionConfig(builder.Services);
SwaggerHandler.SwaggerConfig(builder.Services);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");
app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
