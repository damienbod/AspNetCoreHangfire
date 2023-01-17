using AspNetCoreHangfire.Jobs;
using Hangfire;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreHangfire.Pages;

public class CreateRecurringJobModel : PageModel
{
    public void OnGet()
    {
    }

    public void OnPost() 
    {
        RecurringJob.AddOrUpdate<IMyRecurringJob>(job => job.DoSomethingReenetrant(), Cron.Hourly);
    }
}