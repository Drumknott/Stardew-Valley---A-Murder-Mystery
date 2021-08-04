using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    public class Pam : NPC
    {
        private SaveData SaveData { get; set; }

        public Pam(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            

            if (SaveData.PamCount == 0)
            {
                //first meeting with Pam
            }
        }
        
        
        
    }
}
