using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Morris : NPC
    {
        private SaveData SaveData { get; set; }

        public Morris(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Chat()
        {
            while (true)
            {
                SaveData.LastChat = "Morris";

                if (SaveData.MorrisCount == 0) //first meeting
                {
                    Console.WriteLine("");
                    SaveData.MorrisCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine(""); break;
                        case 1: Console.WriteLine(""); break;
                        case 2: Console.WriteLine(""); break;
                        case 3: Console.WriteLine(""); break;
                        case 4: Console.WriteLine(""); break;
                        case 5: Console.WriteLine(""); break;
                        case 6: Console.WriteLine(""); break;
                        case 7: Console.WriteLine(""); break;
                        case 8: Console.WriteLine(""); break;
                        case 9: Console.WriteLine(""); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

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
                        SaveData.MorrisCount++;
                        return;
                    default: break;
                }

                
            }
        }

        public override void Gift()
        {
            string NPCName = "Morris";
            var FavGift = Enums.Items.JojaCola;
            var DislikedGift = Enums.Items.MapleBar;
            string LoveGift = $"A gift of the highest quality. Thank you, {SaveData.PlayerName}.";
            string HateGift = "You insult me with my competitor's wares.";
            string NeutralGift = "Thank you, this is very nice.";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            Gift giftMethod = new(SaveData);
            giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
          
        }

        void Investigate()
        {

        }
    }
}
