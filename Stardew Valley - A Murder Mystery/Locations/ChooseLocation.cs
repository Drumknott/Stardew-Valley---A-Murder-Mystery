using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    public class ChooseLocation
    {
        public Location ChooseLocationMethod(SaveData saveData)
        {
            while (true)
            {
                Console.WriteLine("");
                var ChosenLocation = Console.ReadLine();
                                              
                switch (ChosenLocation)
                {
                    case "F": if (saveData.Farm == true) return new Farm(saveData); break;
                    //case "B": return new Beach; break;
                    case "M": return new Mine(saveData); break;
                    //case "C": return new CommunityCentre; break;
                    //case "S": return new StardropSaloon; break;
                    //case "D": return new DoctorsSurgery; break;

                    default: break;
                }
            }
        }
    }
}
