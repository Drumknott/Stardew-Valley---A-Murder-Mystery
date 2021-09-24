using Stardew_Valley___A_Murder_Mystery.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class GeneralStore : Location
    {
        private SaveData SaveData { get; set; }

        public GeneralStore(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            SaveData.LastVisited = "Pierres";

            Console.WriteLine("You are in Pierre's General Store.");
            Console.WriteLine("");

            if (SaveData.DayCount == 0)
            {
                Console.WriteLine("Pierre is behind the counter. Marnie and Leah are browsing the shelves.");
                Pierre pierre = new(SaveData);
                Marnie marnie = new(SaveData);
                Leah leah = new(SaveData);
            }

            if (SaveData.DayCount == 1)
            {
                //aerobics day
                Console.WriteLine("Pierre is minding the shop, but there are no customers today.");
                Pierre pierre = new (SaveData);
                Console.WriteLine("The door to the back room is open, and you can hear voices and laughter from inside.");
                Console.WriteLine("");
                Console.WriteLine("I > Investigate the back room");
                Console.WriteLine("S > Stay in the store");
                var investigate = Console.ReadLine();

                if (investigate == "I")
                {
                    //aerobics class
                    Caroline caroline = new (SaveData);
                    Robin robin = new (SaveData);
                    Jodi jodi = new (SaveData);
                    Emily emily = new (SaveData);
                    Marnie marnie = new (SaveData);
                }
            }
        }

        public override void Forage()
        {
            Console.WriteLine("When Pierre's not looking, you swipe a candy bar off one of the shelves. Gosh, what a jerk."); //lol
            
            SaveData.MyInventory.TryGetValue(Enums.Items.MapleBar, out var mapleBarCount);
            mapleBarCount++;
            SaveData.MyInventory[Enums.Items.RedMushroom] = mapleBarCount;
        }
    }
}
