using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class TemplateNPC : NPC
    {
        private SaveData SaveData { get; set; }

        public TemplateNPC (SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Chat()
        {
            SaveData.LastChat = "NPCname";

            if (SaveData.ElliotCount == 0) //first meeting
            {
                Console.WriteLine("");
                SaveData.ElliotCount++;
            }

            else
            {
                Random dialogue = new();
                int random = dialogue.Next(0, 10);

                switch (random) //random dialogue
                {
                    case 0: Console.WriteLine(""); break;
                    case 1: Console.WriteLine(""); break;
                    case 2: Console.WriteLine(""); break;
                    case 3: Console.WriteLine(""); break;
                    case 4: Console.WriteLine(""); break;
                    case 5: Console.WriteLine(""); break;
                    case 6: Console.WriteLine(""); break;
                    case 7: Console.WriteLine(""); break;
                    case 8: Console.WriteLine(""); break;
                    case 9: Console.WriteLine(""); break;
                    default: break;
                }
                //player dialogue options
                Console.WriteLine(""); //chat
                Console.WriteLine(""); //gift
                Console.WriteLine(""); //investigate

                var dialogue1 = Console.ReadLine();

                switch (dialogue1)
                {
                    case "chat":
                        Console.WriteLine("");
                        SaveData.ElliotFriendship++;
                        break;
                    case "gift":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "investigate":
                        Console.WriteLine("");
                        Investigate();
                        break;
                    default: break;
                }

                SaveData.ElliotCount++;
            }
        }

        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give NPC?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            if (gift.Length == 0)
            {
                return;
            }
            
            else if (gift == "Fav" && Enums.Items.Amethyst > 0)
            {
                Console.WriteLine(""); // NPC loves
                Console.WriteLine(gift + " removed from Inventory.");
                SaveData.AbigailFriendship += 2;

                SaveData.MyInventory.TryGetValue(Enums.Items.Amethyst, out var amethystCount);
                amethystCount--;
                SaveData.MyInventory[Enums.Items.Amethyst] = amethystCount;
            }

            else if (gift == "hate" && Enums.Items.Horseradish > 0)
            {
                Console.WriteLine(""); //NPC hates
                Console.WriteLine(gift + " removed from Inventory.");
                SaveData.AbigailFriendship--;

                SaveData.MyInventory.TryGetValue(Enums.Items.Horseradish, out var horseradishCount);
                horseradishCount--;
                SaveData.MyInventory[Enums.Items.Horseradish] = horseradishCount;
            }
            else //neutral
            {
                Console.WriteLine("Abigail > You brought me a present? Thanks.");                              
                Console.WriteLine(gift + " removed from Inventory.");
            }            
        }

        void Investigate()
        {

        }
    }
}
