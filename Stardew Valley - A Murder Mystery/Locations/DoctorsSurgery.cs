using Stardew_Valley___A_Murder_Mystery.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class DoctorsSurgery : Location
    {
        private SaveData SaveData { get; set; }

        public DoctorsSurgery(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            SaveData.LastVisited = "Clinic";

            Console.WriteLine("You are in the Doctor's Surgery.\n");
            
            if (SaveData.DayCount == 1 || SaveData.DayCount == 3)
            {
                Console.WriteLine("Maru is behind the desk, chatting with Harvey. The waiting room is empty.");
                SaveData.npc1 = "Harvey";
                SaveData.npc2 = "Maru";
            }

            else
            {
                Console.WriteLine("The clinic is empty. Where is everyone?");
            }
        }

        public override void Forage()
        {
            Console.WriteLine("You can't forage in here.");
        }        
    }
}
