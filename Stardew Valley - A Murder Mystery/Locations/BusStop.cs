using Stardew_Valley___A_Murder_Mystery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class BusStop : Location
    {
        private SaveData SaveData { get; set; }
        private List<Items> ForagableItems = new[] {Items.Amaranth, Items.BatteryPack, Items.BeanHotpot, Items.Beer, Items.Bread, Items.ChocolateCake, Items.Clay, Items.Cloth, Items.Coffee, Items.Coleslaw, Items.CompleteBreakfast, Items.Corn, Items.CrabCakes, Items.Daffodil, Items.FarmersLunch, Items.FishTaco, Items.FriedCalamari, Items.GoatCheese, Items.Holly, Items.Honey, Items.Horseradish, Items.JojaCola, Items.Leek, Items.MapleBar, Items.RedMushroom, Items.Risotto, Items.VoidEgg }.ToList();

        public BusStop(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            SaveData.LastVisited = "Bus";

            if (SaveData.FreshOffTheBus == false)
            {
                SaveData.PamCount += 1;
                Console.WriteLine("Pam points.");
                Console.WriteLine("Pam > If you head left there that road will take you into town, or right will take you to Stardew Farm.");
                Console.WriteLine("Pam > Good luck, Detective " + SaveData.PlayerName, ".");
                Console.WriteLine("Pam locks the bus and hurries off.");
                Console.WriteLine("");

                SaveData.FreshOffTheBus = true;
                SaveData.BusStop = true;
                SaveData.Farm = true;
                SaveData.PelicanTown = true;
                Console.WriteLine("[BusStop] added to location list");
                Console.WriteLine("[Farm] added to Location list");
                Console.WriteLine("Pelican [Town] added to location list");
            }

            else switch (SaveData.DayCount)
            {
                case <4:
                case 5:
                    Console.WriteLine("You are at the bus stop.\n ");
                    Console.WriteLine("Pam is here, waiting by the bus. Is she always here?");
                    SaveData.npc1 = "Pam";
                    break;
                case 4:
                case 6:
                    Console.WriteLine("You are at the bus stop.\n");                   
                    Console.WriteLine("For once there's no one here. Could Pam be having a day off!?");
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
                case 1: Console.WriteLine("You spot a " + randomItem + " half buried under a bush."); break;
                case 2: Console.WriteLine("After searching for a few minutes you find a " + randomItem); break;
                default: break;
            }
        }
    }
}
