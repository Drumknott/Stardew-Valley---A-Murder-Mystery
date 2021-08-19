using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Willy : NPC
    {
        private SaveData SaveData { get; set; }

        public Willy(SaveData saveData)
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
