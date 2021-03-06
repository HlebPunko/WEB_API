using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Modsen_Pr1;
using Modsen_Pr1.Mapping;
using Modsen_Pr1.Repositories;
using Modsen_Pr1.Repositories.Interfaces;
using Modsen_Pr1.Services;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Modsen_Pr1.AppContext>((DbContextOptionsBuilder options) =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventInfoContext") ??
    throw new InvalidOperationException("Connection string 'EventInfoContext' not found.")));

builder.Services.AddControllers()
       .AddJsonOptions(j => j.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEventInfoService, EventInfoService>();
builder.Services.AddScoped<IEventInfoRepository, EventInfoRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description =
            "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Id = "Bearer" , Type = ReferenceType.SecurityScheme }
            } ,
            new List< string >()
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        ValidIssuer = UserService.Issuer,
        ValidAudience = UserService.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(UserService.SecretKey))

    };
});

builder.Services.AddAuthorization();
builder.Services.AddAutoMapper(typeof(EventInfoProfile), typeof(UserProfile), typeof(AuthProfile));

builder.Services.AddHttpContextAccessor();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var contextEventInfo = services.GetRequiredService<global::Modsen_Pr1.AppContext>();
    DbInitializer.Initialize(contextEventInfo);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();