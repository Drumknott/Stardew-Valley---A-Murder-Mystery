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

                if (SaveData.ElliotCount == 0) //first meeting
                {
                    Console.WriteLine("Elliott > Ah, the Detective we've all been expecting... and whose arrival has sparked many a conversation!");
                    Console.WriteLine("Elloitt > I'm Elliott... I live in the little cabin by the beach. It's a pleasure to meet you.");
                    SaveData.ElliotCount++;
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

                var dialogue1 = Console.ReadLine();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("");
                        SaveData.ElliotFriendship++;
                        break;
                    case "G":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("");
                        Investigate();
                        break;
                    case "L":
                        SaveData.ElliotCount++;
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
