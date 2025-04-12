
using Microsoft.EntityFrameworkCore;
using UserService.Api.DependencyInjection;
using UserService.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddLogging();
builder.Services.AddSwaggerConfiguration(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policyBuilder =>
	{
		policyBuilder.WithOrigins("*");
		policyBuilder.WithMethods("*");
		policyBuilder.WithHeaders("*");
	});
} );
builder.Services.AddDbContext<UserServiceDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
		c.OAuthClientId(builder.Configuration["Keycloak:ClientId"]);
		c.OAuthClientSecret(builder.Configuration["Keycloak:ClientSecret"]); // Para cliente confidencial
		c.OAuthAppName("API - Swagger");
		c.OAuthUsePkce();
	});
}
app.Logger.LogInformation("Cargando...");
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors( policyBuilder => policyBuilder.WithOrigins("*").WithMethods("*").WithHeaders("*"));
app.UseHttpsRedirection();

app.Run();
