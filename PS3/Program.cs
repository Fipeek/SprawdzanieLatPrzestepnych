using PS3.Data;
 using Microsoft.EntityFrameworkCore;
using PS3.Interfaces;
using PS3.Services;
using PS3.Repositories;
using Microsoft.AspNetCore.Identity;
using PS3.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<UsersContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PS3")));
builder.Services.AddIdentity<Admin, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<UsersContext>().AddDefaultUI().AddDefaultTokenProviders();
builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddTransient<IUserRepository,
UserRepository>();

builder.Services.AddDbContext<UsersContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("PS3")));
builder.Services.AddMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});
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
app.UseAuthentication();;

app.UseAuthorization();
app.UseSession();

app.MapRazorPages();

app.Run();
