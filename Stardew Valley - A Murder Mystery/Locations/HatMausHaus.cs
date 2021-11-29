using Stardew_Valley___A_Murder_Mystery.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class HatMausHaus : Location
    {
        private SaveData SaveData { get; set; }

        public HatMausHaus(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            SaveData.LastVisited = "HatMausHaus";

            if (SaveData.HatMausHaus != true)
            {
                Console.WriteLine("A mouse is sitting in one of the windows. It gestures to a selection of hats hanging around it.");
                SaveData.npc1 = "HatMouse";
                HatMaus hatMaus = new(SaveData);
                hatMaus.Chat();
                SaveData.HatMausHaus = true;
            }
            else
            {
                Console.WriteLine("You are at Hat Mouse's House. He has his usual array of hats on display.");
                SaveData.npc1 = "HatMouse";
            }
        }

        public override void Forage()
        {
            Console.WriteLine("Don't steal from Hat Mouse!");
        }
    }
}
