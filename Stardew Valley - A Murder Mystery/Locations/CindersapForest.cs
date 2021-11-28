using Stardew_Valley___A_Murder_Mystery.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class CindersapForest : Location
    {
        private SaveData SaveData { get; set; }

        public CindersapForest(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            Console.WriteLine("You are in Cindersap Forest.\n");

            switch (SaveData.DayCount)
            {
                case 0:
                    Console.WriteLine("Haley is taking photos down by the river");
                    SaveData.npc1 = "Haley";
                    break;
                case 1:
                    Console.WriteLine("The forest is lovely and peaceful. You don't see anyone here.");
                    break;
                case 2:
                case 3:
                    Console.WriteLine("Leah is outside her house, drawing in a sketchbook.");
                    SaveData.npc1 = "Leah";
                    break;
                case 4:
                case 6:
                    Console.WriteLine("There's a travelling lady waving at you from a cute little caravan. It's pulled by a... pig?");
                    break;
                case 5:
                    Console.WriteLine("Willy and the Wizard are up to THINGS"); // totally sus dark ritual to yoba
                    SaveData.npc1 = "Willy";
                    SaveData.npc2 = "Wizard";
                    break;
                default: break;
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
                case 1: Console.WriteLine("You spot a " + randomItem + " half hidden under a bush."); break;
                case 2: Console.WriteLine("After searching for a few minutes you find a " + randomItem +" behind a tree."); break;
                default: break;
            }
        }
    }
}
