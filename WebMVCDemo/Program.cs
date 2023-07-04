using Microsoft.AspNetCore.Builder;
using Serilog;
using System.Diagnostics.Metrics;
using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MyBookstoreApp.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.AspNetCore.Mvc.Razor;
using MyBookStoreApp.MyBookStoreApp.Domain.Services;
using MyBookStoreApp.MyBookStoreApp.Domain.Interfaces;
using MyBookStoreApp.MyBookStoreApp.Domain.Repositories;

namespace MyBookStoreApp.MyBookStoreApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                //We are trying to create a host in which the application will run.
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application startup failed");
            }
            finally
            {
                Console.WriteLine();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            /*
                .Enrich.WithProperty("ApplicationName", "MyApp"): This enricher adds a property named "ApplicationName" with the value "MyApp" to each log event. This can be useful to identify the source of the log events, especially in multi-application scenarios.
                .Enrich.FromLogContext(): This enricher adds contextual information to the log events. It captures information from the execution context, such as HTTP request details, user information, or any custom context you have defined. This information can be useful for troubleshooting or analyzing log events.
             */
            return Host.CreateDefaultBuilder(args)
                .UseSerilog((builderCtx, logCtx) =>
                {
                    logCtx
                    .ReadFrom.Configuration(builderCtx.Configuration)
                    .Enrich.FromLogContext();
                })
                .ConfigureWebHostDefaults((webHostBuilder) =>
                {
                    webHostBuilder.ConfigureServices((services) =>
                    {
                        services.AddControllersWithViews()
                            .AddRazorOptions((options) =>
                            {
                                options.ViewLocationFormats.Add("/MyBookstoreApp.Web/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                                options.ViewLocationFormats.Add("/MyBookstoreApp.Web/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
                            });
                        services.AddDbContext<BookstoreDbContext>(options =>
                            options.UseNpgsql(configuration.GetSection("ConnectionStrings:BookstoreDbConnection").Value));
                        services.AddScoped<IAuthorRepository, AuthorRepository>();
                        services.AddScoped<AuthorService>();
                    })
                    .Configure((ctx, app) =>
                    {
                        //Placing this middleware at the beginning ensures that any unhandled exceptions during the request processing are caught
                        //and handled appropriately.
                        if (ctx.HostingEnvironment.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                        }
                        else
                        {
                            app.UseExceptionHandler();
                        }

                        app.UseHttpsRedirection();
                        //This middleware should come after the exception handling middleware.It allows the server to serve static files directly,
                        //such as CSS, JavaScript, and images.
                        app.UseStaticFiles();

                        //The routing middleware should be placed after the static files middleware. It handles the routing of incoming requests
                        //to the appropriate controller actions based on defined routes.
                        app.UseRouting();

                        //Enables authentication and authorization features, allowing you to authenticate users and protect certain resources or actions.
                        app.UseAuthentication();

                        //Handles authorization checks for authenticated requests, ensuring that the user has the necessary permissions to
                        //access the requested resource or perform the action.
                        app.UseAuthorization();

                        //UseEndpoints middleware is responsible for mapping incoming requests to the appropriate endpoint, which is defined by the routing system.
                        //It determines which controller action or Razor Page should handle the request based on the configured routes.
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllerRoute(
                                name: "default",
                                pattern: "{controller=Author}/{action=Index}");
                        });
                    });
                });
        }
    }
}