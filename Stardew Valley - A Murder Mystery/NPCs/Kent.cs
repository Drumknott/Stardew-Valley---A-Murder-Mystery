using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Kent : NPC
    {
        private SaveData SaveData { get; set; }

        public Kent(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Kent";

                if (SaveData.KentCount == 0) //first meeting
                {
                    Console.WriteLine("Kent > Um, hello there. My name's Kent. I'm running for MAyor of Pelican Town. Well, I just wanted to introduce myself... I'll see you around.");
                    SaveData.KentCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Kent > I don't know if I'll ever get used to being back home. The peacefulness of the town feels like a mask. That's probably just me though."); break;
                        case 1: Console.WriteLine("Kent > Things haven't changed much since I've been gone. Well, except that you're here."); break;
                        case 2: Console.WriteLine("Kent > I've been up since 4 o'clock... sometimes I wonder if I'll ever get back into a normal routine."); break;
                        case 3: Console.WriteLine("Kent > Sam has really grown up since I left. He's a man now. I wish I could've been there for him."); break;
                        case 4: Console.WriteLine("Kent > It looks like a decent day for fishing, doesn't it?"); break;
                        case 5: Console.WriteLine("Kent > I'm running for Mayor - "); break;
                        case 6: Console.WriteLine("Kent > Vote Kent to serve the community!"); break;
                        case 7: Console.WriteLine("Kent > Vote for Kent!"); break;
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
                    case "L": SaveData.KentCount++;
                        return;
                    default: break;
                }             
            }
        }

        public override void Gift()
        {
            string NPCName = "Kent";
            var FavGift = Enums.Items.Risotto;
            var DislikedGift = Enums.Items.Holly;
            string LoveGift = "Oh...! Mom used to give me this when I was a young boy. It brings back wonderful memories. Thank you.";
            string HateGift = "This... They gave this to me in Gotoro prison camp. I've been trying to forget about that. *shudder*";
            string NeutralGift = "That's kind of you. The family will like this.";

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
