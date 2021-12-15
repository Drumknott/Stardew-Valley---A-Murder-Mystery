using Stardew_Valley___A_Murder_Mystery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Farm : Location
    {
        private SaveData SaveData { get; set; }
        private List<Items> ForagableItems = new[] { Items.Amaranth, Items.BatteryPack, Items.BeanHotpot, Items.Beer, Items.Bread, Items.ChocolateCake, Items.Clay, Items.Cloth, Items.Coffee, Items.Coleslaw, Items.CompleteBreakfast, Items.Corn, Items.CrabCakes, Items.Daffodil, Items.FarmersLunch, Items.FishTaco, Items.FriedCalamari, Items.GoatCheese, Items.Holly, Items.Honey, Items.Horseradish, Items.JojaCola, Items.Leek, Items.MapleBar, Items.RedMushroom, Items.Risotto, Items.VoidEgg }.ToList();

        public Farm (SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            SaveData.LastVisited = "Farm";

            if (SaveData.FarmFirstVisit == false)
            {
                Console.WriteLine("");
                Console.WriteLine("You pass a wooden sign that says 'Stardew Farm'. It has a name written underneath, but it's hard to read.");
                Console.WriteLine("You lean in closer. It's the name of the farmer, but their name is obscured by dirt. What does it say?");
                Console.WriteLine("Farmer ____________");
                SaveData.FarmerName = Console.ReadLine();
                Console.WriteLine("As you carry on along the path you see a pretty farmhouse with a barn, silo and a greenhouse behind it");
                Console.WriteLine("A farmer is feeding chickens in a small yard, and waves when they see you.");
                Farmer farmer = new(SaveData);
                farmer.Chat();
                SaveData.FarmFirstVisit = true;
            }
            else
            {
                Console.WriteLine("You are at Stardew Farm.\n");
                Console.WriteLine($"Farmer {SaveData.FarmerName} is here, tending to the animals.");
                SaveData.npc1 = "Farmer";
                SaveData.npc2 = SaveData.FarmerName;
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
                case 1: Console.WriteLine("You spot a " + randomItem + " half buried under a bush."); break;
                case 2: Console.WriteLine("After searching for a few minutes you find a " + randomItem); break;
                default: break;
            }
        }
    }
}
