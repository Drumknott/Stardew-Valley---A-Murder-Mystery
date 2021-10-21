using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Robin : NPC
    {
        private SaveData SaveData { get; set; }

        public Robin(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            SaveData.LastChat = "Robin";

            if (SaveData.RobinCount == 0) //first meeting
            {
                Console.WriteLine("Robin > Have you met everyone in town yet? That sounds exhausting.");
                SaveData.RobinCount++;
            }

            else
            {
                while (true)
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Robin > Have I told you that I built our house from the ground up? It's definitely been the highlight of my career so far."); break;
                        case 1: Console.WriteLine("Robin > Hey, if you need any materials or blueprints, my shop is the place you're looking for! Plus, your business supports the local economy."); break;
                        case 2: Console.WriteLine($"Robin > Hey there, {SaveData.PlayerName}. I was just daydreaming about some new carpentry projects."); break;
                        case 3: Console.WriteLine("Robin > You're always welcome to visit us, even if you aren't shopping, you know. It can get pretty lonely up here in the mountains."); break;
                        case 4: Console.WriteLine("Robin > You've met my son Sebastian, right? He lives downstairs. He's a little shy, but I'm sure he'll warm up to you if you're nice to him."); break;
                        case 5: Console.WriteLine("Robin > I found an ashtray in Sebastian's room, and it smelled really weird. Should I be worried about this?"); break;
                        case 6:
                            Console.WriteLine("Robin > Sometimes I worry about Sebastian... he doesn't have many friends and doesn't really seem to care about his future very much...");
                            Console.WriteLine("I would talk to him about it but he never opens up to me."); break;
                        case 7: Console.WriteLine("Robin > Our house is in such a beautiful area, don't you think? I love the fresh air of the mountains."); break;
                        case 8:
                            Console.WriteLine("Robin > I hope Demetrius doesn't blow the house up with those science experiments of his.");
                            Console.WriteLine("I'm not even sure what he's working on. I think it has something to do with plants."); break;
                        case 9:
                            Console.WriteLine("Robin > My husband almost set the house on fire last night with his science experiment.");
                            Console.WriteLine("One of his beakers exploded and sent a fireball into the rafters! Thank Yoba I used fire-resistant lacquer when I built the place."); break;
                        case 10: Console.WriteLine($"Robin > Sorry if it smells weird in here, {SaveData.PlayerName}. It's my husband's bizarre science project..."); break;
                        default: break;
                    }
                    //player dialogue options
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
                        case "L":
                            SaveData.RobinCount++;
                            return;
                        default: break;
                    }                    
                }
            }
        }

        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give Robin?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            if (gift.Length == 0)
            {
                return;
            }

            else if (gift == "GoatCheese" && Enums.Items.GoatCheese> 0)
            {
                Console.WriteLine("Robin > This is for me? Wow, I absolutely love it!!"); // NPC loves
                Console.WriteLine(gift + " removed from Inventory.");
                
                SaveData.MyInventory.TryGetValue(Enums.Items.GoatCheese, out var goatCheeseCount);
                goatCheeseCount--;
                SaveData.MyInventory[Enums.Items.GoatCheese] = goatCheeseCount;
            }

            else if (gift == "hate" && Enums.Items.Holly > 0)
            {
                Console.WriteLine("Robin > What the...? This is terrible!"); //NPC hates
                Console.WriteLine(gift + " removed from Inventory.");
                
                SaveData.MyInventory.TryGetValue(Enums.Items.Holly, out var hollyCount);
                hollyCount--;
                SaveData.MyInventory[Enums.Items.Holly] = hollyCount;
            }
            else //neutral
            {
                Console.WriteLine("Robin > Thank you. This might come in handy.");
                Console.WriteLine(gift + " removed from Inventory.");
            }
        }

        void Investigate()
        {

        }
    }
}
