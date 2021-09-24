using Stardew_Valley___A_Murder_Mystery.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Beach : Location
    {
        private SaveData SaveData { get; set; }

        public Beach(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            SaveData.LastVisited = "Beach";

            if (SaveData.Beach == false)
            {
                SaveData.Beach = true;
                SaveData.ElliottsCabin = true;
                SaveData.WillysShack = true;
                Console.WriteLine("[Beach] added to location list");
                Console.WriteLine("[Elliots] Cabin added to location list");
                Console.WriteLine("[Willys] Shack added to location list");
                Console.WriteLine("");
            }
            Console.WriteLine(" You are at the beach.");

            if (SaveData.DayCount == 1 || SaveData.DayCount == 2)
            {
                Console.WriteLine("");
                Console.WriteLine("Elliot is standing outside his house, admiring the waves rolling in.");              
                Console.WriteLine("Further down you can see Willy fishing off the quay.");

                Elliot elliot = new(SaveData);
                Willy willy = new (SaveData);
            }
        }

        public override void Forage()
        {

        }
    }
}
