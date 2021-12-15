using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class George : NPC
    {
        private SaveData SaveData { get; set; }

        public George(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "George";

                if (SaveData.GeorgeCount == 0) //first meeting
                {
                    Console.WriteLine("George > Hmmph... It's irritating to have to meet all these new people, huh? Name's George, by the way. Now buzz off... Hmmph.");
                    SaveData.GeorgeCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 5);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("George > I'm not much of a talker. Especially not to strangers, if you don't mind me saying."); break;
                        case 1: Console.WriteLine("George > Hmmph... Looks like another gloomy day."); break;
                        case 2: Console.WriteLine("George > I can't talk right now, Detective. My favorite program is on."); break;
                        case 3: Console.WriteLine("George > So you're a detective, huh? At least it's honest work."); break;
                        case 4: Console.WriteLine("George > The weekend is no different than any other time, for me. That's how it is when you're retired."); break;
                        case 5: Console.WriteLine("George > Aren't you cold? They don't make sweaters like they used to"); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("Me > Hi George, how are you doing?");
                        Console.WriteLine("George > What? Speak up, I can't hear you!");
                        break;
                    case "G":
                        Console.WriteLine("Me > Would you like this?");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Me > George, can I ask you some questions?");
                        Investigate();
                        break;
                    case "L": SaveData.GeorgeCount++;
                        return;
                    default: break;
                }                
            }
        }

        public override void Gift()
        {
            string NPCName = "George";
            var FavGift = Enums.Items.Leek;
            var DislikedGift = Enums.Items.Clay;
            string LoveGift = "This is my favorite thing! Thank you.";
            string HateGift = "This is probably the worst gift I've ever seen. Thanks a lot.";
            string NeutralGift = "A gift? Hmm...";

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

            Console.WriteLine("George > If you must. But don't take too long, you're interrupting my television time!");

            while (true)
            {
                if (Case1 && Case2 && Case3) return;

                Console.WriteLine("\nW > Where were you the night Lewis was killed?");
                Console.WriteLine("D > Did you know Lewis very well?");
                Console.WriteLine("C > Is there anything you can tell me?");
                Console.WriteLine("L > Leave\n");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "W":
                        Console.WriteLine("George > What? Lewis is dead? Oh, wait, yes I remember now. My memory isn't what it once was. I was here probably. I don't go outside very often.");
                        Case1 = true;
                        break;
                    case "2":
                        Console.WriteLine("George > Lewis? I don't know the boy that well, you'll have to ask Evelyn.");
                        Case2 = true;
                        break;
                    case "3":
                        Console.WriteLine("George > Yes. Next time you see him, tell him to stop making such a racket at all hours of the night. Some of us are trying to sleep!");
                        Case3 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }
    }
}
