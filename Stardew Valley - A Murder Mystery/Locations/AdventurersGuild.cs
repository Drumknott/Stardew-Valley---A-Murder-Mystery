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
            Console.WriteLine("");
        }

        public override void Forage()
        {

        }
    }
}
