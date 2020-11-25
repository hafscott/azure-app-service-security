using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Benday.EasyAuthDemo.Api.DataAccess;
using Benday.EasyAuthDemo.Api;
using Benday.EasyAuthDemo.Api.ServiceLayers;
using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EfCore.SqlServer;
using Benday.EasyAuthDemo.Api.DataAccess.SqlServer;
using Benday.EasyAuthDemo.Api.AzureStorage;
using Benday.EasyAuthDemo.Api.Security;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Benday.EasyAuthDemo.WebUi.Models;
using Benday.EasyAuthDemo.WebUi.Security;
using Benday.EasyAuthDemo.Api.Logging;

namespace Benday.EasyAuthDemo.WebUi
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            
            RegisterTypes(services);
            ConfigureAuthentication(services);
            ConfigureAuthorization(services);
            ConfigureEmail(services);
        }
        
        private void ConfigureEmail(IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();
            
            services.AddOptions<EmailConfigurationOptions>().Configure(options =>
            {
                options.FromEmail = Configuration.GetValue<string>("Email:FromEmail");
                options.FromName = Configuration.GetValue<string>("Email:FromName");
                options.SendGridApiKey = Configuration.GetValue<string>("Email:SendGridApiKey");
            });
            //services.AddTransient<IPaymentOrderPermissionsService, PaymentOrderPermissionsService>();
        }
        
        private void ConfigureAuthentication(IServiceCollection services)
        {
            var config = new SecurityConfiguration(Configuration);
            
            services.AddAuthentication(
            CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = new PathString(config.LoginPath);
                options.LogoutPath = new PathString(config.LogoutPath);
            });
        }
        
        private void ConfigureAuthorization(IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, LoggedInUsingEasyAuthHandler>();
            services.AddSingleton<IAuthorizationHandler, RoleAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, ClaimAuthorizationHandler>();
            services.AddTransient<IRouteDataAccessor, HttpContextRouteDataAccessor>();
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy(SecurityConstants.Policy_LoggedInUsingEasyAuth,
                policy => policy.Requirements.Add(
                new LoggedInUsingEasyAuthRequirement()));
                
                options.AddPolicy(SecurityConstants.Policy_IsAdministrator,
                policy => policy.Requirements.Add(
                new RoleAuthorizationRequirement(
                SecurityConstants.RoleName_Admin)));
                
                options.DefaultPolicy = options.GetPolicy(SecurityConstants.Policy_LoggedInUsingEasyAuth);
            });
        }
        
        private void RegisterTypesForPopulateClaimsMiddleware(IServiceCollection services)
        {
            services.AddTransient<PopulateClaimsMiddleware>();
            services.AddTransient<ISecurityConfiguration, SecurityConfiguration>();
        }
        
        private void RegisterTypes(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddTransient<ISecurityConfiguration, SecurityConfiguration>();
            services.AddTransient<IClaimsAccessor, HttpContextClaimsAccessor>();
            RegisterTypesForPopulateClaimsMiddleware(services);
            services.AddDbContext<EasyAuthDemoDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("default")));
            
            services.AddTransient<IEasyAuthDemoDbContext, EasyAuthDemoDbContext>();
            
            services.AddTransient<IUserInformation, UserInformation>();
            services.AddTransient<IUsernameProvider, UserInformation>();
            services.AddTransient<ISearchStringParserStrategy, DefaultSearchStringParserStrategy>();
            
            ConfigureAzureBlobStorage(services);
            
            ConfigureServiceLayers(services);
            ConfigureValidators(services);
            ConfigureRepositories(services);
        }
        
        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddTransient<IPersonRepository, SqlEntityFrameworkPersonRepository>();
            services.AddTransient<
            ILookupRepository,
            SqlEntityFrameworkLookupRepository>();
            services.AddTransient<IConfigurationItemRepository, SqlEntityFrameworkConfigurationItemRepository>();
            services.AddTransient<ILogEntryRepository, SqlEntityFrameworkLogEntryRepository>();
            services.AddTransient<IUserRepository, SqlEntityFrameworkUserRepository>();
            services.AddTransient<IUserClaimRepository, SqlEntityFrameworkUserClaimRepository>();
            
        }
        
        private static void ConfigureValidators(IServiceCollection services)
        {
            services.AddTransient<
            IValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.Person>,
            DefaultValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.Person>>();
            services.AddTransient<
            IValidatorStrategy<Benday.EasyAuthDemo.WebUi.Models.PersonEditorViewModel>,
            DefaultValidatorStrategy<Benday.EasyAuthDemo.WebUi.Models.PersonEditorViewModel>>();
            services.AddTransient<
            IValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.Lookup>,
            DefaultValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.Lookup>>();
            services.AddTransient<
            IValidatorStrategy<Benday.EasyAuthDemo.WebUi.Models.LookupEditorViewModel>,
            DefaultValidatorStrategy<Benday.EasyAuthDemo.WebUi.Models.LookupEditorViewModel>>();
            services.AddTransient<
            IValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem>,
            DefaultValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem>>();
            services.AddTransient<
            IValidatorStrategy<Benday.EasyAuthDemo.WebUi.Models.ConfigurationItemEditorViewModel>,
            DefaultValidatorStrategy<Benday.EasyAuthDemo.WebUi.Models.ConfigurationItemEditorViewModel>>();
            services.AddTransient<
            IValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.LogEntry>,
            DefaultValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.LogEntry>>();
            services.AddTransient<
            IValidatorStrategy<Benday.EasyAuthDemo.WebUi.Models.LogEntryEditorViewModel>,
            DefaultValidatorStrategy<Benday.EasyAuthDemo.WebUi.Models.LogEntryEditorViewModel>>();
            services.AddTransient<
            IValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.User>,
            DefaultValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.User>>();
            services.AddTransient<
            IValidatorStrategy<Benday.EasyAuthDemo.WebUi.Models.UserEditorViewModel>,
            DefaultValidatorStrategy<Benday.EasyAuthDemo.WebUi.Models.UserEditorViewModel>>();
            services.AddTransient<
            IValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.UserClaim>,
            DefaultValidatorStrategy<Benday.EasyAuthDemo.Api.DomainModels.UserClaim>>();
            services.AddTransient<
            IValidatorStrategy<Benday.EasyAuthDemo.WebUi.Models.UserClaimEditorViewModel>,
            DefaultValidatorStrategy<Benday.EasyAuthDemo.WebUi.Models.UserClaimEditorViewModel>>();
            
        }
        
        private static void ConfigureServiceLayers(IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<ILookupService, LookupService>();
            services.AddTransient<IConfigurationItemService, ConfigurationItemService>();
            services.AddTransient<ILogEntryService, LogEntryService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserClaimService, UserClaimService>();
            
        }
        
        private void ConfigureAzureBlobStorage(IServiceCollection services)
        {
            // azure images
            services.AddOptions<AzureBlobImageStorageOptions>().Configure(options =>
            {
                options.UseDevelopmentStorage = Configuration.GetValue<bool>("AzureStorage:UseDevelopmentStorage");
                options.AccountKey = Configuration.GetValue<string>("AzureStorage:AccountKey");
                options.AccountName = Configuration.GetValue<string>("AzureStorage:AccountName");
                options.ContainerName = Configuration.GetValue<string>("AzureStorage:ContainerName");
                options.ReadTokenExpirationInSeconds = Configuration.GetValue<int>("AzureStorage:ReadTokenExpirationInSeconds");
            });
            
            services.AddTransient<IAzureBlobImageSasTokenGenerator, AzureBlobImageStorageHelper>();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            ConfigureLogging(app, loggerFactory);
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();
            
            app.UseAuthentication();
            app.UsePopulateClaimsMiddleware();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
        
        private void ConfigureLogging(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            var config = app.ApplicationServices.GetRequiredService<IConfiguration>();
            
            var connectionString = config.GetConnectionString("default");
            
            loggerFactory.AddProvider(
            new SqlDatabaseLoggerProvider(
            new SqlDatabaseLoggerOptions()
            {
                LogLevel = LogLevel.Information,
                ConnectionString = connectionString
            }
            ));
        }
    }
}

