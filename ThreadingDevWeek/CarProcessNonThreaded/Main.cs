using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingDevWeek.CarProcessNonThreaded
{
  class Main
  {
    Helpers.Reporting _reporting;

    public Main()
    {
      _reporting = new Helpers.Reporting();
    }

    public void MainBuild()
    {
      Stopwatch st = new Stopwatch();
      st.Start();

      _reporting.CheckThreads();

      CarProcess cp = new CarProcess();


      string chassis = cp.GetChassis();

      Console.WriteLine("{0} - Time {1}", chassis, st.ElapsedMilliseconds);

      string buildChassis = cp.BuildChassis();

      Console.WriteLine("{0} - Time {1}", buildChassis, st.ElapsedMilliseconds);

      
      //To Be threaded and returned.
      string tyres = cp.GetTyres();
      _reporting.CheckThreads();
      Console.WriteLine("{0} - Time {1}", tyres, st.ElapsedMilliseconds);

      string steering = cp.GetSteering();
      _reporting.CheckThreads();
      Console.WriteLine("{0} - Time {1}", steering, st.ElapsedMilliseconds);

      string clownHorn = cp.GetClownHorn();
      _reporting.CheckThreads();
      Console.WriteLine("{0} - Time {1}\r\n", clownHorn, st.ElapsedMilliseconds);
      //Fin to be threaded.



      string assembly = cp.AssemblePartsOnChassis(chassis, tyres, steering, clownHorn);

      Console.WriteLine("{0} - Time {1}\r\n", assembly, st.ElapsedMilliseconds);


      string driveOff = cp.DriveOffProductionLine();

      Console.WriteLine("{0} - Time {1}", driveOff, st.ElapsedMilliseconds);


      






      _reporting.CheckThreads();
      Console.WriteLine("Press enter to continue");
      Console.WriteLine();
      Console.ReadLine();

    }
  }
}
