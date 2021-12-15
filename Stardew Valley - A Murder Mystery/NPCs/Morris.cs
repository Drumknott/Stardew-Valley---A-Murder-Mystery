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
                        Console.WriteLine("Hi, Morris. How's business?");
                        break;
                    case "G":
                        Console.WriteLine("Me > Is this any good to you?");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Me > I know you're busy but can I ask you a few questions?");
                        Investigate();
                        break;
                    case "L":
                        SaveData.MorrisCount++;
                        Console.WriteLine("Me > Thanks Morris. Good luck in the election!");
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
            bool Case1 = false;
            bool Case2 = false;
            bool Case3 = false;

            Console.WriteLine("Morris > Of course Detective, I'll do anything I can to help.");

            while (true)
            {
                if (Case1 && Case2 && Case3) return;

                Console.WriteLine("\nW > What were you doing last Friday evening?");
                Console.WriteLine("H > How did you get on with Mayor Lewis?");
                if (SaveData.CrypticNote) Console.WriteLine("N > Can you tell me anything about this note?");
                Console.WriteLine("L > Leave\n");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "W":
                        Console.WriteLine("Morris > Nothing exciting unfortunately. Friday evening is when we do our stock check. I can show you the inventory lists if that's of any help?");
                        Case1 = true;
                        break;
                    case "H":
                        Console.WriteLine("Morris > Lewis and I had different visions for Pelican Town. He liked to maintain the status quo, while");
                        Console.WriteLine("Morris > I have a wonderful vision for the future, to really help the town grow and prosper.");
                        Console.WriteLine("Me > Did you ever argue about it?");
                        Console.WriteLine("Morris > Not at all. We had an agreement to disagree.");
                        Case2 = true;
                        break;
                    case "N" when (SaveData.CrypticNote):
                        Console.WriteLine("Morris peers at the paper.");
                        Console.WriteLine("Morris > No, I can't say I can. It looks like someone was trying to buy the Community Centre.");
                        Console.WriteLine("Me > And you wouldn't be 'M' here, would you?");
                        Console.WriteLine("Morris > What are you saying, Detective? Accusing me of bribery, or blackmail?");
                        Console.WriteLine("Me > The word around town is you want to turn the community centre into a warehouse.");
                        Console.WriteLine("Morris > Is it wrong to use an empty, unused building to benefit the community, create jobs? No.");
                        Console.WriteLine("Morris > But I can assure you, I neither wrote that note, nor did I murder Lewis.");
                        Case3 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }
    }
}
