using Stardew_Valley___A_Murder_Mystery.NPCs;
using Stardew_Valley___A_Murder_Mystery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class PelicanTown : Location
    {
        private SaveData SaveData { get; set; }
        private List<Items> ForagableItems = new[] { Items.Amaranth, Items.BatteryPack, Items.BeanHotpot, Items.Bread, Items.ChocolateCake, Items.Clay, Items.Cloth, Items.Coconut, Items.Coffee, Items.Coleslaw, Items.CompleteBreakfast, Items.Corn, Items.CrabCakes, Items.Daffodil, Items.FarmersLunch, Items.FishTaco, Items.FriedCalamari, Items.GoatCheese, Items.Holly, Items.Honey, Items.Horseradish, Items.JojaCola, Items.Leek, Items.MapleBar, Items.RedMushroom, Items.Risotto, Items.VoidEgg }.ToList();

        public PelicanTown(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            if (SaveData.TownFirstVisit == false)
            {
                ExploreTown exploreTown = new(SaveData);
                exploreTown.Enter();
            }
            else
            {
                Console.WriteLine("You are in the Town square.\n");

                switch (SaveData.DayCount)
                {
                    case 0:
                        Console.WriteLine("Posters have been put up on every available surface: VOTE KENT TO SERVE THE COMMUNITY.");
                        Console.WriteLine("Over these, rival posters have been stuck haphazardly: Vote Pierre, Joja OUT! And lastly, covering an entire wall of the Stardrop Saloon,");
                        Console.WriteLine("is one giant billboard in Joja blue: For Modern Progress vote for Mayor Morris");
                        Console.WriteLine("These people don't waste any time.");
                        Console.WriteLine("Harvey is sitting on a bench nearby, and you can see Penny reading a book by the flowerbeds.");
                        SaveData.npc1 = "Harvey";
                        SaveData.npc2 = "Penny";
                        break;
                    case 1:
                        Console.WriteLine("Abigail is hanging out by her dad's store. Haley is wondering past towards the Community Centre.");
                        Console.WriteLine("And in the middle of the square is Kent, fully dressed in a stars and stripes suit, handing out fliers to everyone he sees.");
                        SaveData.npc1 = "Abigail";
                        SaveData.npc2 = "Haley";
                        SaveData.npc3 = "Kent";
                        break;
                    case 2:
                        Console.WriteLine("Harvey and Maru are chatting outside the clinic, while Evelyn tends to the flowerbeds by the saloon.");
                        SaveData.npc1 = "Evelyn";
                        SaveData.npc2 = "Harvey";
                        SaveData.npc3 = "Maru";
                        break;
                    case 3:
                        Console.WriteLine("Kent is speaking excitedly to a small group of townsfolk that have gathered around him; Abigail, Caroline, Haley, Penny and Sam.");
                        Console.WriteLine("Kent > Now you all know me. I've proven my worth by serving my community while I was in the army - now let me prove it again. Vote for Kent!");
                        SaveData.npc1 = "Abigail";
                        SaveData.npc2 = "Caroline";
                        SaveData.npc3 = "Haley";
                        SaveData.npc4 = "Kent";
                        SaveData.npc5 = "Penny";
                        SaveData.npc6 = "Sam";
                        break;
                    case 4:
                        Console.WriteLine("Alex and Haley are chatting outside the saloon. Kent is wandering around the square trying to canvas more voters.");
                        SaveData.npc1 = "Alex";
                        SaveData.npc2 = "Haley";
                        SaveData.npc3 = "Kent";
                        break;
                    case 5:
                        Console.WriteLine("The square is empty apart from Kent. From the noise you guess everyone is in the saloon; \nKent seems to be loitering outside to catch people as they leave.");
                        SaveData.npc1 = "Kent";
                        break;
                    case 6:
                        ElectionDay election = new(SaveData);
                        election.Election();
                        break;
                    default: break;
                }
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
                case 1: Console.WriteLine("You spot a " + randomItem + " half buried in the flowerbed."); break;
                case 2: Console.WriteLine("After searching for a few minutes you find a " + randomItem); break;
                default: break;
            }
        }
    }
}
