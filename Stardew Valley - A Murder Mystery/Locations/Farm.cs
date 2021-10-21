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

            Console.WriteLine("");
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
                case 1: Console.WriteLine("You spot a " + randomItem + " half buried under a bush."); break;
                case 2: Console.WriteLine("After searching for a few minutes you find a " + randomItem); break;
                default: break;
            }
        }
    }
}
