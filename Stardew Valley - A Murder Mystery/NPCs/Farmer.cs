using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Farmer : NPC
    {
        private SaveData SaveData { get; set; }

        public Farmer(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Chat()
        {

        }

        public override void Gift()
        {

        }
    }
}
