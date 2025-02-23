using Microsoft.EntityFrameworkCore;
using DAL.EF;
using DAL.DataSource;
using Abstraction.Interfaces.DataSourse;
using Abstraction.Interfaces.Services;
using SeriesServiceApi.Extensions;
using SeriesServiceApi.Services;
using NLog.Web;
using Microsoft.AspNetCore.Identity;
using Models.Entities;
using MapsterMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMapper, Mapper>();
builder.Services.AddScoped(typeof(IGenericDataSourse<>), typeof(GenericDataSourse<>));
builder.Services.AddScoped(typeof(ISeriesDataSourse), typeof(SeriesDataSourse));
builder.Services.AddScoped<ISeriesService, SeriesService>();
builder.Services.AddScoped<IEpisodesService, EpisodesService>();

builder.Services.AddDbContext<StreamingServiceDbContext>(
    options =>
    {
        options.UseSqlite("Data Source=../DatabaseApi.db");
    });

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false; 
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 1;
    options.Password.RequiredUniqueChars = 0;
})
.AddEntityFrameworkStores<StreamingServiceDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Logging.ClearProviders();
builder.Host.UseNLog();
builder.Services.AddLogger();

var app = builder.Build();


app.AddExceptionHandler();
app.InitMapping();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();