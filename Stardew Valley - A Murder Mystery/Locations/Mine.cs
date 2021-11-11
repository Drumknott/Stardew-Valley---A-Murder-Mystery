using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Mine : Location
    {
        private SaveData SaveData { get; set; }

        public Mine (SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {          
            SaveData.LastVisited = "Mine";
            Console.WriteLine("You are at the Mine\n");

            if (SaveData.MineCount == 0)
            {
                Console.WriteLine("It's dark, but through the gloom you can just make out the shape of a ladder descending into the earth.\n");
                SaveData.MineCount++;
            }

            Console.WriteLine("E > Explore the Mine");
            Console.WriteLine("L > Leave");

            switch (Console.ReadLine())
            {
                case "E":
                    MineMinigame minigame = new(SaveData);
                    minigame.ExploreTheMine();
                    break;
                case "L": return;
                default: return;
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
                case 1: Console.WriteLine("You spot a " + randomItem + " half buried in the dirt."); break;
                case 2: Console.WriteLine("After searching for a few minutes you find a " + randomItem); break;
                default: break;
            }
        }
    }
}
