using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using investTools.Web.Data;
using investTools.Web.Models.Pessoa;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IInvestidorRepository, InvestidorRepository>();      
// builder.Services.AddScoped<IContaAplicacaoRepository, ContaAplicacaoRepository>();                

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews()
                .ConfigureApiBehaviorOptions(options =>        
                                            {                                                       
                                                options.SuppressModelStateInvalidFilter = true;     
                                            }); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
