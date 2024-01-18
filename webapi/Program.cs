using webapi.Controller;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddTransient<GoogleDistanceService>();
builder.Services.AddTransient<PCMilerDistanceService>();


builder.Services.AddScoped<DistanceProviderResolver>(serviceProvider => engine =>
{
    return engine switch
    {
        DistanceProvider.Google => serviceProvider.GetRequiredService<GoogleDistanceService>(),
        DistanceProvider.PCMiler => serviceProvider.GetRequiredService<PCMilerDistanceService>(),
        _ => throw new Exception("Unsupported service provider"),
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
