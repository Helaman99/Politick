using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.ComponentModel;
using System.Text;
using Politick.Api.Data;
using Politick.Api.Identity;
using Politick.Api.Services;
using Politick.Api.Hubs;


var MyAllowAllOrigins = "_myAllowAllOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowAllOrigins,
                      policy =>
                      {
                          policy.WithOrigins("politick-api.azurewebsites.net",
                                             "https://victorious-flower-0ddb7221e.3.azurestaticapps.net",
                                             "http://localhost:5173")
                                .AllowAnyHeader()
                                .AllowAnyHeader()
                                .AllowCredentials();
                      });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    config =>
    {
        config.SwaggerDoc("v1", new OpenApiInfo { Title = "Wordle API", Version = "v1" });
        config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer"
        });
        config.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new List<string>()
        }
    });
    }
);
builder.Services.AddSignalR().AddHubOptions<ChatHub>(options =>
{
    options.EnableDetailedErrors = true;
    options.ClientTimeoutInterval = TimeSpan.FromMinutes(2);
    options.KeepAliveInterval = TimeSpan.FromMinutes(1);
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<ShopService>();
builder.Services.AddSingleton<ChatService>();

//Identity Services
builder.Services.AddIdentityCore<Player>(options =>
    {
        options.User.RequireUniqueEmail = true;
        options.User.AllowedUserNameCharacters = string.Empty; // Usernames aren't required, nor asked for
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
{
    o.Name = "Default";
    o.TokenLifespan = TimeSpan.FromHours(1);
});

//JWT Token setup
JwtConfiguration jwtConfiguration = builder.Configuration
    .GetSection("Jwt").Get<JwtConfiguration>() ??
    throw new Exception("JWT configuration not specified");

// Use "$env:JWT_SECRET = 'your-secret-value-so-it-works'" in the same powershell instance if running on localhost
//string? jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET", EnvironmentVariableTarget.Process);
//if (jwtSecret is null) throw new NullReferenceException(nameof(jwtSecret));
//jwtConfiguration.Secret = jwtSecret;


builder.Services.AddSingleton(jwtConfiguration);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfiguration.Issuer,
            ValidAudience = jwtConfiguration.Audience,

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Secret))
        };
    });

//Add Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Policies.RandomAdmin, Policies.RandomAdminPolicy);
    options.AddPolicy("IsGrantPolicy", policy => policy.RequireRole("Grant"));
});

var app = builder.Build();

app.UseStaticFiles();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    await IdentitySeed.SeedAsync(
        scope.ServiceProvider.GetRequiredService<UserManager<Player>>(),
        scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>());
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add a redirect for the root URL
//var redirectRootUrl = app.Configuration.GetValue<string>("RedirectRootUrl", "");
//if (string.IsNullOrEmpty(redirectRootUrl)) redirectRootUrl = "https://politickgame.azurewebsites.net";
//var options = new RewriteOptions()
//        .AddRedirect("^$", redirectRootUrl, 302);
//app.UseRewriter(options);

app.UseHttpsRedirection();

app.UseCors(MyAllowAllOrigins);

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/ChatHub");

app.Run();
