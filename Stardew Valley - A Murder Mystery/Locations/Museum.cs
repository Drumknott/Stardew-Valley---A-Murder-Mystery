using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class Museum : Location
    {
        private SaveData SaveData { get; set; }

        public Museum(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            Console.WriteLine("You are in the Museum. The displays and shelves are full of interesting artifacts and books.\n");

            switch (SaveData.DayCount)
            {
                case 0:
                case 3:
                case 6:
                    Console.WriteLine("The door is open but you can't see anyone here.");
                    break;
                case 1:
                case 2:
                    Console.WriteLine("Pennt is here browsing the shelves.");
                    SaveData.npc1 = "Penny";
                    break;                
                case 4:
                    Console.WriteLine("Penny and Caroline are both here, chatting about a book that Caroline is holding.");
                    SaveData.npc1 = "Penny";
                    SaveData.npc2 = "Caroline";
                    break;
                case 5:
                    Console.WriteLine("Harvey is sitting in a corner, reading.");
                    SaveData.npc1 = "Harvey";
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
