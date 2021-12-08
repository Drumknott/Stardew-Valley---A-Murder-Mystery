using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Emily : NPC
    {
        private SaveData SaveData { get; set; }

        public Emily(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
            SaveData.LastChat = "Emily";

                if (SaveData.EmilyCount == 0) //first meeting
                {
                    Console.WriteLine("Emily > Ooh!... I can read it on your face. You're going to love it here in Pelican Town. If you're ever looking for something to do in the evening, stop by the saloon. That's where I work!");
                    SaveData.EmilyCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Emily > Have I told you Haley and I are sisters? Strange, isn't it?"); break;
                        case 1: Console.WriteLine("Emily > I have a secret hobby, but I won't say any more. Maybe I'll show you some day."); break;
                        case 2: Console.WriteLine("Emily > This world is full of spirits and magic... Some don't believe me, but I know it's true. I can see it in your eyes... you believe in the other world, like me."); break;
                        case 3: Console.WriteLine("Emily > I wish Haley would get a job or at least contribute to cooking and cleaning. I think she's hoping to marry someone rich."); break;
                        case 4: Console.WriteLine("Emily > I work part-time at Gus' saloon. It pays the bills."); break;
                        case 5: Console.WriteLine("Emily > I'm just working at Gus' to make ends meet... but my real passion is tailoring. I made these clothes from scratch, see?"); break;
                        case 6: Console.WriteLine("Emily > I've heard rumors of rare and powerful magic rings, forged long ago by forgotten civilizations. I'm not sure if it's true or just a fairy tale."); break;
                        case 7: Console.WriteLine("Emily > Sometimes the flowers speak to me... each one has a different story to tell!"); break;
                        case 8: Console.WriteLine("Emily > Ah, spring. The season of pastels. I actually prefer jewel tones, myself. Oh, excuse me! I was mumbling about fashion again, wasn't I?"); break;
                        case 9: Console.WriteLine("Emily > I like making my own clothes, but it's not easy to get cloth. And it's such a long trip to the city."); break;
                        case 10: Console.WriteLine("Emily > This house was left in our care by my parents. They've been traveling the world for the last two years.\nWe have no idea when they'll be back. I enjoy living here, though. It's a beautiful area and the town is nice."); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("Me > Hi Emily.");
                        SaveData.EmilyFriendship++;
                        break;
                    case "G":
                        Console.WriteLine("Me > Emily, I thought you might like this?");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Me > May I ask you a few questions?");
                        Investigate();
                        break;
                    case "L": SaveData.EmilyCount++;
                        return;
                    default: break;
                }               
            }
        }

        public override void Gift()
        {
            string NPCName = "Emily";
            var FavGift = Enums.Items.Amethyst;
            var DislikedGift = Enums.Items.FishTaco;
            string LoveGift = "This gift is fabulous! Thank you so much!";
            string HateGift = "This gift has a strong negative energy. I can't stand it.";
            string NeutralGift = "Thanks!";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            Gift giftMethod = new(SaveData);
            int friendshipChange = giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
            SaveData.EmilyFriendship += friendshipChange;
        }

        void Investigate()
        {
            bool Case1 = false;
            bool Case2 = false;
            bool Case3 = false;

            Console.WriteLine("Emily > Sure! What's on your mind?");

            while (true)
            {
                if (Case1 && Case2 && Case3) return;

                Console.WriteLine("F > Can you tell me about Friday night?");
                Console.WriteLine("H > How did you like Lewis?");
                Console.WriteLine("W > What do you think happened?");
                Console.WriteLine("L > Leave");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "F":
                        Console.WriteLine("Emily > Well I was working at the saloon as usual. Marnie came rushing in screaming something about Lewis, so Gus, Shane and Willy went to help her.");
                        Console.WriteLine("Emily > Gus told me to stay and mind the bar.");
                        Console.WriteLine("Me > And what happened next?");
                        Console.WriteLine("Well Gus came back after about an hour and said Lewis was dead! It's so awful.");
                        Case1 = true;
                        break;
                    case "H":
                        Console.WriteLine("Emily > I mean I didn't know him too well but he seemed like a nice man. I can't imagine why anyone would want to kill him.");
                        Case2 = true;
                        break;
                    case "W":
                        Console.WriteLine("Emily > Oh, goodness. I don't know. It feels mean to say, but I'm a big believer in karma. Maybe he had it coming?");
                        Case3 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }

    }
}
