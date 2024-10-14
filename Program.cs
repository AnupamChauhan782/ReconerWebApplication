using DataAccess.DbContect;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDBConect>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbContect"));
});
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<ApplicationDBConect>().AddDefaultTokenProviders();
//builder.Services.ConfigureApplicationCookie(opt =>
//{
//    opt.AccessDeniedPath = "/Account/Login";
//    opt.LoginPath = "Account/Login";
//    opt.LogoutPath = "Account/Logout";
//    opt.Cookie.Name = "AuthApplication";
//    opt.ExpireTimeSpan = TimeSpan.FromDays(30);
//    opt.SlidingExpiration = true;
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
