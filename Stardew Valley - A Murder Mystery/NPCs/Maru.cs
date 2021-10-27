using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Maru : NPC
    {
        private SaveData SaveData { get; set; }

        public Maru(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Maru";

                if (SaveData.MaruCount == 0) //first meeting
                {
                    Console.WriteLine("Maru > Oh! Aren't you the Detective? I'm Maru. I've been looking forward to meeting you!"); 
                    Console.WriteLine("You know, with a small town like this, a new face can really alter the community dynamic.It's exciting!");
                    SaveData.MaruCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Maru > Whenever I'm struggling with a technical problem, I always take a walk.It's surprising how much a change of scenery can help."); break;
                        case 1: Console.WriteLine("Maru > Have you met my mother? She's the town's carpenter."); break;
                        case 2: Console.WriteLine("Maru > On Tuesdays and Thursdays I work at Harvey's clinic.He says he likes having me around in case his medical equipment goes haywire!"); break;
                        case 3: Console.WriteLine("Maru > I plan on spending a lot of time with my telescope this summer."); break;
                        case 4: Console.WriteLine("Maru > Do you know my Dad, Demetrius? He's a scientist. I have a lot of fun helping him out in the laboratory."); break;
                        case 5: Console.WriteLine("Maru > Hey, sorry if I seem cranky... I'm a little sore from work yesterday. I had to sort patient records for four hours straight!"); break;
                        case 6: Console.WriteLine("Maru > Sometimes my head gets so cluttered with nonsense I can hardly think. Does that ever happen to you? Getting some fresh air usually helps."); break;
                        case 7: Console.WriteLine("Maru > My mother is a carpenter and my dad is a scientist. I guess it makes sense that I'm into building gadgets."); break;
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
                        SaveData.MaruFriendship++;
                        break;
                    case "gift":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "investigate":
                        Console.WriteLine("");
                        Investigate();
                        break;
                    case "L": SaveData.MaruCount++;
                        return;
                    default: break;
                }                
            }
        }

        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give Maru?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            if (gift.Length == 0)
            {
                return;
            }

            else if (gift == "Fav" && Enums.Items.BatteryPack > 0)
            {
                Console.WriteLine("Maru > Is that...? Oh wow, (Name)! This is spectacular!"); // NPC loves
                Console.WriteLine(gift + " removed from Inventory.");
                SaveData.MaruFriendship += 2;

                SaveData.MyInventory.TryGetValue(Enums.Items.BatteryPack, out var batteryPackCount);
                batteryPackCount--;
                SaveData.MyInventory[Enums.Items.BatteryPack] = batteryPackCount;
            }

            else if (gift == "hate" && Enums.Items.Horseradish > 0)
            {
                Console.WriteLine("Maru > Yuck! You thought I would like this?"); //NPC hates
                Console.WriteLine(gift + " removed from Inventory.");
                SaveData.MaruFriendship--;

                SaveData.MyInventory.TryGetValue(Enums.Items.Holly, out var hollyCount);
                hollyCount--;
                SaveData.MyInventory[Enums.Items.Holly] = hollyCount;
            }
            else //neutral
            {
                Console.WriteLine("Maru > Thanks.");
                Console.WriteLine(gift + " removed from Inventory.");
            }
        }

        void Investigate()
        {

        }
    }
}
