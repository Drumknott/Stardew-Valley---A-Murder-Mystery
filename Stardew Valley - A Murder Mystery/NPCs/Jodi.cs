using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Jodi : NPC
    {
        private SaveData SaveData { get; set; }

        public Jodi(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Jodi";

                if (SaveData.JodiCount == 0) //first meeting
                {
                    Console.WriteLine("Jodi > Oh! You aren't exactly how I imagined... but that's okay! I'm Jodi.");
                    Console.WriteLine("Jodi > It's a quiet little town, so it's very exciting when someone new moves in! Having a Detective around could really change things.");
                    SaveData.JodiCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 9);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Jodi > Maintaining a household is difficult work... but somebody has to do it. Yes?"); break;
                        case 1: Console.WriteLine("Jodi > Exercise is important for staying healthy. I always make sure to set aside some time for it.");
                                Console.WriteLine("Jodi > As a parent, I don't have much time to devote to myself. So I try and make every minute count."); break;
                        case 2: Console.WriteLine("Jodi > I wish I could spend more time outside, but there's so much work to do."); break;
                        case 3: Console.WriteLine("Jodi > I started wearing rubber gloves to keep my hands soft. The older you get, the more work you have to do to stay healthy. Ok, bye!"); break;
                        case 4: Console.WriteLine("Jodi > The food at JojaMart might not be the healthiest for my family, but with such low prices you'd be crazy to shop anywhere else!"); break;
                        case 5: Console.WriteLine("Jodi > Hi. Need something?"); break;
                        case 6: Console.WriteLine("Jodi > I'm taking a break from house chores today. I'm taking the day off. If I don't spend any time outside, I'll go crazy! Plus I don't want my legs to turn soft."); break;
                        case 7: Console.WriteLine("Jodi > Kent is running for mayor. I really hope he wins!"); break;
                        case 8: Console.WriteLine("Jodi > Vote for Kent!"); break;
                        case 9: Console.WriteLine("Jodi > Kent will be a great mayor. It will be so good for him to serve the community again."); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("Me > Hi Jodi, how are things?");                        
                        break;
                    case "G":
                        Console.WriteLine("Me > Here, thought you'd like this");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Me > Hey Jodi, can I ask you something?");
                        Investigate();
                        break;
                    case "L": SaveData.JodiCount++;
                        return;
                    default: break;
                }                
            }
        }

        public override void Gift()
        {
            string NPCName = "Jodi";
            var FavGift = Enums.Items.ChocolateCake;
            var DislikedGift = Enums.Items.Daffodil;
            string LoveGift = "Oh, you're such a sweetheart! I really love this!";
            string HateGift = "*Blech*... I hate this...";
            string NeutralGift = "That's so nice of you! Thanks.";

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

            Console.WriteLine("Jodi > Sure, what's up?");

            while (true)
            {
                if (SaveData.PTSD == true)
                {
                    if (Case1 && Case2 && Case3) return;
                }
                else if (Case1 && Case2) return;

                Console.WriteLine("\nW > Where were you the night Lewis was attacked?");
                Console.WriteLine("I > What was your impression of Lewis?");
                if (SaveData.PTSD == true) Console.WriteLine("K > How has Kent been since he returned from the army?");
                Console.WriteLine("L > Leave");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "W":
                        Console.WriteLine("Jodi > I was at home. I like having the house to myself, it makes it easier to get the housework done.");
                        Console.WriteLine("Me > So Kent and Sam were out?");
                        Console.WriteLine("Jodi > Yes, they were both at the saloon I think.");
                        SaveData.WhereWasKent = true;
                        Case1 = true;
                        break;
                    case "K" when (SaveData.PTSD == true):
                        Console.WriteLine("Jodi > He had a hard time, but he's adjusting back to normal life.");
                        Console.WriteLine("Jodi > I think winning this election would be a great way for him to integrate back into the community fully.");
                        Console.WriteLine("Me > Has he ever shown any sort of violent behaviour?");
                        Console.WriteLine("Jodi > No. How dare you! I know what he's done, what he's had to do, but that doesn't make him a killer.");
                        Console.WriteLine("Me > I'm sorry. I just have to investigate every avenue.");
                        Case2 = true;
                        break;
                    case "3":
                        Console.WriteLine("Jodi > Lewis was a decent man. He wasn't perfect, but who is? ");
                        Console.WriteLine("He worked hard for the town, he did his best for us.");
                        Case3 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }
    }
}
