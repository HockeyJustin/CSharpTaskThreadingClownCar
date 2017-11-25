using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingDevWeek.Progress
{
  public class CarProcessReporting : CarProcessNonThreaded.CarProcess
  {
    /// <summary>
    /// Overload of BuildChassis that includes progress reporting : )
    /// </summary>
    /// <param name="progress"></param>
    /// <returns></returns>
    public string BuildChassis(IProgress<int> progress)
    {

      for (int i = 0; i < 10000000; i++)
      {
        string bob = "" + i;

        //If we are at a set number, raise the progress event
        if (i % 100000 == 0)
        {
          progress.Report(i);
        }

      }

      return "Built Chassis";
    }

  }
}
