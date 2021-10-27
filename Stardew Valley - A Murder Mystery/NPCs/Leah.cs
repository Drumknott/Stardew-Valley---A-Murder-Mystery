﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Leah : NPC
    {
        private SaveData SaveData { get; set; }

        public Leah(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Leah";

                if (SaveData.LeahCount == 0) //first meeting
                {
                    Console.WriteLine("Leah > Hello, it's nice to meet you. You picked a good time to visit... The spring is lovely.");
                    SaveData.LeahCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Leah > Hi. Oh, you want to talk? The landscape around here gives me a lot of ideas. The terrain is almost like a sculpture itself."); break;
                        case 1: Console.WriteLine("Leah > I don't make art for money. It's just an urge that I have."); break;
                        case 2: Console.WriteLine("Leah > This morning I accidentally stepped on a bug. Sometimes I think it's impossible to live without destroying nature in some way."); break;
                        case 3: Console.WriteLine("Leah > There's actually a lot of wild food in this area, if you know where to look. I've been having fresh salads almost every day."); break;
                        case 4: Console.WriteLine("Leah > It's simpler to be friends with the trees. They don't have much to say."); break;
                        case 5: Console.WriteLine("Leah > We wouldn't be able to survive without nature. It's good to remember that."); break;
                        case 6: Console.WriteLine($"Leah > Hello, {SaveData.PlayerName}. It's a nice day, isn't it? Stop by my cabin if you ever need someone to talk to."); break;
                        case 7: Console.WriteLine("Leah > I love to decorate for the different seasons."); break;
                        case 8: Console.WriteLine("Leah > If you hear any banging from inside my hut, it's probably just me working on one of my sculptures."); break;
                        default: break;
                    }
                }

                Console.WriteLine("");
                Console.WriteLine(""); //chat
                Console.WriteLine(""); //gift
                Console.WriteLine(""); //investigate
                Console.WriteLine("L > Leave");

                var dialogue1 = Console.ReadLine();

                switch (dialogue1)
                {
                    case "chat":
                        Console.WriteLine("");
                        SaveData.LeahFriendship++;
                        break;
                    case "gift":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "investigate":
                        Console.WriteLine("");
                        Investigate();
                        break;
                    case "L": SaveData.LeahCount++;
                        return;
                    default: break;
                }            
            }
        }

        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give Leah?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            if (gift.Length == 0)
            {
                return;
            }

            else if (gift == "Fav" && Enums.Items.GoatCheese > 0)
            {
                Console.WriteLine("Leah > Oh! This is exactly what I wanted! Thank you!"); // NPC loves
                Console.WriteLine(gift + " removed from Inventory.");
                SaveData.LeahFriendship += 2;

                SaveData.MyInventory.TryGetValue(Enums.Items.GoatCheese, out var goatCheeseCount);
                goatCheeseCount--;
                SaveData.MyInventory[Enums.Items.GoatCheese] = goatCheeseCount;
            }

            else if (gift == "hate" && Enums.Items.Bread > 0)
            {
                Console.WriteLine("Leah > This is a pretty terrible gift, isn't it?"); //NPC hates
                Console.WriteLine(gift + " removed from Inventory.");
                SaveData.LeahFriendship--;

                SaveData.MyInventory.TryGetValue(Enums.Items.Bread, out var breadCount);
                breadCount--;
                SaveData.MyInventory[Enums.Items.Bread] = breadCount;
            }
            else //neutral
            {
                Console.WriteLine("Leah > Thank you.");
                Console.WriteLine(gift + " removed from Inventory.");
            }
        }

        void Investigate()
        {

        }
    }
}
