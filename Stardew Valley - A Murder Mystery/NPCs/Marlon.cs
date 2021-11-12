using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Marlon : NPC
    {
        private SaveData SaveData { get; set; }

        public Marlon(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Marlon";

                if (SaveData.MarlonCount == 0) //first meeting
                {
                    Console.WriteLine("Marlon > Hey, good afternoon.");
                    SaveData.MarlonCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Marlon > Even with my bad leg, I never miss a town festival."); break;
                        case 1: Console.WriteLine("Marlon > Marnie looks lovely today..."); break;
                        case 2: Console.WriteLine("Marlon > Clint's blades get sharper every year. So do his prices..."); break;
                        case 3: Console.WriteLine("Marlon > Be careful if you go exploring in the mines. It can be dangerous in there."); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine();

                switch (dialogue1)
                {
                    case "C":
                        if (SaveData.Flashlight == false)
                        {
                            Console.WriteLine("Marlon > Say, I was clearing out one of my old boxes of junk and I found this flashlight. Would you like it? It might come in handy.");
                            SaveData.Flashlight = true;
                        }
                        else
                        {
                            Console.WriteLine("Me > How are you doing, Marlon? Don't you ever get lonely up here?");
                            Console.WriteLine("Marlon > Folks like me are used to being by themselves. Mind you, I would enjoy some of Miss Marnie's company.");
                        }
                        break;
                    case "G":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("");
                        Investigate();
                        break;
                    case "L": SaveData.MarlonCount++;
                        return;
                    default: break;
                }             
            }
        }

        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give Marlon?");
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
                Console.WriteLine("Marlon > "); // NPC loves
                Console.WriteLine(gift + " removed from Inventory.");
                SaveData.AbigailFriendship += 2;

                SaveData.MyInventory.TryGetValue(Enums.Items.Amethyst, out var amethystCount);
                amethystCount--;
                SaveData.MyInventory[Enums.Items.Amethyst] = amethystCount;
            }

            else if (gift == "hate" && Enums.Items.Horseradish > 0)
            {
                Console.WriteLine("Marlon > "); //NPC hates
                Console.WriteLine(gift + " removed from Inventory.");
                SaveData.AbigailFriendship--;

                SaveData.MyInventory.TryGetValue(Enums.Items.Horseradish, out var horseradishCount);
                horseradishCount--;
                SaveData.MyInventory[Enums.Items.Horseradish] = horseradishCount;
            }
            else //neutral
            {
                Console.WriteLine("Marlon > ");
                Console.WriteLine(gift + " removed from Inventory.");
            }
        }

        void Investigate()
        {

        }
    }
}
