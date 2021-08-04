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
                var ChosenLocation = Console.ReadLine();
                                              
                switch (ChosenLocation)
                {
                    case "F": if (saveData.Farm == true) return new Farm(saveData); break;
                    case "B": if (saveData.Beach == true) return new Beach(saveData); break;
                    case "M": return new Mine(saveData); break;
                    case "C": return new CommunityCentre(saveData); break;
                    case "S": return new StardropSaloon(saveData); break;
                    case "D": return new DoctorsSurgery(saveData); break;

                    default: break;
                }
            }
        }
    }
}
