using Stardew_Valley___A_Murder_Mystery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class NorthOfTown : Location
    {
        private SaveData SaveData { get; set; }
        private List<Items> ForagableItems = new[] { Items.Amaranth, Items.BatteryPack, Items.BeanHotpot, Items.Bread, Items.ChocolateCake, Items.Clay, Items.Cloth, Items.Coconut, Items.Coffee, Items.Coleslaw, Items.CompleteBreakfast, Items.Corn, Items.CrabCakes, Items.Daffodil, Items.FarmersLunch, Items.FishTaco, Items.FriedCalamari, Items.GoatCheese, Items.Holly, Items.Honey, Items.Horseradish, Items.JojaCola, Items.Leek, Items.MapleBar, Items.RedMushroom, Items.Risotto, Items.VoidEgg}.ToList();
        public NorthOfTown(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            Console.WriteLine("You are North of Town.\n");

            switch (SaveData.DayCount)
            {
                case 0: 
                case 1:                
                case 4: 
                case 5:
                    Console.WriteLine("Linus is sitting by the campfire outside his tent.");
                    SaveData.npc1 = "Linus";
                    break;
                case 2:
                    Console.WriteLine("Linus is sitting by the lake. Further up the path, Demetrius is writing something on a clipboard.");
                    SaveData.npc1 = "Linus";
                    SaveData.npc2 = "Demetrius";
                    break;
                case 3:
                    Console.WriteLine("Linus is gazing out over the lake. Outside his house, Demetrius is writing something on his clipboard,\nand behind the house you can see Sebastian wandering yp towards the train tracks.");
                    SaveData.npc1 = "Linus";
                    SaveData.npc2 = "Demetrius";
                    SaveData.npc3 = "Sebastian";
                    break;
                case 6:
                    Console.WriteLine("It's a beautiful day, but nobody seems to be around. They must all be in town for the election.");
                    break;
                default: break;
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
                case 1: Console.WriteLine("You spot a " + randomItem + " half hidden under a bush."); break;
                case 2: Console.WriteLine("After searching for a few minutes you find a " + randomItem + " behind a tree."); break;
                default: break;
            }
        }
    }
}
