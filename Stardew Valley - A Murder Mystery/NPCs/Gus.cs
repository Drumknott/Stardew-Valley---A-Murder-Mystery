using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Gus : NPC
    {
        private SaveData SaveData { get; set; }

        public Gus(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {

            if (SaveData.GusCount == 0)
            {
                //first meeting with Gus
                Console.WriteLine("Gus > Hi, I'm Gus.");
                SaveData.GusCount += 1;
            }
        }

        public override void Gift()
        {

        }
    }
}
