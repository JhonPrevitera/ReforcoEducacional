using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace UserService.Api.DependencyInjection;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
	{
		var keycloakSettings = configuration.GetSection("Keycloak");
    
		services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
        
			c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			{
				Name = "Authorization",
				Type = SecuritySchemeType.OAuth2,
				Scheme = "Bearer",
				BearerFormat = "JWT",
				In = ParameterLocation.Header,
				Flows = new OpenApiOAuthFlows
				{
					AuthorizationCode = new OpenApiOAuthFlow
					{
						AuthorizationUrl = new Uri($"{keycloakSettings["Authority"]}/protocol/openid-connect/auth"),
						TokenUrl = new Uri($"{keycloakSettings["Authority"]}/protocol/openid-connect/token"),
						Scopes = new Dictionary<string, string>
						{
							{ "openid", "OpenID Connect" },
							{ "profile", "Profile information" }
						}
					}
				}
			});

			c.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						}
					},
					new[] { "openid", "profile" }
				}
			});
		});

		return services;
	}
	public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
	{
		var keycloakSettings = configuration.GetSection("Keycloak");
    
		services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.Authority = keycloakSettings["Authority"];
				options.Audience = "user-service-api";
				options.RequireHttpsMetadata = bool.Parse(keycloakSettings["RequireHttpsMetadata"] ?? "false");
				options.SaveToken = true;
        
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidIssuer = keycloakSettings["Authority"],
					ValidateAudience = true,
					ValidAudiences = new[] { "account", "user-service-api" },
					ValidateLifetime = true,
					ClockSkew = TimeSpan.FromSeconds(30),
					ValidateIssuerSigningKey = true
				};

				options.Events = new JwtBearerEvents
				{
					OnAuthenticationFailed = context =>
					{
						Console.WriteLine($"Authentication failed: {context.Exception.Message}");
						return Task.CompletedTask;
					},
					OnTokenValidated = context =>
					{
						// Adicione esta linha para debug
						Console.WriteLine($"Token validated for user: {context.Principal.Identity.Name}");
						return Task.CompletedTask;
					}
				};
			});

		services.AddAuthorization(options =>
		{
			options.AddPolicy("AdminOnly", policy => 
				policy.RequireClaim("user_realm_roles", "admin"));
        
			options.AddPolicy("UserAccess", policy =>
				policy.RequireClaim("user_realm_roles", new[] { "user", "admin" }));
		});

		return services;
	}

}