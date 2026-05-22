using RSSFeedReader.Api.Services;

var builder = WebApplication.CreateBuilder(args);

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

app.UseCors("LocalDev");
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
