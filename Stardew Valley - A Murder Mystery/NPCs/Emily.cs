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
                        case 10: Console.WriteLine("Emily > This house was left in our care by my parents. They've been traveling the world for the last two years. We have no idea when they'll be back. I enjoy living here, though. It's a beautiful area and the town is nice."); break;
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
                        SaveData.EmilyFriendship++;
                        break;
                    case "G":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("");
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

        }

        void Investigate()
        {

        }

    }
}
