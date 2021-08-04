using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    public abstract class NPC
    {
        private SaveData SaveData { get; set; }

        public abstract void Chat();
        public abstract void Gift();
    }
}
