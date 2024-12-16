using CourseProject_AutomatedGreenHouse.Controllers;
using CoursProject.BLL.Interfaces;
using CoursProject.BLL.Services;
using CoursProject.Core.Constants;
using CoursProject.Core.Options;
using CoursProject.DAL.Data;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7209");
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowCredentials();
                      });

});

builder.Services.Configure<DbOptions>(
    builder.Configuration.GetSection(
        OptionsConstants.DbOptionsKey));

builder.Services.AddDbContext<CourseProjectDbContext>((provider, ctx) =>
{
    var options = provider.GetRequiredService<IOptions<DbOptions>>().Value;
    ctx.UseSqlServer(options.ConnectionString);
});

builder.Services.AddScoped<IIndicatorService, IndicatorService>();
builder.Services.AddScoped<IBackgroundImageService, BackgroundImageService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHub<IndicatorHub>("/indicator");

app.MapControllers();

app.Run();