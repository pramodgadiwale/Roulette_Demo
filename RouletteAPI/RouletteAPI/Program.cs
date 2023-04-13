using Microsoft.Extensions.DependencyInjection;
using RouletteAPI.Database;
using RouletteAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.Configure<FormatSettings>(builder.Configuration.GetSection("Formatting"));
//builder.Services.AddSingleton(new DatabaseConfig { Name = Configuration["DatabaseName"] });

builder.Services.AddScoped<IRouletteDB, RouletteDB>();
builder.Services.AddScoped<IRouletteData, RouletteData>();
builder.Services.AddScoped<ISpinData, SpinData> ();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Services.GetService<IRouletteDB>().Setup();

app.Run();
