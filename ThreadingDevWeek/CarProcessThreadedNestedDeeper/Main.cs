using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingDevWeek.CarProcessThreadedNestedDeeper
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

      CarProcessChained2 ct = new CarProcessChained2();


      //Single threaded Approach
      string getChassis = ct.GetChassis();
      Console.WriteLine("{0} - Time {1}", getChassis, st.ElapsedMilliseconds);
      string getNuts = ct.GetNuts();
      Console.WriteLine("{0} - Time {1}", getNuts, st.ElapsedMilliseconds);
      string getBolts = ct.GetBolts();
      Console.WriteLine("{0} - Time {1}", getBolts, st.ElapsedMilliseconds);
      string buildChassis = ct.BuildChassis(getNuts, getBolts);
      Console.WriteLine("{0} - Time {1}", buildChassis, st.ElapsedMilliseconds);
      string finalStep = ct.PassToNextStageOfManufacture();
      Console.WriteLine("{0} - Time {1}", finalStep, st.ElapsedMilliseconds);



      st.Restart();



      //Multi-Threaded Approach
      Console.WriteLine("\r\nMULTI THREAD - As good as we need (BEST OF EASY TO READ AND SPEED)");
      getChassis = ct.GetChassis();
      _reporting.CheckThreads();
      Console.WriteLine("{0} - Time {1}", getChassis, st.ElapsedMilliseconds);
      var getNutsTask = Task<string>.Factory.StartNew(() => ct.GetNuts());
      _reporting.CheckThreads();
      var getBoltsTask = Task<string>.Factory.StartNew(() => ct.GetBolts());
      _reporting.CheckThreads();
      buildChassis = ct.BuildChassis(getNutsTask.Result, getBoltsTask.Result); //Here we use the results of the threaded operations when they are ready.
      _reporting.CheckThreads();
      Console.WriteLine("{0} - Time {1}", buildChassis, st.ElapsedMilliseconds);
      finalStep = ct.PassToNextStageOfManufacture();
      Console.WriteLine("{0} - Time {1}", finalStep, st.ElapsedMilliseconds);



      st.Restart();


      //Further Threading
      Console.WriteLine("\r\nDeeper Threading - BAD - delay as nuts bolts still sequential");
      getChassis = ct.GetChassis();
      Console.WriteLine("{0} - Time {1}", getChassis, st.ElapsedMilliseconds);

      var buildResult = Task<NutsAndBolts>.Factory.StartNew(() =>
      {
        var nb = new NutsAndBolts();

        string nuts = ct.GetNuts(); //NOTE: NOT THREADING AGAIN HERE, SO CAUSING DELAYS
        nb.Nuts = nuts;

        _reporting.CheckThreads();

        string bolts = ct.GetBolts(); //NOTE: NOT THREADING AGAIN HERE, SO CAUSING DELAYS
        nb.Bolts = bolts;

        return nb;

      }).ContinueWith<NutsAndBolts>(tak =>
        {
          _reporting.CheckThreads();
          var bm = new NutsAndBolts();
          bm.Details = ct.BuildChassis(tak.Result.Nuts, tak.Result.Bolts);
          return bm;
        });



      Console.WriteLine("{0} - Time {1}", buildResult.Result.Details, st.ElapsedMilliseconds);
      finalStep = ct.PassToNextStageOfManufacture();
      Console.WriteLine("{0} - Time {1}", finalStep, st.ElapsedMilliseconds);




      st.Restart();


      //Further Threading  -Optimal, but a little hard to read!
      Console.WriteLine("\r\nDeeper Threading - uses continuewith");
      getChassis = ct.GetChassis();
      Console.WriteLine("{0} - Time {1}", getChassis, st.ElapsedMilliseconds);

      buildResult = Task<NutsAndBolts>.Factory.StartNew(() =>
      {
        _reporting.CheckThreads();
        var nb = new NutsAndBolts();
        _reporting.CheckThreads();
        var nutsTask = Task<string>.Factory.StartNew(() => ct.GetNuts());
        _reporting.CheckThreads();
        var boltsTask = Task<string>.Factory.StartNew(() => ct.GetBolts());
        _reporting.CheckThreads();

        nb.Nuts = nutsTask.Result;
        nb.Bolts = boltsTask.Result;
        return nb;

      })// Go Straight into the next operation with the values we gained from the the previous parallel operation.
      .ContinueWith<NutsAndBolts>(tak =>
      {
        _reporting.CheckThreads();
        var nb2 = new NutsAndBolts();
        var bs = Task<string>.Factory.StartNew(() => ct.BuildChassis(tak.Result.Nuts, tak.Result.Bolts));
        nb2.Details = bs.Result;
        _reporting.CheckThreads();
        return nb2;
      });



      Console.WriteLine("{0} - Time {1}", buildResult.Result.Details, st.ElapsedMilliseconds);
      finalStep = ct.PassToNextStageOfManufacture();
      Console.WriteLine("{0} - Time {1}", finalStep, st.ElapsedMilliseconds);




      Console.WriteLine("Press enter to continue");
      Console.ReadLine();
    }


    public class NutsAndBolts
    {
      public string Nuts { get; set; }
      public string Bolts { get; set; }
      public string Details { get; set; }
    }


  }
}
