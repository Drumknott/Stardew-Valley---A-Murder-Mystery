using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class StardropSaloon : Location
    {
        private SaveData SaveData { get; set; }

        public StardropSaloon(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            Console.WriteLine("");
            Console.WriteLine("You are in the Stardrop Saloon. A friendly looking man behind the bar greets you.");

            Gus newNPC = new Gus(SaveData);
            newNPC.Chat();

            Console.WriteLine("");
            

        }

        public override void Forage()
        {
            Console.WriteLine("You can't forage in here.");
        }

        
    }
}
