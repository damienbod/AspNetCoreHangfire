namespace AspNetCoreHangfire.Jobs;

public class MyRecurringJob : IMyRecurringJob
{
    public void DoSomethingReentrant()
    {
        Console.WriteLine("IMyRecurringJob doing something");
    }
}
