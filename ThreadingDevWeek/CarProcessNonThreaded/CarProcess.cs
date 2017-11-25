using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingDevWeek.CarProcessNonThreaded
{
  public class CarProcess
  {


    public string GetChassis()
    {

      for (int i = 0; i < 10000000; i++)
      {
        string bob = "" + i;
      }

      return "Chassis - Ready For Assembly";
    }




    public string BuildChassis()
    {

      for (int i = 0; i < 10000000; i++)
      {
        string bob = "" + i;
      }

      return "Built Chassis";
    }





    public string GetTyres()
    {

      for (int i = 0; i < 10000000; i++)
      {
        string bob = "" + i;
      }

      return "4 Tyres - Ready For Assembly";
    }


    public string GetSteering()
    {

      for (int i = 0; i < 10000000; i++)
      {
        string bob = "" + i;
      }

      return "Steering - Ready For Assembly";
    }


    public string GetClownHorn()
    {

      for (int i = 0; i < 10000000; i++)
      {
        string bob = "" + i;
      }

      return "Clown Horn - Ready For Assembly";
    }






    public string AssemblePartsOnChassis(string builtChassis, string tyres, string steering, string clownHorn)
    {

      if (String.IsNullOrWhiteSpace(tyres) || String.IsNullOrWhiteSpace(steering) || String.IsNullOrEmpty(clownHorn))
        throw new Exception("DATA MISSING");


      builtChassis = builtChassis.Replace("- Ready For Assembly", "");
      tyres = tyres.Replace("- Ready For Assembly", "");
      steering = steering.Replace("- Ready For Assembly", "");
      clownHorn = clownHorn.Replace("- Ready For Assembly", "");


      for (int i = 0; i < 10000000; i++)
      {
        string bob = "" + i;
      }

      return String.Format("Parts assembled on {0} - {1},{2},{3} and also some magic to make it go", builtChassis.ToLower(), tyres, steering, clownHorn);
    }





    public string DriveOffProductionLine()
    {
      for (int i = 0; i < 10000000; i++)
      {
        string bob = "" + i;
      }
      return "Honk! Honk! Drive Off Baby!";
    }



  }
}
