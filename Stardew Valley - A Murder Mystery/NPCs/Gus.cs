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
                if (SaveData.FindSewerKey == true) Console.WriteLine("K > Do you know where I'd find a key for the Sewers?");
                if (SaveData.Homeless == true) Console.WriteLine("R > Do you have any rooms available?");

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("Me > Hey Gus. Nice to see you.");                        
                        break;
                    case "G":
                        Console.WriteLine("Me > Gus would you like this?");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Me > Do you mind if I ask you a few questions about last Friday night?");
                        Investigate();
                        break;
                    case "S":
                        Console.WriteLine("Me > I was hoping to buy something from you Gus");
                        Buy();
                        break;
                    case "K" when SaveData.FindSewerKey:
                        Console.WriteLine("Gus > For the sewers? Goodness, why would you want to go down there? \nGus > Mayor Lewis had a key, but I don't know where it would be now.");
                        break;
                    case "R" when (SaveData.Homeless == true):
                        FindAHome();
                        break;
                    case "L": SaveData.GusCount++;
                        return;
                    default: break;
                }                
            }
        }

        private void FindAHome()
        {
            Console.WriteLine("Gus > I usually do, but they're being done up at the moment. I thought you were staying in one of the cabins on the Farm?");
            Console.WriteLine("Me > Oh, uh, the farm life isn't really for me... ");
            Console.WriteLine("Gus > Well, if it's not too weirtd I suppose you could stay in Mayor Lewis' house. He's not using it anymore...\n ");
            Console.WriteLine("C > Stay in the Cabin\nL > Stay at Lewis'");
            switch (Console.ReadLine().Substring(0, 1).ToUpper())
            {
                case "C":
                    Console.WriteLine("Me > I think I might stay in the cabin after all. Thanks Gus.");
                    break;
                case "L":
                    Console.WriteLine("Me > I don't mind that. Thanks Gus.");
                    SaveData.StayAtLewis = true;
                    break;
                default: break;
            }
        }

        public override void Gift()
        {
            string NPCName = "Gus";
            var FavGift = Enums.Items.Diamond;
            var DislikedGift = Enums.Items.Horseradish;
            string LoveGift = "You're giving this... to me? I'm speechless.";
            string HateGift = "No, no, no...";
            string NeutralGift = "Oh, that's sweet. Thank you.";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            Gift giftMethod = new(SaveData);
            giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);           
        }

        void Investigate()
        {
            bool Case1 = false;
            bool Case2 = false;
            bool Case3 = false;

            Console.WriteLine("Gus > Of course, Detective. Not a problem.");

            while (true)
            {
                if (Case1 && Case2 && Case3) return;

                Console.WriteLine("C > Can you tell me what happened?");
                Console.WriteLine("D > Did you get on with Mayor Lewis?");
                Console.WriteLine("Y > You must know all the townsfolk quite well. Is there anyone who didn't like Lewis?");
                Console.WriteLine("L > Leave");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "C":
                        Console.WriteLine("Gus > Well, Marnie came rushing into the saloon screaming for help, something about Lewis.");
                        Console.WriteLine("Gus > Myself, Willy and Shane went to see what was going on. Harvey was already there doing CPR. ");
                        Console.WriteLine("Gus > Willy and I helped Harvey, and Shane, that's Marnie's nephew, he looked after her.");
                        Console.WriteLine("Gus > We did CPR for half an hour? Forty minutes? And Harvey said it was no use, so we stopped.");
                        Console.WriteLine("Gus > Horrible thing. Never seen anything like it.");
                        Case1 = true;
                        break;
                    case "D":
                        Console.WriteLine("Gus > Oh sure, Lewis was a regular. Always nice and polite, never had a bad word to say about anyone.");
                        Case2 = true;
                        break;
                    case "Y":
                        Console.WriteLine("Gus > I don't think so. He was the town Mayor, so he had to make some unpopular decisions sometimes, but nothing to warrant what happened to him.");
                        Case3 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }

        void Buy()
        {
            if (SaveData.ShopGus > 10)
            {
                Console.WriteLine("Gus > Err, I don't mean to be rude Detective but I can't just keep giving you all this free food and drink...");
                return;
            }

            Console.WriteLine("Gus > Oh don't be silly, Detective. You're our guest! Whatever you need is on the house.\n");
            Console.WriteLine("B > Beer");
            Console.WriteLine("C > Coffee");
            Console.WriteLine("F > Fish Taco");
            Console.WriteLine("R > Risotto");

            var order = Console.ReadLine().Substring(0, 1).ToUpper();

            switch (order)
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
