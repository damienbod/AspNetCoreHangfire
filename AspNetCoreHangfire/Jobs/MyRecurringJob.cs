namespace AspNetCoreHangfire.Jobs;

public class MyRecurringJob : IMyRecurringJob
{
    public void DoSomethingReenetrant()
    {
        Console.WriteLine("IMyRecurringJob doing something");
    }
}
