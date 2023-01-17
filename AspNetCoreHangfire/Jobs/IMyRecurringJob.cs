namespace AspNetCoreHangfire.Jobs;

public interface IMyRecurringJob
{
    public void DoSomethingReentrant();
}
