using Hangfire;

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
        services.AddHangfire(
            x => x.UseSqlServerStorage(configuration.GetConnectionString("HangfireConn"))
        );

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

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