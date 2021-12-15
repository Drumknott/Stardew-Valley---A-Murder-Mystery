using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Alex : NPC
    {
        private SaveData SaveData { get; set; }

        public Alex(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            {
                SaveData.LastChat = "Alex";

                if (SaveData.AlexCount == 0)
                {
                    //first meeting
                    Console.WriteLine("Alex > Oh, hey. So you're the Detective, huh? Cool. I'm Alex. I'll see you around.");
                }
                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 6);

                    switch (random) // generic chat
                    {
                        case 0: Console.WriteLine("Alex > Did you know I was an all - star quarterback in high school? It's true. See this little star on my jacket here? That proves it."); break;
                        case 1: Console.WriteLine("Alex > The air's starting to warm up... I'm feeling pumped."); break;
                        case 2: Console.WriteLine("Alex > My arms are really sore, but that's the sign of progress for a guy like me. I must've done a thousand push - ups yesterday."); break;
                        case 3: Console.WriteLine("Alex > Hey.What, you wanna talk to me? I'm busy."); break;
                        case 4: Console.WriteLine("Alex > Hey, " + SaveData.PlayerName + ".That's right, I remember your name."); break;
                        case 5: Console.WriteLine("Alex > Hey, " + SaveData.PlayerName + ".How's your day going?"); break;
                        case 6: Console.WriteLine("Alex > Hey, " + SaveData.PlayerName + ".I'm glad you stopped by. I'm not ashamed to say that I love my Grandma! Now Grandpa, on the other hand... Just kidding."); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("Me > Hey Alex, what's up?");
                        SaveData.AlexCount++;
                        break;
                    case "G":
                        Console.WriteLine("Me > Hey, would you like this?");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Me > Alex, do you mind if I ask you about Mayor Lewis?");
                        Investigate();
                        Console.WriteLine("Me > Thanks Alex, I think I've got what I need.\n");
                        break;
                    case "L":
                        Console.WriteLine("Me > See you soon, Alex!");
                        SaveData.AlexCount++;
                        return;
                    default: break;
                }
            }
        }

        public override void Gift()
        {
            string NPCName = "Alex";
            var FavGift = Enums.Items.CompleteBreakfast;
            var DislikedGift = Enums.Items.Holly;
            string LoveGift = "Hey, awesome! I love this stuff!";
            string HateGift = "Are you serious? This is garbage.";
            string NeutralGift = "Thanks!";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            Gift giftMethod = new(SaveData);
            int friendshipChange = giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
            SaveData.AlexFriendship += friendshipChange;
        }

        void Investigate()
        {
            bool CaseN = false;
            bool CaseW = false;
            bool CaseH = false;

            Console.WriteLine("Alex > Sure thing. What do you want to know?");

            while (true)
            {
                if (CaseN && CaseH && CaseW) return;

               
                Console.WriteLine("\nN > Lewis was your neighbor - how did you like him?");
                Console.WriteLine("W > Where were you last Friday night?");
                Console.WriteLine("H > Have you ever heard any arguments or disagreements from Lewis' house?");
                Console.WriteLine("L > Leave\n");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "N":
                        Console.WriteLine("Alex > He was fine, I guess. I didn't talk to him much. I tried talking to him about football one time but he said he didn't like sports...");
                        CaseN = true;
                        break;
                    case "W":
                        Console.WriteLine("Alex > I was hanging out at Haley's. Emily works at the Saloon in the evenings so we usually have the place to ourselves.");
                        Console.WriteLine("Me > Did you see or hear anything unusual on your walk home?");
                        Console.WriteLine("Alex > Uh... haha, my walk home was early Saturday morning, if you get my meaning...");
                        CaseW = true;
                        break;
                    case "H":
                        Console.WriteLine("Alex > Sometimes, yeah. I've heard him argue with a woman a couple of times. Don't know who it was though.");
                        Console.WriteLine("Me > Could you hear what they were arguing about?");
                        Console.WriteLine("Alex > Nah, sorry Detective. I could just hear raised voices, that's all.");
                        CaseH = true;
                        break;
                    case "L":
                        return;
                    default: break;
                }
            }
        }
    }
}
