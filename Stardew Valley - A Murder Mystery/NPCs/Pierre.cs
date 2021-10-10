using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Pierre : NPC
    {
        private SaveData SaveData { get; set; }

        public Pierre(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            SaveData.LastChat = "Pierre";

            if (SaveData.DayCount == 1)
            {
                //chat about aerobics day
            }
        }

        public override void Gift()
        {
            //add gift option for joja cola and the candy you can steal from the store
        }
    }
}
