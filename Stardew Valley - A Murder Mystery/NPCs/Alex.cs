using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Alex : NPC
    {
        private SaveData SaveData { get; set; }

        public Alex(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {

        }

        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give Alex?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            {
                if (gift == "Complete Breakfast" && Enums.Items.CompleteBreakfast > 0)
                {
                    Console.WriteLine("Alex > "); // Alex loves
                    SaveData.AlexFriendship += 2;

                    SaveData.MyInventory.TryGetValue(Enums.Items.CompleteBreakfast, out var completebreakfastCount);
                    completebreakfastCount--;
                    SaveData.MyInventory[Enums.Items.CompleteBreakfast] = completebreakfastCount;
                }

                if (gift == "Holly" && Enums.Items.Holly >0)
                {
                    Console.WriteLine("Alex > "); //Alex hates
                    SaveData.AlexFriendship--;

                    SaveData.MyInventory.TryGetValue(Enums.Items.Holly, out var hollyCount);
                    hollyCount--;
                    SaveData.MyInventory[Enums.Items.Holly] = hollyCount;
                }
            }
        }
    }
}
