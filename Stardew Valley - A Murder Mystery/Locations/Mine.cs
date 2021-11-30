using Stardew_Valley___A_Murder_Mystery.Enums;
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

        private List<Items> ForagableMineItems = new[] { Items.Amethyst, Items.BatteryPack, Items.Clay, Items.Coal, Items.Diamond, Items.Emerald, Items.FrozenTear, Items.JojaCola, Items.PrismaticShard, Items.Quartz, Items.VoidEssence}.ToList();
        public Mine (SaveData saveData)
        {
            SaveData = saveData;
        }


        public override void Enter()
        {          
            Console.WriteLine("You are at the Mine\n");

            if (SaveData.MineCount == 0)
            {
                Console.WriteLine("It's dark, but through the gloom you can just make out the shape of a ladder descending into the earth.\n");
                SaveData.MineCount++;
            }
            else Console.WriteLine("You can here a faint dripping noise, but otherwise it's eerily quiet.");
            Console.WriteLine("E > Explore the Mine");
            Console.WriteLine("L > Leave");

            switch (Console.ReadLine().Substring(0, 1).ToUpper())
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
            var random = new Random();
            var Index = random.Next(0, ForagableMineItems.Count - 1);
            var randomItem = ForagableMineItems[Index];

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
