using Hangfire;
using Hangfire.Storage;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreHangfire.Pages;

public class DeleteRecurringJobsModel : PageModel
{
    public void OnGet()
    {
    }

    public void OnPost() 
    {
        using (var connection = JobStorage.Current.GetConnection())
        {
            foreach (var recurringJob in connection.GetRecurringJobs())
            {
                RecurringJob.RemoveIfExists(recurringJob.Id);
            }
        }
    }
}