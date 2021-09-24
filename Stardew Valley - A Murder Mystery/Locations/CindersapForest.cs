using Stardew_Valley___A_Murder_Mystery.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class CindersapForest : Location
    {
        private SaveData SaveData { get; set; }

        public CindersapForest(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            SaveData.LastVisited = "Cindersap";

            Console.WriteLine("You are in Cindersap Forest.");

            if (SaveData.DayCount == 0)
            {
                Console.WriteLine("Haley is taking photos down by the river");
                Hayley haley = new (SaveData);
            }

            if (SaveData.DayCount == 2 || SaveData.DayCount == 3)
            {
                Console.WriteLine("Leah is outside her house, drawing in a sketchbook.");
                Leah leah = new(SaveData);
            }

            if (SaveData.DayCount == 4)
            {
                Console.WriteLine("There's a travelling lady waving at you from a cute little caravan. It's pulled by a... pig?");
                //travelling lady
            }

            if (SaveData.DayCount == 5)
            {
                Console.WriteLine("Willy and the Wizard are up to THINGS"); // totally sus dark ritual to yoba
                Willy willy = new(SaveData);
                Wizard wizard = new (SaveData);
            }

            if (SaveData.DayCount == 6)
            {
                Console.WriteLine("There's a travelling lady waving at you from a cute little caravan. It's pulled by a... pig?");
                //travelling lady
            }

            else
            {
                Console.WriteLine("The forest is lovely and peaceful. You don't see anyone here.");
            }
        }

        public override void Forage()
        {

        }
    }
}
