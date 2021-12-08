using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Elliot : NPC
    {
        private SaveData SaveData { get; set; }

        public Elliot (SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            {
                SaveData.LastChat = "Elliott";

                if (SaveData.ElliottCount == 0) //first meeting
                {
                    Console.WriteLine("Elliott > Ah, the Detective we've all been expecting... and whose arrival has sparked many a conversation!");
                    Console.WriteLine("Elloitt > I'm Elliott... I live in the little cabin by the beach. It's a pleasure to meet you.");
                    SaveData.ElliottCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine($"Elliott > I'm kind of new to this town myself, but I really feel at home. I moved here only a year before you."); break;
                        case 1: Console.WriteLine($"Elliott > A great idea can pass through your head when you least expect it... but if your mind is too busy you might miss it. Well, I really must get back to my work."); break;
                        case 2: Console.WriteLine($"Elliott > The sweet friction of pen and paper is the music of my soul. That's why I chose this beach as my home, so that I could have peace and quiet to do my work."); break;
                        case 3: Console.WriteLine($"Elliott > The forest is a wonderful place. Have you been there?"); break;
                        case 4: Console.WriteLine($"Elliott > I can't seem to find the inspiration to begin writing my novel..."); break;
                        case 5: Console.WriteLine($"Elliott > I've been feeling hopeful lately. Perhaps the weather is changing."); break;
                        case 6: Console.WriteLine($"Elliott > Hello, {SaveData.PlayerName}. Are you well?"); break;
                        case 7: Console.WriteLine($"Elliott > The fresh air of this valley is good for body and mind. A quick stroll outdoors always invigorates me."); break;
                        case 8: Console.WriteLine($"Elliott > I'll admit... it takes me several hours each morning to make my hair look this good."); break;
                        case 9: Console.WriteLine($"Elliott > You probably wouldn't like it inside my cabin. It's dark and full of spiders."); break;
                        case 10: Console.WriteLine("Elliott > Please excuse the sorry state of my cabin."); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("Hello, Elliott. How are you doing today?");
                        SaveData.ElliottFriendship++;
                        break;
                    case "G":
                        Console.WriteLine("Elliott, I have a gift for you.");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("May I ask you a few questions?");
                        Investigate();
                        break;
                    case "L":
                        Console.WriteLine("Thank you, Elliott. Talk to you soon.");
                        SaveData.ElliottCount++;
                        return;
                    default: break;
                }
            }
        }

        public override void Gift()
        {
            string NPCName = "Elliott";
            var FavGift = Enums.Items.CrabCakes;
            var DislikedGift = Enums.Items.Amaranth;
            string LoveGift = $"{SaveData.PlayerName}, this is a beautiful gift! Thank you!";
            string HateGift = "This item gives me a terrible feeling. I'll have to dispose of it.";
            string NeutralGift = "Oh, a present! Thank you!";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            Gift giftMethod = new(SaveData);
            int friendshipChange = giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
            SaveData.ElliottFriendship += friendshipChange;
        }

        void Investigate()
        {
            bool Case1 = false;
            bool Case2 = false;
            bool Case3 = false;

            Console.WriteLine("Elliott > Why of course, Detective. Fire away.\n");

            while (true)
            {
                if (Case1 && Case2 && Case3) return;

                Console.WriteLine("I > What was your impression of Lewis?");
                Console.WriteLine("W > Where were you the night he was attacked?");
                Console.WriteLine("A > Is there anything else you think I should know?");
                Console.WriteLine("L > Leave");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "I":
                        Console.WriteLine("Elliott > He was a nice man. Always working on some town project or other. I can't imagine why anyone would wish him harm.");
                        Case1 = true;
                        break;
                    case "W":
                        Console.WriteLine("Elliott > I was at home. A nice fire, the sound of the waves, and a good book.");
                        Console.WriteLine("Me > That sounds lovely.");
                        Console.WriteLine("Elliott > It truely is. You should consider it for yourself, Detective. The country life can be very rewarding.");
                        Case2 = true;
                        break;
                    case "A":
                        Console.WriteLine("Elliott > This is a small town. Everyone knows each others business, and it's hard to keep secrets.");
                        Console.WriteLine("Elliott > If you speak to the right people, and ask the right questions, you'll find out what you need to know.");
                        Case3 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }
    }
}
