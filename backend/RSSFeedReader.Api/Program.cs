using RSSFeedReader.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddCors(options =>
{
    options.AddPolicy("LocalDev", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

builder.Services.AddSingleton<SubscriptionStore>();
builder.Services.AddSingleton<SubscriptionService>();

var app = builder.Build();

app.Logger.LogInformation("Starting RSSFeedReader API");

app.UseCors("LocalDev");
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
