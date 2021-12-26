using BootstrapBlazor.Components;
using BootstrapBlazorApp.Proxy;
using BootstrapBlazorApp.Shared.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Refit;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddBootstrapBlazor();

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<IVaccinationLocationProxy, VaccinationLocationProxy>();

// 增加 Table 数据服务操作类
builder.Services.AddTableDemoDataService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
