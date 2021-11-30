using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class Graveyard : Location
    {
        private SaveData SaveData { get; set; }

        public Graveyard(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            Console.WriteLine("You are in the Graveyard.\n");

            if (SaveData.DayCount == 3)
            {
                Console.WriteLine("Abigail is here.");
                SaveData.npc1 = "Abigail";
            }
            else Console.WriteLine("There's no one here.");
        }

        public override void Forage()
        {
            Console.WriteLine("...Really?");
        }
    }
}
