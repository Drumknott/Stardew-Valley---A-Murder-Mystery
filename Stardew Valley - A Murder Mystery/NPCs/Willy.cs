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

                var dialogue1 = Console.ReadLine();

                switch (dialogue1)
                {
                    case "chat":
                        Console.WriteLine("");
                        break;
                    case "gift":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "investigate":
                        Console.WriteLine("");
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
            Console.WriteLine("What gift would you like to give Willy?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            if (gift.Length == 0)
            {
                return;
            }

            else if (gift == "Octopus" && Enums.Items.Octopus > 0)
            {
                Console.WriteLine("Willy > This is great! If only me ol' Pappy was around. He'd go nuts for this."); // NPC loves
                Console.WriteLine(gift + " removed from Inventory.");
              
                SaveData.MyInventory.TryGetValue(Enums.Items.Octopus, out var octopusCount);
                octopusCount--;
                SaveData.MyInventory[Enums.Items.Octopus] = octopusCount;
            }

            else if (gift == "Leek" && Enums.Items.Leek > 0)
            {
                Console.WriteLine("Willy > ... *sniff*... Well I guess I can toss it into the chum bucket."); //NPC hates
                Console.WriteLine(gift + " removed from Inventory.");
                
                SaveData.MyInventory.TryGetValue(Enums.Items.Leek, out var leekCount);
                leekCount--;
                SaveData.MyInventory[Enums.Items.Leek] = leekCount;
            }
            else //neutral
            {
                Console.WriteLine("Willy > A gift! Thanks.");
                Console.WriteLine(gift + " removed from Inventory.");
            }
        }

        void Investigate()
        {

        }
    }
}
