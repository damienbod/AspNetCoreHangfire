namespace AspNetCoreHangfire.Jobs;

public class MyBackgroundJob : IMyBackgroundJob
{
    public void DoSomethingReentrant()
    {
        Console.WriteLine("IMyBackgroundJob doing something");
    }
}
