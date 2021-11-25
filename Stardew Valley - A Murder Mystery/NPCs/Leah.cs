using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Leah : NPC
    {
        private SaveData SaveData { get; set; }

        public Leah(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Leah";

                if (SaveData.LeahCount == 0) //first meeting
                {
                    Console.WriteLine("Leah > Hello, it's nice to meet you. You picked a good time to visit... The spring is lovely.");
                    SaveData.LeahCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Leah > Hi. Oh, you want to talk? The landscape around here gives me a lot of ideas. The terrain is almost like a sculpture itself."); break;
                        case 1: Console.WriteLine("Leah > I don't make art for money. It's just an urge that I have."); break;
                        case 2: Console.WriteLine("Leah > This morning I accidentally stepped on a bug. Sometimes I think it's impossible to live without destroying nature in some way."); break;
                        case 3: Console.WriteLine("Leah > There's actually a lot of wild food in this area, if you know where to look. I've been having fresh salads almost every day."); break;
                        case 4: Console.WriteLine("Leah > It's simpler to be friends with the trees. They don't have much to say."); break;
                        case 5: Console.WriteLine("Leah > We wouldn't be able to survive without nature. It's good to remember that."); break;
                        case 6: Console.WriteLine($"Leah > Hello, {SaveData.PlayerName}. It's a nice day, isn't it? Stop by my cabin if you ever need someone to talk to."); break;
                        case 7: Console.WriteLine("Leah > I love to decorate for the different seasons."); break;
                        case 8: Console.WriteLine("Leah > If you hear any banging from inside my hut, it's probably just me working on one of my sculptures."); break;
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
                        SaveData.LeahFriendship++;
                        break;
                    case "G":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("");
                        Investigate();
                        break;
                    case "L": SaveData.LeahCount++;
                        return;
                    default: break;
                }            
            }
        }

        public override void Gift()
        {
            string NPCName = "Leah";
            var FavGift = Enums.Items.GoatCheese;
            var DislikedGift = Enums.Items.Bread;
            string LoveGift = "Oh! This is exactly what I wanted! Thank you!";
            string HateGift = "This is a pretty terrible gift, isn't it?";
            string NeutralGift = "Thank you.";

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
