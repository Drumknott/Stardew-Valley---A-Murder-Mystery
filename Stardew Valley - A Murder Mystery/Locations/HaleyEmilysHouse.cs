using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class HaleyEmilysHouse : Location
    {
        private SaveData SaveData { get; set; }

        public HaleyEmilysHouse(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            Console.WriteLine("You are in Emily and Haley's house.\n");

            switch (SaveData.DayCount)
            {
                case 0:
                case 1:
                case 4:
                case 6:
                    Console.WriteLine("No-one's home.");
                    break;
                case 2:
                    Console.WriteLine("Haley and Alex are sitting on the sofa, giggling together.");
                    SaveData.npc1 = "Haley";
                    SaveData.npc2 = "Alex";
                    break;
                case 3:
                    Console.WriteLine("Emily is humming to herself while she works at her sewing machine.");
                    SaveData.npc1 = "Emily";
                    break;
             
                case 5:
                    Console.WriteLine("Emily is cooking something in the kitchen while Haley reads a magazine.");
                    SaveData.npc1 = "Emily";
                    SaveData.npc2 = "Haley";
                    break;
           
                default: break;
            }
        }

        public override void Forage()
        {
            Console.WriteLine("You can't forage in here.");
        }
    }
}
