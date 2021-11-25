using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class HatMaus //okay poke?
    {
        private SaveData SaveData { get; set; }

        public HatMaus(SaveData saveData)
        {
            SaveData = saveData;
        }
        public void Chat()
        {
            Console.WriteLine("Hat Mouse > Me sell hats, okay poke?");
        }        
    }
}
