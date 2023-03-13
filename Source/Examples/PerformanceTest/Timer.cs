using System.Diagnostics;

class Timer : IDisposable
{
    public string Message { get; set; }

    private readonly Stopwatch watch;

    public Timer(string message)
    {
        this.Message = message;
        this.watch = new Stopwatch();
        this.watch.Start();
    }

    public long Stop()
    {
        this.watch.Stop();
        return this.ElapsedMicroseconds / 1000;
    }

    public void Dispose()
    {
        var ms = this.watch.ElapsedMilliseconds;
        Console.WriteLine("{0}: {1} ms", this.Message, ms);
    }

    protected long ElapsedMicroseconds
    {
        get
        {
            return 1000000L * this.watch.ElapsedTicks / Stopwatch.Frequency;
        }
    }
}
