using Stardew_Valley___A_Murder_Mystery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class Sewers : Location
    {
        private SaveData SaveData { get; set; }
        private List<Items> ForagableItems = new[] { Items.Amethyst, Items.BatteryPack, Items.Clam, Items.SuperCucumber, Items.Coal, Items.Coral, Items.Diamond, Items.Emerald, Items.FrozenTear, Items.JojaCola, Items.Octopus, Items.PrismaticShard, Items.Quartz, Items.Seaweed, Items.VoidEgg }.ToList();

        public Sewers(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            if (SaveData.SewerKey != true)
            {
                Console.WriteLine("You need a key to get down to the sewers.");
                SaveData.FindSewerKey = true;
                return;
            }

            Console.WriteLine("You are in the sewers.\n");

            if (SaveData.DayCount < 6)
            {
                Console.WriteLine("You can just make out Krobus through the mist.");
                SaveData.npc1 = "Krobus";
            }
            else
            {
                Console.WriteLine("There's no sign of anyone here.");
            }
        }

        public override void Forage()
        {
            var random = new Random();
            var Index = random.Next(0, ForagableItems.Count - 1);
            var randomItem = ForagableItems[Index];

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
