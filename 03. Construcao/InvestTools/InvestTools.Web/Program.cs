using investTools.Web.Data;
using investTools.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;                                        // Linha inserida
using Microsoft.Extensions.DependencyInjection;                             // Linha inserida
using investTools.Web.Areas.Identity.Data;
using investTools.Web.Services.Email;

var builder = WebApplication.CreateBuilder(args);

var emailConfig = builder.Configuration             // Linha inserida
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();

builder.Services.AddSingleton(emailConfig);         // Linha inserida
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IInvestidorRepository, InvestidorRepository>();      // Linha inserida

var connectionString = builder.Configuration.GetConnectionString("default");  // Linha inserida

builder.Services.AddDbContext<ApplicationDbContext>(options =>                          // Linha inserida
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddDefaultIdentity<IdentityUser>()                         // Linha inserida (Tem que ser colocada debaixo do "AddDbContext")
    .AddEntityFrameworkStores<ApplicationDbContext>()                      // Linha inserida (Tem que ser colocada debaixo do "AddDbContext")
    .AddDefaultTokenProviders();

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>       // Linha inserida
                        opt.TokenLifespan = TimeSpan.FromHours(2));         // Linha inserida

builder.Services.ConfigureApplicationCookie(options =>                      // Linha inserida
{                                                                           // Linha inserida
    // Cookie settings
    options.Cookie.HttpOnly = true;                                         // Linha inserida
    options.Cookie.Name = "InvestTools.Cookies";                            // Linha inserida
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);                       // Linha inserida

    options.LoginPath = "/Account/Login";                                   // Linha inserida
    options.LogoutPath = "/Account/Logout";                                 // Linha inserida
    options.AccessDeniedPath = "/Account/AccessDenied";                     // Linha inserida
    options.SlidingExpiration = true;                                       // Linha inserida
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6;                                    // Linha inserida
    options.Password.RequiredUniqueChars = 3;                               // Linha inserida
    options.Password.RequireNonAlphanumeric = false;                        // Linha inserida
    options.Password.RequireDigit = false;                                  // Linha inserida
    options.Password.RequireUppercase = false;                              // Linha inserida
    options.SignIn.RequireConfirmedEmail = true;
});


// Add services to the container.
builder.Services.AddControllersWithViews()                                      // Linha alterada
                .ConfigureApiBehaviorOptions(options =>
                                            {
                                                options.SuppressModelStateInvalidFilter = true;
                                            });

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

app.MapRazorPages();                                                        // Linha inserida


app.Run();
