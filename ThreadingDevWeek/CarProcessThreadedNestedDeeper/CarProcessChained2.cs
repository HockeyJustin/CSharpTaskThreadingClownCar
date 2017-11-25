using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingDevWeek.CarProcessThreadedNestedDeeper
{
  public class CarProcessChained2
  {



    public string GetChassis()
    {

      for (int i = 0; i < 10000000; i++)
      {
        string bob = "" + i;
      }

      return "Chassis - Ready For Assembly";
    }



    public string GetNuts()
    {

      for (int i = 0; i < 10000000; i++)
      {
        string bob = "" + i;
      }

      return "Nuts";
    }



    public string GetBolts()
    {

      for (int i = 0; i < 10000000; i++)
      {
        string bob = "" + i;
      }

      return "Bolts";
    }






    public string BuildChassis(string nuts, string bolts)
    {

      for (int i = 0; i < 10000000; i++)
      {
        string bob = "" + i;
      }

      return String.Format("Built Chassis with {0} and {1}", nuts, bolts) ;
    }




    public string PassToNextStageOfManufacture()
    {

      for (int i = 0; i < 10000000; i++)
      {
        string bob = "" + i;
      }

      return "We're done in the chassis factory";
    }




  }
}
