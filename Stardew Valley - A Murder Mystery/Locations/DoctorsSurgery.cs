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

            Console.WriteLine("You are in the Doctor's Surgery.");
            Console.WriteLine("");

            if (SaveData.DayCount == 1 || SaveData.DayCount == 3)
            {
                Console.WriteLine("Maru is behind the desk, chatting with Harvey. The waiting room is empty.");
                Harvey harvey = new (SaveData);
                Maru maru = new (SaveData);
            }

            else
            {
                Console.WriteLine("The clinic is empty. Where is everyone?");
            }
        }

        public override void Forage()
        {

        }
    }
}
