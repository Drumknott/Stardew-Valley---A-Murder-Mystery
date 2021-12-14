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
                    Console.WriteLine("Morris > Welcome to Joja Mart. My name is Morris. Can I interest you in one of our excellent value membership plans?");
                    SaveData.MorrisCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 8);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Morris > Joja Mart is bringing affordable prices to everyone."); break;
                        case 1: Console.WriteLine("Morris > If you ever feel like a career change, I'm sure our debt collection department would be keen to meet you."); break;
                        case 2: Console.WriteLine("Morris > Pierre thinks I'm this evil corporate pawn, here to destroy his business."); break;
                        case 3: Console.WriteLine("Morris > Why shop at Pierre's when he charges so much more than Joja Mart?"); break;
                        case 4: Console.WriteLine("Morris > Always shop local. Except when you can get a better price at Joja Mart."); break;
                        case 5: Console.WriteLine("Morris > I'm running for Mayor on Sunday - be sure to Vote for Mayor Morris!"); break;
                        case 6: Console.WriteLine("Morris > When I'm Mayor I can really improve this town."); break;
                        case 7: Console.WriteLine("Morris > The old community centre is just sitting there - why not make use of it?"); break;                       
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
            if (SaveData.CrypticNote == true)
            {

            }

            bool Case1 = false;
            bool Case2 = false;
            bool Case3 = false;

            Console.WriteLine("");

            while (true)
            {
                if (Case1 && Case2 && Case3) return;

                Console.WriteLine("");
                Console.WriteLine("");
                if (SaveData.CrypticNote) Console.WriteLine("");
                Console.WriteLine("L > Leave");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "1":
                        Console.WriteLine("");
                        Case1 = true;
                        break;
                    case "2":
                        Console.WriteLine("");
                        Case2 = true;
                        break;
                    case "3" when (SaveData.CrypticNote):
                        Console.WriteLine("");
                        Case3 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }
    }
}
