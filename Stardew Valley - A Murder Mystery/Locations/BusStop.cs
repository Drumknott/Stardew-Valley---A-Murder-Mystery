using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class BusStop : Location
    {
        private SaveData SaveData { get; set; }

        public BusStop(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            SaveData.LastVisited = "Bus";

            if (SaveData.FreshOffTheBus == false)
            {
                SaveData.PamCount += 1;
                Console.WriteLine("Pam points.");
                Console.WriteLine("Pam > If you head left there that road will take you into town, or right will take you to Stardew Farm.");
                Console.WriteLine("Pam > Good luck, Detective " + SaveData.PlayerName, ".");
                Console.WriteLine("Pam locks the bus and hurries off.");
                Console.WriteLine("");

                SaveData.FreshOffTheBus = true;
                SaveData.BusStop = true;
                SaveData.Farm = true;
                SaveData.PelicanTown = true;
                Console.WriteLine("[BusStop] added to location list");
                Console.WriteLine("[Farm] added to Location list");
                Console.WriteLine("Pelican [Town] added to location list");
            }

            if (SaveData.DayCount == 0 || SaveData.DayCount == 1 || SaveData.DayCount == 2 || SaveData.DayCount == 3 || SaveData.DayCount == 5)
            {
                Pam pam = new(SaveData);

                Console.WriteLine("You are at the bus stop.");
                Console.WriteLine("");
                Console.WriteLine("Pam is here, waiting by the bus. Is she always here?");
                Console.WriteLine("");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("");
                Console.WriteLine("C > Chat with Pam");
                Console.WriteLine("G > Go back");
                var choice = Console.ReadLine();

                if (choice == "C")
                {
                    pam.Chat();
                }
            }

            if (SaveData.DayCount == 4 || SaveData.DayCount == 6)
            {
                Console.WriteLine("You are at the bus stop.");
                Console.WriteLine("");
                Console.WriteLine("For once there's no one here. Could Pam be having a day off for once?");
            }
        }

        public override void Forage()
        {        
            Console.WriteLine("You find a Red Mushroom hiding under a bush."); 
            SaveData.MyInventory.TryGetValue(Enums.Items.RedMushroom, out var mushroomCount);
            mushroomCount++;
            SaveData.MyInventory[Enums.Items.RedMushroom] = mushroomCount;            
        }
    }
}
