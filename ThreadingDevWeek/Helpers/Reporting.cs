using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingDevWeek.Helpers
{
  internal class Reporting
  {
    public void CheckThreads()
    {
      int workers, portThreads;
      ThreadPool.GetAvailableThreads(out workers, out portThreads);

      Console.WriteLine("Threads Available {0}", workers);
    }
  }
}
