using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingDevWeek.Progress
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

      Stopwatch st = new Stopwatch();
      st.Start();

      _reporting.CheckThreads();

      CarProcessReporting cp = new CarProcessReporting();


      string chassis = cp.GetChassis();

      Console.WriteLine($"{chassis} - Time {st.ElapsedMilliseconds}");

      //IMPORTANT
      // The progress is created here. - It implements IProgress
      Progress<int> progress = new Progress<int>();
      // Subscribe to the progress event...
      progress.ProgressChanged += progress_ProgressChanged;
      // Call the method as usual, passing in the progress token.
      var buildChassis = Task<string>.Factory.StartNew(() => cp.BuildChassis(progress));

      

      //To Be threaded and returned.
      var tyres = Task.Factory.StartNew<string>(() => cp.GetTyres());
      _reporting.CheckThreads();
      Console.WriteLine($"{tyres} - Time {st.ElapsedMilliseconds}");

      var steering = Task.Factory.StartNew<string>(() => cp.GetSteering());
      _reporting.CheckThreads();
      Console.WriteLine($"{steering} - Time {st.ElapsedMilliseconds}");

      var clownHorn = Task.Factory.StartNew<string>(() => cp.GetClownHorn());
      _reporting.CheckThreads();
      Console.WriteLine($"{clownHorn} - Time {st.ElapsedMilliseconds}\r\n");
      //Fin to be threaded.



      Console.WriteLine($"{buildChassis.Result} - Time {st.ElapsedMilliseconds}");

      string assembly = cp.AssemblePartsOnChassis(chassis, tyres.Result, steering.Result, clownHorn.Result);
      _reporting.CheckThreads();
      Console.WriteLine($"{assembly} - Time {st.ElapsedMilliseconds}\r\n");


      string driveOff = cp.DriveOffProductionLine();
      _reporting.CheckThreads();
      Console.WriteLine($"{driveOff} - Time {st.ElapsedMilliseconds}");









      _reporting.CheckThreads();
      Console.WriteLine("Press enter to continue");
      Console.ReadLine();




    }




    /// <summary>
    /// This is the progress event for the chassis
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void progress_ProgressChanged(object sender, int e)
    {

      _reporting.CheckThreads();

      Console.WriteLine(e);
    }
  }



}
