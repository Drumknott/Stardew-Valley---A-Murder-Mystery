using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Hayley : NPC
    {
        private SaveData SaveData { get; set; }

        public Hayley(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Haley";

                if (SaveData.HaleyCount == 0) //first meeting
                {
                    Console.WriteLine("Haley > Oh... you're that Detective, aren't you? Huh? Oh... I'm Haley. Hmm... If it weren't for those horrendous clothes you might actually be cute. Actually, nevermind.");
                    SaveData.HaleyCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 6);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Haley > This town is so small. It sucks. I have to drive, like, twenty miles to buy any decent clothes. That's why I usually just order online. What?"); break;
                        case 1: Console.WriteLine("Haley > The only thing I like about this town is the beach."); break;
                        case 2: Console.WriteLine("Haley > *sigh* I could really go for a cupcake right now. Do you need something?"); break;
                        case 3: Console.WriteLine("Haley > I’ve decided I am going to organise my clothes today. I'll have to throw out all of last year's styles to make room for the new ones!"); break;
                        case 4: Console.WriteLine("Haley > I'm feeling an urge to go shopping. Ugh! I wish there was a mall here."); break;
                        case 5: Console.WriteLine("Haley > My sister is so weird. Sometimes I wonder if we're actually related."); break;
                        case 6: Console.WriteLine("Haley > Did you know that my sister hates FishTaco? She finds it absolutely revolting. I guess everyone has their hang-ups."); break;
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
                        SaveData.HaleyFriendship++;
                        break;
                    case "G":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("");
                        Investigate();
                        break;
                    case "L": SaveData.HaleyCount++;
                        return;
                    default: break;
                }               
            }
        }

        public override void Gift()
        {
            string NPCName = "Haley";
            var FavGift = Enums.Items.Coconut;
            var DislikedGift = Enums.Items.PrismaticShard;
            string LoveGift = "Oh my god, this is my favorite thing!";
            string HateGift = "Gross!";
            string NeutralGift = "Thank you. I love presents.";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            Gift giftMethod = new(SaveData);
            int friendshipChange = giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
            SaveData.HaleyFriendship += friendshipChange;
        }

        void Investigate()
        {

        }
    }
}
