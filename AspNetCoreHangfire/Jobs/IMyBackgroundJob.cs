namespace AspNetCoreHangfire.Jobs;

public interface IMyBackgroundJob
{
    public void DoSomethingReentrant();
}
