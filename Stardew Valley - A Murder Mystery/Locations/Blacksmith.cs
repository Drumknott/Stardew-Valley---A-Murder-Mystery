using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class Blacksmith : Location
    {
        private SaveData SaveData { get; set; }

        public Blacksmith(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            SaveData.LastVisited = "Blacksmith";
            Console.WriteLine("You are in the Blacksmith's.");

            switch(SaveData.DayCount)
            {
                case <6:
                    Console.WriteLine("Clint is here manning the forge.");
                    SaveData.npc1 = "Clint";
                    break;                
                case 6:
                    Console.WriteLine("There's no-one here.");
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
