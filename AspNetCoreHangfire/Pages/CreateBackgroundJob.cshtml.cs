using AspNetCoreHangfire.Jobs;
using Hangfire;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreHangfire.Pages;

public class CreateBackgroundJob : PageModel
{
    public void OnGet()
    {
    }

    /// <summary>
    /// https://docs.hangfire.io/en/latest/background-methods/index.html
    /// </summary>
    public void OnPost() 
    {
        BackgroundJob.Enqueue<IMyBackgroundJob>(x => x.DoSomethingReentrant());
    }
}