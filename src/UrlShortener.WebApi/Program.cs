using UrlShortener.Core;
using UrlShortener.Infrastructure;
using UrlShortener.WebApi.Middleware;
using UrlShortener.WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCore();

builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("DbConnection"));

builder.Services.AddCors();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<UrlSettings>(builder.Configuration.GetSection(UrlSettings.SectionName));

var app = builder.Build();

app.ConfigureExceptionHandlingMiddleware();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyMethod()
				  .AllowAnyHeader()
				  .SetIsOriginAllowed(origin => true) 
				  .AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
