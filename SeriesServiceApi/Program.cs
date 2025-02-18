using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SeriesServiceApi.DAL.EF;
using SeriesServiceApi.DataSource;
using SeriesServiceApi.Extensions;
using SeriesServiceApi.Interfaces.DataSourse;
using SeriesServiceApi.Interfaces.Services;
using SeriesServiceApi.Services;
using System.Runtime.Serialization;

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
        options.UseSqlite("Data Source=DatabaseApi.db");
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