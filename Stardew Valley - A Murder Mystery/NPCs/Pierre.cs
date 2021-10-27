using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Pierre : NPC
    {
        private SaveData SaveData { get; set; }

        public Pierre(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Pierre";

                if (SaveData.PierreCount == 0) //first meeting
                {
                    Console.WriteLine($"Pierre > Hey, it's Detective {SaveData.PlayerName}! I'm Pierre, owner of the local general store.");
                    Console.WriteLine("Pierre > A little mystery like this could really inject life into the local economy!");
                    SaveData.PierreCount++;
                }

                else
                {

                    if (SaveData.DayCount == 1) //aerobics day
                    {
                        //chat about aerobics day
                    }

                    else
                    {
                        Random dialogue = new();
                        int random = dialogue.Next(0, 9);

                        switch (random) //random dialogue
                        {
                            case 0: Console.WriteLine("Pierre > Welcome! If you're looking for seeds, you've come to the right place!"); break;
                            case 1: Console.WriteLine($"Pierre > Hi, {SaveData.PlayerName}. Need any seeds or fruit tree saplings?"); break;
                            case 2: Console.WriteLine("Pierre > Sometimes I get new items in stock, so make sure to stop by every so often. It's a lot of work to run a shop."); break;
                            case 3: Console.WriteLine("Pierre > I'm happy to buy any produce off you. I'll give you a fair price, of course!"); break;
                            case 4: Console.WriteLine($"Pierre > I really do appreciate your business, Detective {SaveData.PlayerName}. I've been having a harder and harder time turning a decent profit."); break;
                            case 5: Console.WriteLine("Pierre > Business has been slow since Joja moved into town. It's hard to compete with their selection."); break;
                            case 6: Console.WriteLine("Pierre > *sigh*... I've got those behind-the-counter blues... I wish I could go for a walk, but I can't leave the store unattended. I've heard the flowers are in bloom and the air smells great..."); break;
                            case 7: Console.WriteLine($"Pierre > Hey, {SaveData.PlayerName}. You're my number one customer!"); break;
                            case 8: Console.WriteLine("Pierre > Vote for Pierre!"); break;
                            case 9: Console.WriteLine("Pierre > Remember, a vote for Pierre is a vote against Joja Mart! Let's save our community!"); break;
                            default: break;
                        }
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
                    case "buy":
                        Console.WriteLine("");
                        Buy();
                        break;
                    case "L":
                        SaveData.PierreCount++;
                        return;
                    default: break;
                }                                  
            }            
        }

        public override void Gift()
        {
            //add gift option for joja cola and the candy you can steal from the store

            Console.WriteLine("What gift would you like to give Pierre?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            if (gift.Length == 0)
            {
                return;
            }

            else if (gift == "JojaCola" && Enums.Items.JojaCola > 0)
            {
                Console.WriteLine("Pierre > Is this some kind of sick joke? Why would you bring me my competitor's product?");
                Console.WriteLine(gift + " removed from Inventory.");

                SaveData.MyInventory.TryGetValue(Enums.Items.JojaCola, out var jojaColaCount);
                jojaColaCount--;
                SaveData.MyInventory[Enums.Items.JojaCola] = jojaColaCount;
            }

            else if (gift == "MapleBar" && Enums.Items.MapleBar > 0)
            {
                Console.WriteLine("Pierre > Ooh, a maple bar. Thanks, I love these!");
                Console.WriteLine(gift + " removed from Inventory.");

                SaveData.MyInventory.TryGetValue(Enums.Items.MapleBar, out var mapleBarCount);
                mapleBarCount--;
                SaveData.MyInventory[Enums.Items.MapleBar] = mapleBarCount;

                if (SaveData.StealFromPierre == true)
                {
                    SaveData.FuckYouPierre = true;
                }
            }

            else if (gift == "FriedCalamari" && Enums.Items.FriedCalamari > 0)
            {
                Console.WriteLine("Pierre > This is my all-time favorite! Thank you!"); // NPC loves
                Console.WriteLine(gift + " removed from Inventory.");
                
                SaveData.MyInventory.TryGetValue(Enums.Items.FriedCalamari, out var friedCalamariCount);
                friedCalamariCount--;
                SaveData.MyInventory[Enums.Items.FriedCalamari] = friedCalamariCount;
            }

            else if (gift == "Corn" && Enums.Items.Corn > 0)
            {
                Console.WriteLine("Pierre > Please, never bring this to me again."); //NPC hates
                Console.WriteLine(gift + " removed from Inventory.");
               
                SaveData.MyInventory.TryGetValue(Enums.Items.Corn, out var cornCount);
                cornCount--;
                SaveData.MyInventory[Enums.Items.Corn] = cornCount;
            }

            else //neutral
            {
                Console.WriteLine("Pierre > A present? Thanks!");
                Console.WriteLine(gift + " removed from Inventory.");
            }
        }

        void Investigate()
        {

        }

        void Buy()
        {

        }
    }
}
