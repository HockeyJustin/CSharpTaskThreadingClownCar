using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingDevWeek
{
  class Program
  {
    static void Main(string[] args)
    {

      Console.WriteLine("-----------------------------------------------------------------------");
      Console.WriteLine("Non-threaded-----------------------------------------------------------");

      ThreadingDevWeek.CarProcessNonThreaded.Main mn = new CarProcessNonThreaded.Main();
      mn.MainBuild();

      Console.WriteLine("-----------------------------------------------------------------------");
      Console.WriteLine("Threaded---------------------------------------------------------------");

      ThreadingDevWeek.CarProcessThreaded.Main mnt = new CarProcessThreaded.Main();
      mnt.MainBuild();

      Console.WriteLine("-----------------------------------------------------------------------");
      Console.WriteLine("Progress Reporting_----------------------------------------------------");

      Progress.Main p = new Progress.Main();
      p.MainBuild();

      Console.WriteLine("-----------------------------------------------------------------------");
      Console.WriteLine("Deeper Nesting--------------------------------------------------------");

      CarProcessThreadedNestedDeeper.Main ct = new CarProcessThreadedNestedDeeper.Main();
      ct.MainBuild();

    }
  }
}
