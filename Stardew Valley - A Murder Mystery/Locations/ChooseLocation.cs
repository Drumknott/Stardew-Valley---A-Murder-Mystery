using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
     class ChooseLocation
    {
        public Location ChooseLocationMethod(SaveData saveData)
        {
            while (true)
            {
                Console.WriteLine("Where would you like to go?");

                if (saveData.Farm == true) Console.WriteLine("F > Stardew Farm");
                if (saveData.Beach == true) Console.WriteLine("B > Beach");
                if (saveData.Mine == true) Console.WriteLine("M > Mine");
                if (saveData.CommunityCentre == true) Console.WriteLine("C > Community Centre");
                if (saveData.StardropSaloon == true) Console.WriteLine("S > Stardrop Saloon");
                if (saveData.DoctorsSurgery == true) Console.WriteLine("D > Doctor's Surgery");
                if (saveData.PelicanTown == true) Console.WriteLine("P > Pelican Town");

                var ChosenLocation = Console.ReadLine();
                                              
                switch (ChosenLocation)
                {
                    case "F": if (saveData.Farm == true) return new Farm(saveData); break;
                    case "B": if (saveData.Beach == true) return new Beach(saveData); break;
                    case "M": if (saveData.Mine == true) return new Mine(saveData); break;
                    case "C": if (saveData.CommunityCentre == true) return new CommunityCentre(saveData); break;
                    case "S": if (saveData.StardropSaloon == true) return new StardropSaloon(saveData); break;
                    case "D": if (saveData.DoctorsSurgery == true) return new DoctorsSurgery(saveData); break;
                    case "P": if (saveData.PelicanTown == true) return new PelicanTown(saveData); break;

                    default: break;
                }
            }
        }
    }
}
