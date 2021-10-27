using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Linus : NPC
    {
        private SaveData SaveData { get; set; }

        public Linus(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Linus";

                if (SaveData.LinusCount == 0) //first meeting
                {
                    Console.WriteLine("Linus > A stranger?... Hello. Don't mind me. I just live out here alone.");
                    SaveData.LinusCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Linus > The crisp air of the wilderness is all I care to know. I live out here by choice."); break;
                        case 1: Console.WriteLine("Linus > ...Have you come to ridicule me? I'm just minding my own business."); break;
                        case 2: Console.WriteLine("Linus > I don't know you well enough to trust you. Sorry."); break;
                        case 3: Console.WriteLine("Linus > ...Hmm? Do you want something from me?"); break;
                        case 4: Console.WriteLine("Linus > Please don't destroy my tent. It's happened before."); break;
                        case 5: Console.WriteLine("Linus > I'm happy by myself, you know. I don't need new friends."); break;
                        case 6: Console.WriteLine("Linus > I have to be wary of strangers. Most people don't like a 'wild man'."); break;
                        case 7: Console.WriteLine("Linus > Someone was throwing rocks at my tent last night... I just had to wait it out."); break;
                        case 8: Console.WriteLine("Linus > I don't like to stay in one place for too long. There's just too much to experience in the world."); break;
                        case 9: Console.WriteLine("Linus > It would be nice if the townspeople could accept me for who I am. I like living out here in the open air. That's what they don't understand."); break;
                        case 10: Console.WriteLine("Linus > You can learn to survive in the wild. I have. I think we all have a hidden urge to return to nature. It's just a little scary to make the leap."); break;
                        case 11: Console.WriteLine("Linus > The people here seem nice, but they avoid me. People are afraid of the unknown."); break;
                        case 12: Console.WriteLine("Linus > You can learn a lot from trees. Spend time with them and they might tell you their secrets. Go in peace, young one."); break;
                        case 13: Console.WriteLine("Linus > I have everything I need to survive, and more. Nature plays a wonderful tune if you can only learn to listen."); 
                                Console.WriteLine(" also spend a lot of time reading. One of the reasons I stopped in the valley was for the great library."); break;
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
                        break;
                    case "gift":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "investigate":
                        Console.WriteLine("");
                        Investigate();
                        break;
                    case "L": SaveData.LinusCount++;
                        return;
                    default: break;
                }                
            }
        }

        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give Linus?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            if (gift.Length == 0)
            {
                return;
            }

            else if (gift == "Fav" && Enums.Items.Coconut > 0)
            {
                Console.WriteLine("Linus > This is wonderful! You've really made my day special."); // NPC loves
                Console.WriteLine(gift + " removed from Inventory.");
                
                SaveData.MyInventory.TryGetValue(Enums.Items.Coconut, out var coconutCount);
                coconutCount--;
                SaveData.MyInventory[Enums.Items.Coconut] = coconutCount;
            }

            else if (gift == "hate" && Enums.Items.Horseradish > 0)
            {
                Console.WriteLine("Linus > Why would you give this to me? Do you think I like junk just because I live in a tent? That's terrible."); //NPC hates
                Console.WriteLine(gift + " removed from Inventory.");
                
                SaveData.MyInventory.TryGetValue(Enums.Items.Seaweed, out var seaweedCount);
                seaweedCount--;
                SaveData.MyInventory[Enums.Items.Seaweed] = seaweedCount;
            }
            else //neutral
            {
                Console.WriteLine("Linus > A gift? How nice.");
                Console.WriteLine(gift + " removed from Inventory.");
            }
        }

        void Investigate()
        {

        }
    }
}
