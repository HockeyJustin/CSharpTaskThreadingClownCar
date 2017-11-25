using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadingDevWeek.CarProcessNonThreaded;

namespace ThreadingDevWeek.CarProcessThreaded
{
  public class Main
  {
    Helpers.Reporting _reporting;

    public Main()
    {
      _reporting = new Helpers.Reporting();
    }


    public void MainBuild()
    {

      try
      {
        Stopwatch st = new Stopwatch();
        st.Start();

        _reporting.CheckThreads();

        CarProcess cp = new CarProcess();


        string chassis = cp.GetChassis();

        Console.WriteLine("{0} - Time {1}", chassis, st.ElapsedMilliseconds);



        //Start threaded processes for info later
        var tyres = Task<string>.Factory.StartNew(() => new CarProcess().GetTyres());
                                                                                  // could use continuewith if we needed something resulting from this....
        _reporting.CheckThreads();
        Console.WriteLine("{0} - Time {1}", tyres, st.ElapsedMilliseconds);

        var steering = Task<string>.Factory.StartNew(() => new CarProcess().GetSteering());
        
        _reporting.CheckThreads();
        Console.WriteLine("{0} - Time {1}", steering, st.ElapsedMilliseconds);


        var clownHorn = Task<string>.Factory.StartNew(() => new CarProcess().GetClownHorn());
        
        _reporting.CheckThreads();
        Console.WriteLine("{0} - Time {1}\r\n", clownHorn, st.ElapsedMilliseconds);

        //Fin to be threaded.




        string buildChassis = cp.BuildChassis(); //Long running, but need this for asssembly.

        Console.WriteLine("{0} - Time {1}", buildChassis, st.ElapsedMilliseconds);


        string assembly = cp.AssemblePartsOnChassis(chassis, tyres.Result, steering.Result, clownHorn.Result);

        Console.WriteLine("{0} - Time {1}\r\n", assembly, st.ElapsedMilliseconds);


        string driveOff = cp.DriveOffProductionLine();

        Console.WriteLine("{0} - Time {1}", driveOff, st.ElapsedMilliseconds);




        _reporting.CheckThreads();
        Console.WriteLine("Press enter to continue");
        Console.ReadLine();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
