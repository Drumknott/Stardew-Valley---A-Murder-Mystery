using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Willy : NPC
    {
        private SaveData SaveData { get; set; }

        public Willy(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            {
                SaveData.LastChat = "Willy";

                if (SaveData.WillyCount == 0) //first meeting
                {
                    Console.WriteLine("Willy > Ahoy there! It's nice to see young folk movin' in to the valley. It's not very common these days.");
                    SaveData.WillyCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 7);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine($"Willy > Ahoy there, {SaveData.PlayerName}. Looks like decent weather for fishing, eh?"); break;
                        case 1: Console.WriteLine($"Willy > Have you had much luck in the local waters? You look like you could be a strong angler if you set your mind to it."); break;
                        case 2: Console.WriteLine($"Willy > A true angler has respect for the water... don't you forget that."); break;
                        case 3: Console.WriteLine($"Willy > Some fish come and go with the seasons. Others only come out at night or in the rain."); break;
                        case 4: Console.WriteLine($"Willy > *mumble* *mumble* ...Eh? I would tell you about my thoughts, but it's a fisherman's secret."); break;
                        case 5:
                            Console.WriteLine($"Willy > There are rumors of some very rare fish in these parts... but only an experienced angler could stand a chance against them.");
                            Console.WriteLine("\tYou'll need the finest bait you can get if you want a rare fish to bite."); break;
                        case 6: Console.WriteLine($"Willy > If you really want to get the fish biting, make sure you put some bait on your hook."); break;
                        case 7: Console.WriteLine($"Willy > If the local fishing scene got a bit more lively, I might expand the shop's stock."); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("Me > Hi Willy, how are the fish biting today?");
                        break;
                    case "G":
                        Console.WriteLine("Me > Say, do you think you'd have any use for this?");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Me > Mind if I ask a couple of questions, Willy?");
                        Investigate();
                        break;
                    case "L":
                        SaveData.WillyCount++;
                        return;
                    default: break;
                }                
            }
        }

        public override void Gift()
        {
            string NPCName = "Willy";
            var FavGift = Enums.Items.Octopus;
            var DislikedGift = Enums.Items.Leek;
            string LoveGift = "This is great! If only me ol' Pappy was around. He'd go nuts for this.";
            string HateGift = " ... *sniff*... Well I guess I can toss it into the chum bucket.";
            string NeutralGift = "A gift! Thanks.";

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

            Console.WriteLine("Willy > Not a problem. What's on your mind?");

            while (true)
            {
                if (Case1 && Case2 && Case3) return;

                Console.WriteLine("\nW > Where were you last Friday night?");
                Console.WriteLine("D > Did you like Mayor Lewis?");
                if (SaveData.Ritual) Console.WriteLine("R > Where did you learn to do that... thing... you were doing in the forest?");
                Console.WriteLine("L > Leave\n");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "W":
                        Console.WriteLine("Willy > I was anchored up in the saloon 'til poor Marnie came rushing in like that.");
                        Console.WriteLine("Willy > Terrible business. Never seen the likes of it before.");
                        Case1 = true;
                        break;
                    case "D":
                        Console.WriteLine("Willy > He was a good man making his way, same as us all. He weren't much for fishing, though.");
                        Case2 = true;
                        break;
                    case "R":
                        Console.WriteLine("Willy > Oh, Ol' Rasmodius helps me with the fishing from time to time.");
                        Console.WriteLine("Willy > Summoning shoals, making the sacrifice to the sea god, that sort of thing...");
                        Console.WriteLine("Willy > I've picked up a few things from him over time.");
                        Case3 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }
    }
}
