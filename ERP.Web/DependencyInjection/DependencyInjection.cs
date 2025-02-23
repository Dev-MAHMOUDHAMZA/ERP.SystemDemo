
using ERP.Domain.Entities.Common;
using ERP.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;


namespace ERP.Web.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection InjectionServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        #region MyRegion
        //builder.Services.AddHangfire(h => h.UseSqlServerStorage(connectionString));
        //builder.Services.AddHangfireServer();

        //builder.Services.Configure<AuthorizationOptions>(options =>
        //{
        //    options.AddPolicy(ConstRoles.DefaultRole, policy =>
        //    {
        //        policy.RequireAuthenticatedUser();
        //    });

        //    options.AddPolicy("ArchivePolicy", policy =>
        //        policy.RequireAssertion(context =>
        //            context.User.HasClaim("Permission", Permissions.Mailing.SecretArchive) ||
        //            context.User.HasClaim("Permission", Permissions.Mailing.NonSecretArchive) ||
        //            context.User.HasClaim("Permission", Permissions.Mailing.TransferGeneralMailing) ||
        //            context.User.HasClaim("Permission", Permissions.Mailing.TransferMailingInDepartment)
        //        )
        //    );

        //    options.AddPolicy("InternalMailingDetailsPolicy", policy =>
        //       policy.RequireAssertion(context =>
        //           context.User.HasClaim("Permission", Mailing.InternalIncomingMailingDetails) ||
        //           context.User.HasClaim("Permission", Mailing.OutgoingDetails))
        //   );

        //    options.AddPolicy("ExternalMailingDetailsPolicy", policy =>
        //       policy.RequireAssertion(context =>
        //           context.User.HasClaim("Permission", Mailing.ExternalIncomingMailingDetails) ||
        //           context.User.HasClaim("Permission", Mailing.OutgoingDetails))
        //   );
        //}); 
        #endregion

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseLazyLoadingProxies().UseSqlServer(connectionString), ServiceLifetime.Transient);


        builder.Services.AddIdentity<Employee, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
        }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

        //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        //add services

        //builder.Services.AddScoped<CountriesServicesBL>();



        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            options.LoginPath = "/Accounts/Login";
            options.LogoutPath = "/Accounts/SignOutAsync";
            options.AccessDeniedPath = "/Accounts/AccessDenied";
            options.SlidingExpiration = true;
            options.Cookie.Name = "Cookie";

        });

        builder.Services.Configure<SecurityStampValidatorOptions>(options =>
        {
            options.ValidationInterval = TimeSpan.Zero;
        });
        builder.Services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
        });

        builder.Services.AddMemoryCache();

        builder.Services.AddControllersWithViews();
        services.AddHttpContextAccessor();
        builder.Services.AddSession();
        builder.Services.AddSignalR();

        //builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MapperProfile)));

        //builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //builder.Services.AddScoped<CitiesServices>();


        //builder.Services.AddHTMLToPDF();

        //Register Languages
        //builder.Services.AddSingleton<ServicesLanguage>();
        //services.AddLocalization(options => options.ResourcesPath = "Resources");
        //services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
        //    .AddDataAnnotationsLocalization(options =>
        //    {
        //        options.DataAnnotationLocalizerProvider = (type, factory) =>
        //        {
        //            var assemblyName = new AssemblyName(typeof(ResourceWeb).GetTypeInfo().Assembly.FullName!);
        //            return factory.Create("ResourceWeb", assemblyName.Name!);
        //        };
        //    });


        //Register Permissions
        //builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
        //builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
        //builder.Services.AddScoped<IEmailSender, ServicesEmailSender>();





        builder.Services.AddScoped<MemoryStream>();

        //Add Serilog
        ////Log.Logger = new LoggerConfiguration().ReadFrom
        ////    .Configuration(builder.Configuration).WriteTo.Console() // Log to the console
        ////      .WriteTo.Seq("http://localhost:5341").CreateLogger();
        ////builder.Host.UseSerilog();


        //Add Serilog
        // Log.Logger = new LoggerConfiguration()
        //.WriteTo.MSSqlServer(connectionString, tableName: "ErrorLogsDashboard") 
        //.CreateLogger();
        //builder.Host.UseSerilog();
        return services;
    }

}

