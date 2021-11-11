using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Marnies : Location
    {
        private SaveData SaveData { get; set; }
        bool MarnieHere { get; set; }
        bool ShaneHere { get; set; }

        public Marnies(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            SaveData.LastVisited = "Marnies";
            Console.WriteLine("You're in Marnie's.");

            switch (SaveData.DayCount)
            {
                case 0:
                case 1:
                case 6:
                    Console.WriteLine("There's no one here.");
                    break;
                case 2:
                case 3:
                case 4:
                    Console.WriteLine("Marnie is bustling behind the counter of her farm store.");
                    SaveData.npc1 = "Marnie";
                    break;
                case 5:
                    Console.WriteLine("Through the doorway you can see Marnie in the kitchen, while Shane is putting out feed for the chickens.");
                    SaveData.npc1 = "Marnie";
                    SaveData.npc2 = "Shane";
                    break;
                default: break;
            }
        }

        public override void Forage()
        {
            Console.WriteLine("You can't forage in here.");
        }        
    }
}
