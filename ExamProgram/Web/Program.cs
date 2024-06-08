using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Contexts;
using ServiceLayer.Extensions;
using ServiceLayer.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationAutoValidation();

#region Context

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration["ConnectionStrings:Mssql"]);
});

#endregion

#region AutoMapper

var configuration = new MapperConfiguration(x =>
{
    x.AddProfile(new MappingProfile());
});
var mapper = configuration.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

builder.Services.ServiceAdd();
builder.Services.ValidateAdd();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
  
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
