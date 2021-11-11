using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Gus : NPC
    {
        private SaveData SaveData { get; set; }

        public Gus(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {     
            while (true)
            { 
                SaveData.LastChat = "Gus";

                if (SaveData.GusCount == 0) //first meeting
                {
                    Console.WriteLine("Gus > Well hello there! I'm Gus, chef and owner of the Stardrop Saloon. Stop in if you need any refreshments. I've always got hot coffee and cold beer at the ready.");
                    SaveData.GusCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 6);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Gus > Yeah, I know a lot about the people living here. That's one of the benefits of being a bartender. Sometimes I hear too much..."); break;
                        case 1: Console.WriteLine("Gus > I sell different dishes each week, so make sure and check in every now and then! You might taste something spectacular. Just let me know if you have any allergies. Okay, see you around."); break;
                        case 2: Console.WriteLine("Gus > Emily's been working here for a while now. I don't know what I'd do without her! I would hate to have to clean all those pots by myself."); break;
                        case 3: Console.WriteLine("Gus > Pam and Clint come into the saloon almost every night. I'd probably go out of business if they stopped coming. So make sure you don't drive them away!"); break;
                        case 4: Console.WriteLine("Gus > Hi there, " + SaveData.PlayerName + ". If you're ever thirsty, the Saloon is the place the be."); break;
                        case 5: Console.WriteLine("Gus > Business has been pretty steady thanks to my regular customers."); break;
                        case 6: Console.WriteLine("Gus > I don't actually drink very much myself. I'm mainly doing this to make a living. Although I do enjoy a taste of the Stardew Valley vintage from time to time."); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();
                Console.WriteLine("S > Shop"); //buy stuff
                
                var dialogue1 = Console.ReadLine();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("");                        
                        break;
                    case "G":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("");
                        Investigate();
                        break;
                    case "S":
                        Console.WriteLine("Me > I was hoping to buy something from you Gus");
                        Buy();
                        break;
                    case "L": SaveData.GusCount++;
                        return;
                    default: break;
                }                
            }
        }

        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give Gus?");
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

        void Buy()
        {
            if (SaveData.ShopGus > 10)
            {
                Console.WriteLine("Gus > Err, I don't mean to be rude Detective but I can't just keep giving you all this free food and drink...");
                return;
            }

            Console.WriteLine("Gus > Oh don't be silly, Detective. You're our guest! Whatever you need is on the house.");
            Console.WriteLine("");
            Console.WriteLine("B > Beer");
            Console.WriteLine("C > Coffee");
            Console.WriteLine("F > Fish Taco");
            Console.WriteLine("R > Risotto");

            var order = Console.ReadLine();

            switch(order)
            {
                case "B":
                    Console.WriteLine("Gus > Beer it is. Here you go.");
                    Console.WriteLine("Beer added to Inventory");
                    SaveData.MyInventory.TryGetValue(Enums.Items.Beer, out var beerCount);
                    beerCount++;
                    SaveData.MyInventory[Enums.Items.Beer] = beerCount;
                    break;
                case "C":

                    SaveData.MyInventory.TryGetValue(Enums.Items.Coffee, out var coffeeCount);
                    coffeeCount++;
                    SaveData.MyInventory[Enums.Items.Coffee] = coffeeCount;
                    break;
                case "F":

                    SaveData.MyInventory.TryGetValue(Enums.Items.FishTaco, out var fishTacoCount);
                    fishTacoCount--;
                    SaveData.MyInventory[Enums.Items.FishTaco] = fishTacoCount;
                    break;
                case "R":

                    SaveData.MyInventory.TryGetValue(Enums.Items.Risotto, out var risottoCount);
                    risottoCount--;
                    SaveData.MyInventory[Enums.Items.Risotto] = risottoCount;
                    break;
            }

            SaveData.ShopGus++;
        }
    }
}
