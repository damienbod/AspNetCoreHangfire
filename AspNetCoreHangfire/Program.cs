using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreHangfire;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var services = builder.Services;
        var configuration = builder.Configuration;
        var env = builder.Environment;

        services.AddRazorPages();

        services.AddHangfire(hangfire =>
        {
            hangfire.SetDataCompatibilityLevel(CompatibilityLevel.Version_170);
            hangfire.UseSimpleAssemblyNameTypeSerializer();
            hangfire.UseRecommendedSerializerSettings();
            hangfire.UseColouredConsoleLogProvider();
            hangfire.UseSqlServerStorage(configuration.GetConnectionString("HangfireConn"), 
                new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true 
                });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        // Add the processing server as IHostedService
        services.AddHangfireServer();

        app.UseHangfireDashboard();

        //app.UseHangfireDashboard(options: new DashboardOptions() 
        //    { /*Authorization = new[] { new HangfireAuthorizationFilter() }*/ });

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}