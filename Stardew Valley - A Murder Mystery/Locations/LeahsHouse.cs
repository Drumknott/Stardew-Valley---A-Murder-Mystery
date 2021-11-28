using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class LeahsHouse : Location
    {
        private SaveData SaveData { get; set; }

        public LeahsHouse(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            Console.WriteLine("You are in Leah's house.\n");

            switch (SaveData.DayCount)
            {
                case 0:
                case > 1:
                    Console.WriteLine("No one's home.");
                    break;
                case 1:
                    Console.WriteLine("Leah's here, working on one of her sculptures.");
                    SaveData.npc1 = "Leah";
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
