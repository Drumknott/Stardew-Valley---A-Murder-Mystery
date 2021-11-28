using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class JodiKentSamsHouse : Location
    {
        private SaveData SaveData { get; set; }

        public JodiKentSamsHouse(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            Console.WriteLine("You are in Jodi, Kent and Sam's house.\n");

            switch (SaveData.DayCount)
            {
                case 0:
                    Console.WriteLine("Jodi and Kent are here, organising what looks like stacks of campaign posters.");
                    SaveData.npc1 = "Jodi";
                    SaveData.npc2 = "Kent";
                    break;
                case 1:
                    Console.WriteLine("You can here the sound of an electric guitar coming from Sam's room. No one else is here.");
                    SaveData.npc1 = "Sam";
                    break;
                case 2:
                    Console.WriteLine("Kent is scribbling furiously in a notebook.");
                    SaveData.npc1 = "Kent";
                    break;
                case 3:
                    Console.WriteLine("Jodi is here, trying to clean around the mountains of campaign material.");
                    SaveData.npc1 = "Jodi";
                    break;
                case 4:
                case 6:
                    Console.WriteLine("There's no one here.");
                    break;
                case 5:
                    Console.WriteLine("Jodi is eating a pizza while watching TV. Sam and Sebastian are hanging out in Sam's room.");
                    SaveData.npc1 = "Jodi";
                    SaveData.npc2 = "Sam";
                    SaveData.npc3 = "Sebastian";
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
