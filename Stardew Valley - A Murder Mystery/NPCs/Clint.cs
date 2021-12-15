using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Clint : NPC
    {
        private SaveData SaveData { get; set; }

        public Clint(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Chat()
        {
            while (true)
            {
                if (SaveData.ClintCount == 0) //first meeting
                {
                    Console.WriteLine("Clint > Er... hi. I'm Clint. I'm the town blacksmith. If you ever need to upgrade your tools, I'm your guy.");
                    SaveData.ClintCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 6);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Clint > Hey. What do you need?"); break;
                        case 1: Console.WriteLine("Clint > Business has been slow lately. You should upgrade your tools. I could use the cash."); break;
                        case 2: Console.WriteLine("Clint > The weather doesn't really matter to me. I typically stay near my shop year-round. Depressing, huh?"); break;
                        case 3: Console.WriteLine("Clint > Sometimes I wonder how I ended up in this town."); break;
                        case 4: Console.WriteLine("Clint > Don't you have work to do?"); break;
                        case 5: Console.WriteLine("Clint > Yep. I'm a blacksmith. My father was also a blacksmith. My grandfather was a blacksmith as well.\nClint > I bet you can't guess what my great-grandfather was..."); break;
                        case 6: Console.WriteLine("Clint > It's a shame about Mayor Lewis. He was a good man."); break;                        
                        default: break;
                    }
                }


                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("Me > Hi Clint. How are you today?");
                        break;
                    case "G":
                        Console.WriteLine("Me > Do you have any use for this?");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Me > Can I ask you a few questions?");
                        Investigate();
                        break;
                    case "L":
                        Console.WriteLine("Me > Thanks Clint. Talk soon.");
                        SaveData.ClintCount++;
                        return;
                    default: break;
                }               
            }
        }

        public override void Gift()
        {
            string NPCName = "Clint";
            var FavGift = Enums.Items.Emerald;
            var DislikedGift = Enums.Items.Holly;
            string LoveGift = "Yes! This is exactly what I've been looking for!";
            string HateGift = "This makes me depressed.";
            string NeutralGift = "Thanks.";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            Gift giftMethod = new(SaveData);
            giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
            
        }

        void Investigate()
        {
            //Clint made the statue of mayor Lewis
            bool Case1 = false;
            bool Case2 = false;
            bool Case3 = false;
            SaveData.MyInventory.TryGetValue(Enums.Items.LewisStatue, out int StatueCount);
            Console.WriteLine("Clint > Sure, what's up?");

            while (true)
            {
                if (Case1 && Case2 && Case3) return;

                Console.WriteLine("W > Where were you the night Mayor Lewis was attacked?");
                Console.WriteLine("D > Did you like Lewis?");                
                if (StatueCount >0) Console.WriteLine("S > Do you recognise this statue, by any chance?");
                Console.WriteLine("L > Leave");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "W":
                        Console.WriteLine("Clint > Oh, I was at the Saloon. Usually am on a Friday night.");
                        Console.WriteLine("Me > Did you see or hear anything unusual on your way home? You walk past Lewis' house, right?");
                        Console.WriteLine("Clint > Now you mention it, I did hear some raised voices. I thought it was Old George's TV, he always has it loud because of his bad hearing.");
                        Console.WriteLine("Me > Did you hear what they were saying?");
                        if (SaveData.TheMurderer == "Marnie") Console.WriteLine("Clint > Afraid not. I heard a woman's voice though.");
                        else Console.WriteLine("Clint > Afraid not. Pretty sure it was two men though.");
                        Case1 = true;
                        break;
                    case "D":
                        Console.WriteLine("Clint > Oh, sure. Nice man, always doing his best for the community. It's a real shame he's gone.");
                        Case2 = true;
                        break;
                    case "S" when (StatueCount >0):
                        Console.WriteLine("Clint > Oh, sure. Made that myself. Mayor Lewis wanted a solid gold statue of himself, and wanted it kept secret.");
                        Console.WriteLine("Clint > Paid handsomly for it, too. I always wondered where he got the money to pay for it...");
                        Console.WriteLine("Me > Interesting...");
                        Case3 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }
    }
}
