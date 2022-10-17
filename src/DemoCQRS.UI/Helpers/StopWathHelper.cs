using System.Diagnostics;

namespace DemoCQRS.UI.Helpers
{
    public class StopWathHelper
    {
        private Stopwatch stopWatch;
        public void Start()
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
        }

        public string StopeResult()
        {
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            return elapsedTime;
        }

    }
}
