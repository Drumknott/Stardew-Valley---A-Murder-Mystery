using Stardew_Valley___A_Murder_Mystery.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class AdventurersGuild : Location
    {
        private SaveData SaveData { get; set; }

        public AdventurersGuild(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            SaveData.LastVisited = "Guild";

            if (SaveData.DayCount <6)
            {
                Console.WriteLine("You are in the Adventurer's Guild. Marlon is behind the counter.");
                Marlon marlon = new Marlon(SaveData);


            }

            else if (SaveData.DayCount == 6)
            {
                Console.WriteLine("You are in the Adventurer's Guild. There's no one here.");
            }
        }

        public override void Forage()
        {
            Console.WriteLine("Marlon's watching you.");
            Console.WriteLine("Marlon > Hey, what are you doing!? You'd better not steal anything.");
        }
    }
}
