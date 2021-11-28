using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class EvelynGeorgeAlexsHouse : Location
    {
        private SaveData SaveData { get; set; }

        public EvelynGeorgeAlexsHouse(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            Console.WriteLine("You are in George, Evelyn and Alex's house.\n");
            switch (SaveData.DayCount)
            {
                case 0:
                case 1:
                case 3:
                case 5:
                    Console.WriteLine("George is watching TV. Alex is lifting weights in his room, and Evelyn is bustling about the kitchen. Something smells wonderful.");
                    SaveData.npc1 = "Alex";
                    SaveData.npc2 = "George";
                    SaveData.npc3 = "Evelyn";
                    break;                
                case 2:
                    Console.WriteLine("George is sitting in his usual place in front of the TV.");
                    SaveData.npc1 = "George";
                    break;
                case 4:
                    Console.WriteLine("George and Evelyn are at the kitchen table. Evelyn's been baking again - something smells delicious.");
                    SaveData.npc1 = "George";
                    SaveData.npc2 = "Evelyn";
                        break;
                case 6:
                    Console.WriteLine("Nobody's home.");
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
