using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class Cabin : Location
    {
        private SaveData SaveData { get; set; }

        public Cabin(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            SaveData.LastVisited = "Cabin";

            Console.WriteLine("You are back in your cabin at the farm. What would you like to do?\n");
            Console.WriteLine("R > Review your casefile");
            Console.WriteLine("S > Sleep until tomorrow");
            Console.WriteLine("L > Leave");

            switch(Console.ReadLine())
            {
                case "R":
                    CaseFile caseFile = new(SaveData);
                    caseFile.Notes();
                    break;
                case "S":
                    DayManager dayManager = new(SaveData);
                    dayManager.IncreaseDayCount();
                    break;
                case "L": return;
                default: break;
            }
        }

        public override void Forage()
        {
            Console.WriteLine("You can't forage in here.");
        }
    }
}
