using Stardew_Valley___A_Murder_Mystery.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Beach : Location
    {
        private SaveData SaveData { get; set; }

        public Beach(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            SaveData.LastVisited = "Beach";

            if (SaveData.Beach == false)
            {
                SaveData.Beach = true;
                SaveData.ElliottsCabin = true;
                SaveData.WillysShack = true;
                Console.WriteLine("[Beach] added to location list");
                Console.WriteLine("[Elliots] Cabin added to location list");
                Console.WriteLine("[Willys] Shack added to location list");
                Console.WriteLine("");
            }

            else if (SaveData.DayCount == 0 || SaveData.DayCount == 3)
            {
                Console.WriteLine("You are at the Beach");
            }

            else if (SaveData.DayCount == 1 || SaveData.DayCount == 2)
            {
                Console.WriteLine(" You are at the beach.");
                Console.WriteLine("");
                Console.WriteLine("Elliot is standing outside his house, admiring the waves rolling in.");
                Console.WriteLine("Further down you can see Willy fishing off the quay.");

                SaveData.npc1 = "Willy";
                SaveData.npc2 = "Elliott";
            }

            else if (SaveData.DayCount == 4 || SaveData.DayCount == 6)
            {
                Console.WriteLine("You are at the beach. You can't see anybody else here.");
            }

            else if (SaveData.DayCount == 5)
            {
                Console.WriteLine("You are at the beach.");
                Console.WriteLine("");
                Console.WriteLine("Elliot is standing on the quay, staring out to sea as if lost in thought.");

                SaveData.npc1 = "Elliott";
            }
        }

        public override void Forage()
        {
            Forage_Randomiser randomiser = new(SaveData);
            var randomItem = randomiser.ForageRandomiser();

            RandomForageDialogue(randomItem);

            if (SaveData.MyInventory.TryGetValue(randomItem, out var randomItemCount))
            {
                randomItemCount++;
            }
            else
            {
                randomItemCount = 1;
            }
            SaveData.MyInventory[randomItem] = randomItemCount;
            Console.WriteLine(randomItem + " added to Inventory");
        }

        private static void RandomForageDialogue(Enums.Items randomItem)
        {
            Random dialogue = new();
            int random = dialogue.Next(0, 2);

            switch (random)
            {
                case 0: Console.WriteLine("You have found a " + randomItem); break;
                case 1: Console.WriteLine("You spot a " + randomItem + " half buried in the sand."); break;
                case 2: Console.WriteLine("After searching for a few minutes you find a " + randomItem); break;
                default: break;
            }
        }
    }
}
