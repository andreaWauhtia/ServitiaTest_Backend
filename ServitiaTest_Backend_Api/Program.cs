using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ServitiaTest_Backend_Api.Hubs;
using ServitiaTest_Backend_Common.DependencyInjection;
using ServitiaTest_Backend_Domain.DependencyInjection;
using ServitiaTest_Backend_Persistence.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureCommonDependencies(builder.Configuration);
builder.Services.ConfigureDomainDependencies(builder.Configuration);
builder.Services.ConfigurePersistenceDependencies(builder.Configuration);
builder.Services.ConfigureApplicationDependencies(builder.Configuration);
builder.Services.ConfigureInfrastructureDependencies(builder.Configuration);
builder.Services.AddSingleton<MessageNotificationHub>();
builder.Services.AddSingleton<MessageReadHub>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    // options.Authority = "https://localhost:5001/";
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = null,
        ValidateIssuerSigningKey = false,
        ValidIssuer = "MyApp",
        ValidateIssuer = true,
        ValidAudience = "MyAppUser",
        ValidateAudience = false,
        ValidateLifetime = true, //validate the expiration and not before values in the token
        ClockSkew = TimeSpan.FromMinutes(5), //5 minute tolerance for the expiration date (opt?)
                                             //RequireExpirationTime = true,
        SaveSigninToken = false
    };
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((config) =>
{
   
});
builder.Services.AddSignalR();
builder.Services.AddHttpContextAccessor();



builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();


// Customise default API behaviour
builder.Services.Configure<ApiBehaviorOptions>(options =>
    options.SuppressModelStateInvalidFilter = true);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
       .AllowAnyMethod()
       .AllowAnyHeader()
       .SetIsOriginAllowed(origin => true) // allow any origin
       .AllowCredentials()); // allow credentials

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Add the following line to configure routing.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.MapHub<MessageNotificationHub>("/notification");
app.MapHub<MessageReadHub>("/read");
app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
