using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class WizardsTower : Location
    {
        private SaveData SaveData { get; set; }

        public WizardsTower(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            Console.WriteLine("You are in the Wizard's Tower.\n");

            if (SaveData.WizardsTower != true)
            {
                Console.WriteLine("There is a circle of candles on the floor, and lots of dusty books on the shelves.\n");
                SaveData.WizardsTower = true;
            }

            switch (SaveData.DayCount)
            {                
                case <=4:
                    Console.WriteLine("The Wizard is here, stirring a large cauldron while he reads from an old book.");
                    SaveData.npc1 = "Wizard";
                    break;
                case 5:
                case 6:
                    Console.WriteLine("There's no one here. The cauldron bubbles ominously."); 
                    break;
                default: break;
            }
        }

        public override void Forage()
        {
            Console.WriteLine("You shouldn't forage in here. You never know what you might find.");
        }
    }
}
