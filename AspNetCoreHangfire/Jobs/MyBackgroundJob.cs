namespace AspNetCoreHangfire.Jobs;

public class MyBackgroundJob : IMyBackgroundJob
{
    public void DoSomethingReenetrant()
    {
        Console.WriteLine("IMyBackgroundJob doing something");
    }
}
