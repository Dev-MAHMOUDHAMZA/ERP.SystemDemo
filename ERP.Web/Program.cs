using ERP.Infrastructure.Data;
using ERP.Web.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.InjectionServices(builder);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

var supportedCultures = new[] { "ar", "en" };
app.UseRequestLocalization(new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures)
    .AddInitialRequestCultureProvider(new QueryStringRequestCultureProvider()
    {
        QueryStringKey = "lang"
    }));

//Seeding 
using var Scope = app.Services.CreateScope();
var services = Scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<ApplicationDbContext>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    //var userManager = services.GetRequiredService<UserManager<ApplicationEmployee>>();
    //var roleServices = services.GetRequiredService<RolesServicesBL>();
    //DefaultMainProgram.SeedMainProgram(context);   
    //await DefaultRoles.SeedDefaultRolesAsync(roleManager, roleServices);
    //DefaultRegion.SeedRegions(context);
    //await DefaultUser.SeedDefaultUsersAsync(userManager, roleManager, context);
}
catch (Exception) { }



app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
