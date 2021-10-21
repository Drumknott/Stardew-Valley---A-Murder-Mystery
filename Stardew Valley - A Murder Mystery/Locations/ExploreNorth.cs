using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class ExploreNorth : Location
    {
        private SaveData SaveData { get; set; }

        public ExploreNorth(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            Console.WriteLine("Further up the path past the Community Centre you come to a house with a workshop at the side and a telescope on the roof.");
            SaveData.Robins = true;
            Console.WriteLine("To the west is a path that leads to Stardew Farm.");
            Console.WriteLine("To the East is a large lake. On the north shore of the lake you can see a large cave entrance, and a building next to it.");
            Console.WriteLine("On the other side of the lake a bridge leads to a quarry.");
            SaveData.Mine = true;
            SaveData.AdventurersGuild = true;
            SaveData.Quarry = true;
            Console.WriteLine("[Mine] added to location list");
            Console.WriteLine("Adventurer's [Guild] added to location list");
            Console.WriteLine("[Quarry] added to location list");                       
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
                case 1: Console.WriteLine("You spot a " + randomItem + " hidden behind a tree."); break;
                case 2: Console.WriteLine("After searching for a few minutes you find a " + randomItem); break;
                default: break;
            }
        }
    }
}
