using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class CommunityCentre : Location
    {
        private SaveData SaveData { get; set; }

        public CommunityCentre(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            SaveData.LastVisited = "Cindersap";
            Console.WriteLine("You are in the old Community Centre");

            switch (SaveData.DayCount)
            {
                case < 5:
                case 6:
                    Console.WriteLine("The place looks like it's falling apart. No wonder Jojamart wants to use it as a warehouse.\nThere's nobody here.");
                    break;
                case 5:
                    Console.WriteLine("Penny and Maru are both here doing some cleaning.");
                    SaveData.npc1 = "Penny";
                    SaveData.npc2 = "Maru";
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
                case 1: Console.WriteLine("You spot a " + randomItem + " hidden by some undergrowth."); break;
                case 2: Console.WriteLine("After searching for a few minutes you find a " + randomItem); break;
                default: break;
            }
        }
    }
}
