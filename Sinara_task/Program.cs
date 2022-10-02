using Microsoft.EntityFrameworkCore;
using Sinara_task.Data;
using Sinara_task.Repositories;
using Sinara_task.Repositories.Interfaces;
using Sinara_task.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<GuideBook_DbContext>(
        op => op.UseNpgsql(builder.Configuration.GetConnectionString("Pgl_db"))
    );

builder.Services.AddTransient<ICRUDDbRepository<Post>, UserRecordsRepository>();
builder.Services.AddTransient<ICheckActiveDirectory, UserActiveDirectoryChecker>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
