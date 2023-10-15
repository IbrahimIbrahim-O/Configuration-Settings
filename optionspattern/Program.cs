using optionspattern.ConfigOptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Implement option service
builder.Services.Configure<AppSettingsOptions>
    (builder.Configuration.GetSection("weatherapi"));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.Run();
