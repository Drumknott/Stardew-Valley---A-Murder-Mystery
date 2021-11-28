using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class RobinDemetriusSebastianMarusHouse : Location
    {
        private SaveData SaveData { get; set; }

        public RobinDemetriusSebastianMarusHouse(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            Console.WriteLine("You are in Robin, Demetrius, Sebastian and Maru's house.\n");

            switch (SaveData.DayCount)
            {
                case 0:
                    Console.WriteLine("Robin is building something in her store. Sebastian is down in his room.\nDemetrius and Maru are working in the lab.");
                    SaveData.npc1 = "Robin";
                    SaveData.npc2 = "Demetrius";
                    SaveData.npc3 = "Sebastian";
                    SaveData.npc4 = "Maru";
                    break;
                case 1:
                    Console.WriteLine("Demetrius is in the lab, while Sebastian is down in his room.");
                    SaveData.npc1 = "Demetrius";
                    SaveData.npc2 = "Sebastian";
                    break;
                case 2:
                    Console.WriteLine("Robin and Sebastian are having coffee in the kitchen.");
                    SaveData.npc1 = "Robin";
                    SaveData.npc2 = "Sebastian";
                    break;
                case 3:
                    Console.WriteLine($"Robin is behind the counter of her store.\nRobin > Hi {SaveData.PlayerName}! If you're looking for the others they're not here right now I'm afraid.\nRobin > Have you tried outside?");
                    SaveData.npc1 = "Robin";
                    break;
                case 4:
                    Console.WriteLine("The only person here is Maru, who is so engrossed in whatever she's studying she doesn't even notice you.");
                    SaveData.npc1 = "Maru";
                    break;
                case 5:
                    Console.WriteLine("Demetrius is working away in his lab while Robin is in the kitchen. She seems annoyed about something.");
                    Console.WriteLine("Robin > Ugh, the one time the kids are out and we have the house to ourselves, and he still ignores me.");
                    SaveData.npc1 = "Robin";
                    SaveData.npc2 = "Demetrius";
                    break;
                case 6:
                    Console.WriteLine("The door is locked; no one's home.");
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
