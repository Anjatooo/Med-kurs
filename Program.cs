using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication3;
using WebApplication3.Controllers;
using WebApplication3.Models.JWT;
using WebApplication3.Models.Users;
using WebApplication3.Services;
using WebApplication3.Services.BD;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddAutoMapper(typeof(AppMappingProfile)); //АвтоМаппер

builder.Services.AddScoped(typeof(IRepositoty<>), typeof(Repository<>));

builder.Services.AddSession();
builder.Services.AddAuthorization();


builder.Services.AddControllersWithViews();

builder.Services.AddScoped<JWT>();
builder.Services.Configure<Auth>(
    builder.Configuration.GetSection(key: "AuthSettings"));
builder.Services.AddAuth(builder.Configuration);

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
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
//    var red = new Red(context); // <-- здесь добавятся врачи
//}

app.Run();
