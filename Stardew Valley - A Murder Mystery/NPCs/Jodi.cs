using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Jodi : NPC
    {
        private SaveData SaveData { get; set; }

        public Jodi(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Jodi";

                if (SaveData.JodiCount == 0) //first meeting
                {
                    Console.WriteLine("Jodi > Oh! You aren't exactly how I imagined... but that's okay! I'm Jodi.");
                    Console.WriteLine("Jodi > It's a quiet little town, so it's very exciting when someone new moves in! Having a Detective around could really change things.");
                    SaveData.JodiCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Jodi > Maintaining a household is difficult work... but somebody has to do it. Yes?"); break;
                        case 1: Console.WriteLine("Jodi > Exercise is important for staying healthy. I always make sure to set aside some time for it.");
                            Console.WriteLine("Jodi > As a parent, I don't have much time to devote to myself. So I try and make every minute count."); break;
                        case 2: Console.WriteLine("Jodi > I wish I could spend more time outside, but there's so much work to do."); break;
                        case 3: Console.WriteLine("Jodi > I started wearing rubber gloves to keep my hands soft. The older you get, the more work you have to do to stay healthy. Ok, bye!"); break;
                        case 4: Console.WriteLine("Jodi > The food at JojaMart might not be the healthiest for my family, but with such low prices you'd be crazy to shop anywhere else!"); break;
                        case 5: Console.WriteLine("Jodi > Hi. Need something?"); break;
                        case 6: Console.WriteLine("Jodi > I'm taking a break from house chores today. I'm taking the day off. If I don't spend any time outside, I'll go crazy! Plus I don't want my legs to turn soft."); break;
                        case 7: Console.WriteLine("Jodi > Kent is running for mayor. I really hope he wins!"); break;
                        case 8: Console.WriteLine("Jodi > Vote for Kent!"); break;
                        case 9: Console.WriteLine("Jodi > Kent will be a great mayor. It will be so good for him to serve the community again."); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

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
                    case "L": SaveData.JodiCount++;
                        return;
                    default: break;
                }                
            }
        }

        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give Jodi?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            if (gift.Length == 0)
            {
                return;
            }

            else if (gift == "ChocolateCake" && Enums.Items.ChocolateCake > 0)
            {
                Console.WriteLine("Jodi > Oh, you're such a sweetheart! I really love this!"); // NPC loves
                Console.WriteLine(gift + " removed from Inventory.");
                
                SaveData.MyInventory.TryGetValue(Enums.Items.ChocolateCake, out var chocolateCakeCount);
                chocolateCakeCount--;
                SaveData.MyInventory[Enums.Items.ChocolateCake] = chocolateCakeCount;
            }

            else if (gift == "Daffodil" && Enums.Items.Daffodil > 0)
            {
                Console.WriteLine("Jodi > *Blech*... I hate this..."); //NPC hates
                Console.WriteLine(gift + " removed from Inventory.");
                
                SaveData.MyInventory.TryGetValue(Enums.Items.Daffodil, out var daffodilCount);
                daffodilCount--;
                SaveData.MyInventory[Enums.Items.Daffodil] = daffodilCount;
            }
            else //neutral
            {
                Console.WriteLine("Jodi > That's so nice of you! Thanks.");
                Console.WriteLine(gift + " removed from Inventory.");
            }
        }

        void Investigate()
        {

        }
    }
}
