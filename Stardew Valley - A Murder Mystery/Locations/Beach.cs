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
        }

        public override void Forage()
        {

        }
    }
}
