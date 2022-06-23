namespace CmsSampleSite.Ui
{
    using System;
    using System.IO;

    using CmsSampleSite.Features.Dependencies;
    using CmsSampleSite.HealthChecks;

    using EPiServer.Cms.Shell;
    using EPiServer.Cms.UI.AspNetIdentity;
    using EPiServer.Scheduler;
    using EPiServer.Web.Routing;

    using Geta.NotFoundHandler.Infrastructure.Configuration;
    using Geta.NotFoundHandler.Infrastructure.Initialization;
    using Geta.NotFoundHandler.Optimizely.Infrastructure.Configuration;
    using Geta.NotFoundHandler.Optimizely.Infrastructure.Initialization;
    using Geta.Optimizely.Categories.Configuration;
    using Geta.Optimizely.Categories.Infrastructure.Initialization;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IWebHostEnvironment _webHostingEnvironment;

        private readonly IConfiguration _configuration;

        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment webHostingEnvironment)
        {
            _configuration = configuration;
            _webHostingEnvironment = webHostingEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_webHostingEnvironment.IsDevelopment())
            {
                AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

                services.Configure<SchedulerOptions>(options => options.Enabled = false);
            }

            var connectionString = _configuration.GetConnectionString("EPiServerDB");
            services.AddNotFoundHandler(o =>
                {
                    o.UseSqlServer(connectionString);
                    o.BufferSize = 30;
                    o.ThreshHold = 5;
                    o.HandlerMode = FileNotFoundMode.On;
                    o.IgnoredResourceExtensions = new[] { "jpg", "gif", "png", "css", "js", "ico", "swf", "woff" };
                    o.Logging = LoggerMode.On;
                    o.LogWithHostname = false;

                    // We can add custom INotFoundHandlers here to add custom behaviour for handling not found URLS
                    //// o.AddProvider<NullNotFoundHandlerProvider>();
                },
                policy =>
                {
                    policy.RequireRole("WebAdmins");
                });

            services.AddOptimizelyNotFoundHandler();
            services.AddRazorPages();

            services
                .AddCmsAspNetIdentity<ApplicationUser>()
                .AddCms()
                .AddAdminUserRegistration()
                .AddEmbeddedLocalization<Startup>();

            services.AddCustomDependencies();
            services.AddGetaCategories();

            services.AddHealthChecks()
                    .AddCustomHealthChecks();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseNotFoundHandler();
            app.UseOptimizelyNotFoundHandler();
            app.UseGetaCategories();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapContent();
                endpoints.MapRazorPages();
                endpoints.MapHealthChecks("/app-health");
            });
        }
    }
}
