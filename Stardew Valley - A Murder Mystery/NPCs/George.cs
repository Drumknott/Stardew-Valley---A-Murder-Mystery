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
                //player dialogue options
                Console.WriteLine(""); //chat
                Console.WriteLine(""); //gift
                Console.WriteLine(""); //investigate

                var dialogue1 = Console.ReadLine();

                switch (dialogue1)
                {
                    case "chat":
                        Console.WriteLine("");                        
                        break;
                    case "gift":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "investigate":
                        Console.WriteLine("");
                        Investigate();
                        break;
                    default: break;
                }

                SaveData.GeorgeCount++;
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
