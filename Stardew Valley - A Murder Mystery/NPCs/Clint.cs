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
                    case "L":
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
        }
    }
}
