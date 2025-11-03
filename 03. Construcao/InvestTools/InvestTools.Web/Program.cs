using investTools.Web.Data;
using investTools.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;                                        
using Microsoft.Extensions.DependencyInjection;                             
using investTools.Web.Areas.Identity.Data;
using investTools.Web.Services.Email;
using investTools.Web.Services.CustomTokenProviders;
using investTools.Web.Utils;

var builder = WebApplication.CreateBuilder(args);

var emailConfig = builder.Configuration             
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();

builder.Services.AddSingleton(emailConfig);         
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IInvestidorRepository, InvestidorRepository>();      

var connectionString = builder.Configuration.GetConnectionString("default");  

builder.Services.AddDbContext<ApplicationDbContext>(options =>                          
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddDefaultIdentity<IdentityUser>()                         
    .AddEntityFrameworkStores<ApplicationDbContext>()                       
    .AddDefaultTokenProviders()
    .AddTokenProvider<EmailConfirmationTokenProvider<IdentityUser>>("emailconfirmation");

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>       
                        opt.TokenLifespan = TimeSpan.FromHours(2));         

builder.Services.Configure<EmailConfirmationTokenProviderOptions>(opt =>                    
    opt.TokenLifespan = TimeSpan.FromDays(14));


builder.Services.ConfigureApplicationCookie(options =>                      
{                                                                           
    // Cookie settings
    options.Cookie.HttpOnly = true;                                         
    options.Cookie.Name = "InvestTools.Cookies";                            
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);                       

    options.LoginPath = "/Account/Login";                                   
    options.LogoutPath = "/Account/Logout";                                 
    options.AccessDeniedPath = "/Account/AccessDenied";                     
    options.SlidingExpiration = true;                                       
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6;                                    
    options.Password.RequiredUniqueChars = 3;                               
    options.Password.RequireNonAlphanumeric = false;                        
    options.Password.RequireDigit = false;                                  
    options.Password.RequireUppercase = false;                              
    options.SignIn.RequireConfirmedEmail = true;
    options.Tokens.EmailConfirmationTokenProvider = "emailconfirmation"; 
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);   
    options.Lockout.MaxFailedAccessAttempts = 3;                        
    options.Lockout.AllowedForNewUsers = true;                          

});


// Add services to the container.
builder.Services.AddControllersWithViews()
                .ConfigureApiBehaviorOptions(options =>
                                            {
                                                options.SuppressModelStateInvalidFilter = true;
                                            });
                // .AddJsonOptions(options =>            
                //                             {
                //                                 options.JsonSerializerOptions.Converters.Add(new JsonStringConverter());
                //                                 options.JsonSerializerOptions.PropertyNamingPolicy = null;
                //                                 options.JsonSerializerOptions.WriteIndented = true;
                //                             });

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

app.MapRazorPages();                                                        


app.Run();
