using Microsoft.EntityFrameworkCore;
using DAL.EF;
using DAL.DataSource;
using Abstraction.Interfaces.DataSourse;
using Abstraction.Interfaces.Services;
using SeriesServiceApi.Extensions;
using SeriesServiceApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IGenericDataSourse<>), typeof(GenericDataSourse<>));
builder.Services.AddScoped(typeof(ISeriesDataSourse), typeof(SeriesDataSourse));
builder.Services.AddScoped<ISeriesService, SeriesService>();
builder.Services.AddScoped<IEpisodesService, EpisodesService>();


builder.Services.AddDbContext<StreamingServiceDbContext>(
    options =>
    {
        options.UseSqlite("Data Source=../DatabaseApi.db");
    });

var app = builder.Build();


app.InitMapping();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();