using Microsoft.OpenApi.Models;
using System.Reflection;
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

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "Url Shortener",
		Description = "Ult shortener. Test project for AXL Edtech"
	});

	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});

builder.Services.Configure<UrlSettings>(builder.Configuration.GetSection(UrlSettings.SectionName));

var app = builder.Build();

app.ConfigureExceptionHandlingMiddleware();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c => c.DefaultModelExpandDepth(-1));
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyMethod()
				  .AllowAnyHeader()
				  .SetIsOriginAllowed(origin => true)
				  .AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
