using Stardew_Valley___A_Murder_Mystery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Abigail : NPC
    {
        private SaveData SaveData { get; set; }

        public Abigail(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            SaveData.LastChat = "Abigail";

            if (SaveData.AbigailCount == 0)
            {
                //first meeting with Abigail
                Console.WriteLine("");
                SaveData.AbigailCount += 1;
            }
        }

        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give Abigail?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            {
                if (gift == "Amethyst" && Enums.Items.Amethyst >0)
                {
                    Console.WriteLine("Abigail > Hey, how’d you know I was hungry? This looks delicious!"); // Abi loves
                    SaveData.AbigailFriendship +=2;

                    SaveData.MyInventory.TryGetValue(Enums.Items.Amethyst, out var amethystCount);
                    amethystCount--;
                    SaveData.MyInventory[Enums.Items.Amethyst] = amethystCount;
                }

                if (gift == "Horseradish" && Enums.Items.Horseradish > 0)
                {
                    Console.WriteLine("Abigail > What am I supposed to do with this ?"); //Abi hates
                    SaveData.AbigailFriendship --;

                    SaveData.MyInventory.TryGetValue(Enums.Items.Horseradish, out var horseradishCount);
                    horseradishCount--;
                    SaveData.MyInventory[Enums.Items.Horseradish] = horseradishCount;
                }
                //else if [neutral gift]
                    
            }

            Console.WriteLine("Abigail > You brought me a present ? Thanks."); //Abi neutral
            

        }

    }
}
