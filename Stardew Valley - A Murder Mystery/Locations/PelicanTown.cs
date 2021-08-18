using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class PelicanTown : Location
    {
        private SaveData SaveData { get; set; }

        public PelicanTown(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            if (SaveData.TownFirstVisit == false)
            {
                Console.WriteLine(" You are in the town square. To the north, you can see a Doctor's Surgery next to a general store called Pierre's.");
                SaveData.DoctorsSurgery = true;
                SaveData.GeneralStore = true;
                Console.WriteLine("A path next to Pierre's leads further north. To the east is a tavern, a small graveyard and a couple of houses and a trailer.");
                Console.WriteLine("Beyond the tavern is a bridge leading further east.");
                SaveData.StardropSaloon = true;
                Console.WriteLine("To the south are some more houses and a path that looks like it heads towards the beach.");
                Console.WriteLine("A path in the south west leads towards the forest.");
                Console.WriteLine("Where would you like to explore?");
                SaveData.TownFirstVisit = true;
                Console.WriteLine("N > North");
                Console.WriteLine("S > South");
                Console.WriteLine("E > East");
                Console.WriteLine("W > South West");
                Console.WriteLine("V > Visit one of the town buildings");

                var Choice = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (Choice)
                {
                    case "N": if (Choice == "N") Console.WriteLine(""); break;
                    case "S": if (Choice == "S") Console.WriteLine(""); break;
                    case "E": if (Choice == "E") Console.WriteLine(""); break;
                    case "W": if (Choice == "W") Console.WriteLine(""); break; 
                    default: break;
                }
            }

            Console.WriteLine("You are in the town square.");
        }

        public override void Forage()
        {

        }
    }
}
