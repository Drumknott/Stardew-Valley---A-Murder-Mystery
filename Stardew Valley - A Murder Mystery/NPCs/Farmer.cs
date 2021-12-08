using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Farmer : NPC
    {
        private SaveData SaveData { get; set; }

        public Farmer(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Chat()
        {
            if (SaveData.FarmerCount == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Farmer "+SaveData.FarmerName+" > Hi! Are you the Detective from the City? I'm "+SaveData.FarmerName+".");
                Console.WriteLine("Farmer "+SaveData.FarmerName+" > I've got a cabin ready for you to stay in while you're here. Normally visitors stay at the Stardrop Saloon,");
                Console.WriteLine("\tbut Gus is having the place done up so there isn't any space. I hope that's ok?");
                Console.WriteLine("");
                Console.WriteLine("Y > Yeah that sounds great");
                Console.WriteLine("N > I'm staying on a farm!?");
                Console.WriteLine("I > ...is there another option?");
                SaveData.FarmerCount++;
                var Dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();
                switch (Dialogue1)
                {
                    case "Y":
                        Console.WriteLine("You > That sounds great, I love the countryside!");
                        Console.WriteLine("Farmer "+SaveData.FarmerName+" > Great! It's just over here");
                        Console.WriteLine(SaveData.FarmerName+" leads you across the farm to a small cabin by a pond. It's nicely furnished with a comfy bed, desk, dresser and a TV.");
                        Console.WriteLine("A perfect place from which to conduct your investigation.");
                        SaveData.Cabin = true;
                        Console.WriteLine("Finally, Farmer "+SaveData.FarmerName+" hands you a package wrapped in foil.");
                        Console.WriteLine("Farmer "+SaveData.FarmerName+" > I thought you might be hungry, so I made you this. Enjoy!");
                        Console.WriteLine("It's a Farmer's Lunch. Smells great!");
                        SaveData.MyInventory.TryGetValue(Enums.Items.FarmersLunch, out var farmerslunchCount);
                        farmerslunchCount++;
                        SaveData.MyInventory[Enums.Items.FarmersLunch] = farmerslunchCount;
                        break;                       
                    case "N": 
                        Console.WriteLine("You > Um, I thought I'd be staying in town. I'm not really a country person...");
                        Console.WriteLine("Farmer "+SaveData.FarmerName+" > Oh, well I guess you could ask around the town? I don't know if anyone has a spare room though...");
                        Console.WriteLine("\tHere are the keys though, just in case. You know, if you change your mind.");
                        SaveData.Cabin = true;
                        break;
                    case "I": 
                        Console.WriteLine("You > I don't mean to be rude, but is there another option? I'm not a very... farmy... person");
                        Console.WriteLine("Farmer "+SaveData.FarmerName+" > Um, maybe check with Gus at the Saloon? He might have a room cleared by now, I don't know.");
                        SaveData.Homeless = true;
                        break;
                }                
            }

            else
            {
                Random dialogue = new();
                int random = dialogue.Next(0, 9);

                switch (random) //random dialogue
                {                    
                    case 0: Console.WriteLine($"Farmer {SaveData.FarmerName} > I love Spring time - the new blossoms on the trees give me life!"); break;
                    case 1: Console.WriteLine($"Farmer {SaveData.FarmerName} > My cows hate the rain - the chickens love it though!"); break;
                    case 2: Console.WriteLine($"Farmer {SaveData.FarmerName} > I'm growing potatoes down on the bottom field at the moment. You can have some when they're ready!"); break;
                    case 3: Console.WriteLine($"Farmer {SaveData.FarmerName} > Have you met my horse? I call her Reneigh"); break;
                    case 4: Console.WriteLine($"Farmer {SaveData.FarmerName} > I've got white chickens, brown chickens, a black chicken and... blue. Please don't ask."); break;
                    case 5: Console.WriteLine($"Farmer {SaveData.FarmerName} > My grandfather left me this farm. I'm doing my best to bring it back to it's former glory in his memory."); break;
                    case 6: Console.WriteLine($"Farmer {SaveData.FarmerName} > Look out for fruit bushes - it's nearly salmonberry season!"); break;
                    case 7: Console.WriteLine($"Farmer {SaveData.FarmerName} > Have you heard Sebastian and Abigail's podcast? It's pretty morbid..."); break;
                    case 8: Console.WriteLine($"Farmer {SaveData.FarmerName} > The egg festival is next week. My chickens are working overtime on those eggs! "); break;
                    case 9: Console.WriteLine($"Farmer {SaveData.FarmerName} > Poor Lewis. I don't know what we'll do without him."); break;
                    default: break;
                }
                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("Me > Hi, can we chat?");
                        break;
                    case "G":
                        Console.WriteLine("Me > Would you like this?");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Me > Do you mind answering a few questions for me...?");
                        Investigate();
                        Console.WriteLine($"Me > Ok, thanks {SaveData.FarmerName}.");
                        break;
                    default: break;
                }

                SaveData.FarmerCount++;
            }
        }

        public override void Gift()
        {
            string NPCName = SaveData.FarmerName;
            var FavGift = Enums.Items.Beer;
            var DislikedGift = Enums.Items.Coal;
            string LoveGift = "";
            string HateGift = "";
            string NeutralGift = "";

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

            Console.WriteLine($"Farmer {SaveData.FarmerName} > No problem - ask away.\n");

            while (true)
            {
                if (Case1 && Case2 && Case3) return;

                Console.WriteLine("W > Where were you last Friday night?");
                Console.WriteLine("T > Tell me about Mayor Lewis?");
                Console.WriteLine("E > Is there anyone else in particular you think I should be talking to?");
                Console.WriteLine("L > Leave");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "W":
                        Console.WriteLine($"Farmer { SaveData.FarmerName} > I was at the Saloon. I'm sure you've already heard about the commotion, or you will.");
                        Console.WriteLine($"Farmer { SaveData.FarmerName} > I left soon after that though. I always have to be up early to feed the animals, so I like to get an early night. ");
                        Case1 = true;
                        break;
                    case "T":
                        Console.WriteLine($"Farmer { SaveData.FarmerName} > Well, I've only lived in town just over a year, so I don't know him as well as a lot of the other townsfolk would.");
                        Console.WriteLine($"Farmer { SaveData.FarmerName} > But he always seemed ok to me. Never forgot to check my shipping bin, always punctual with payments. Decent man.");
                        Case2 = true;
                        break;
                    case "E":
                        Console.WriteLine($"Farmer { SaveData.FarmerName} > I'd chat to Gus at the saloon. He always seems to know what's going on around town.");
                        Case3 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }
    }
}
