using Stardew_Valley___A_Murder_Mystery.NPCs;
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

            if (SaveData.DayCount == 0)
            {
                Console.WriteLine("You are in the town square. Posters have been put up on every available surface: VOTE KENT TO SERVE THE COMMUNITY.");
                Console.WriteLine("Over these, rival posters have been stuck haphazardly: Vote Pierre, Joja OUT! And lastly, covering an entire wall of the Stardrop Saloon,");
                Console.WriteLine("is one giant billboard in Joja blue: For Modern Progress vote for Mayor Morris");
                Console.WriteLine("These people don't waste any time.");
                Console.WriteLine("Harvey is sitting on a bench nearby");
                Harvey harvey = new(SaveData);
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
                case 1: Console.WriteLine("You spot a " + randomItem + " half buried in the flowerbed."); break;
                case 2: Console.WriteLine("After searching for a few minutes you find a " + randomItem); break;
                default: break;
            }
        }
    }
}
