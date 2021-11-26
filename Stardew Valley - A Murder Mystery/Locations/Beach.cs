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
            Console.WriteLine("You are at the beach.\n");

            if (SaveData.Beach == false)
            {
                SaveData.Beach = true;                
                Console.WriteLine("[Beach] added to location list\n");                
            }

            else switch (SaveData.DayCount)
            {
                case 0:
                case 3:
                    Console.WriteLine("You can see Willy fishing from the pier.");
                    SaveData.npc1 = "Willy";
                    break;
                case 1:
                case 2:
                    Console.WriteLine("Elliot is standing outside his house, admiring the waves rolling in.");
                    Console.WriteLine("Further down you can see Willy fishing off the quay.");
                    SaveData.npc1 = "Willy";
                    SaveData.npc2 = "Elliott";
                    break;
                case 4:
                case 6:
                    Console.WriteLine("You can't see anybody else here today.");
                    break;
                case 5:
                    Console.WriteLine("Elliott is standing on the quay, staring out to sea as if lost in thought.");
                    SaveData.npc1 = "Elliott";
                    break;
                default: break;
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
