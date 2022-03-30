using DrugManagementWebApp.Data;
using Microsoft.EntityFrameworkCore;
using DrugManagementWebApp.Interfaces;
using DrugManagementWebApp.Repositories;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationContextConnection");builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=DrugAppDb;Integrated Security=True"));
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDepartment,DepartmentRepository>();
builder.Services.AddScoped<IUsageConditionDrug, UsageConditionDrugRepository>();
builder.Services.AddScoped<IReactionAgent,ReactionAgentRepository>();
builder.Services.AddScoped<IAllergicSymptom, AllergicSymptomRepository>();
builder.Services.AddScoped<IAntiAllergicDrug, AntiAllergicDrugRepository>();
builder.Services.AddScoped<IConditionDetail, ConditionDetailRepository>();
builder.Services.AddScoped<IPatient, PatientRepository>();



builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=DrugMangAppDb;Integrated Security=True"));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
