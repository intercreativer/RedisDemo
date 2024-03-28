using RedisDemo.Components;
using RedisDemo.Data;

//public IConfigurationRoot? Configuration { get; }

//public Startup(IConfiguration configuration)
//{
//    Configuration = configuration;
//}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<WeatherForecastService, WeatherForecastService>();

//builder.Services.AddSingleton<IConfiguration>(Configuration);
builder.Services.AddStackExchangeRedisCache(options =>
    {
        var connection = "localhost:5002";
        options.Configuration = connection; //ConfigurationManager.GetConnectionString("Redis")//
        options.InstanceName = "RedisDemo_";
        
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
