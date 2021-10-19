using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Willy : NPC
    {
        private SaveData SaveData { get; set; }

        public Willy(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            SaveData.LastChat = "Willy";

            if (SaveData.WillyCount == 0) //first meeting
            {
                Console.WriteLine("");
                SaveData.WillyCount++;
            }

            else
            {
                Random dialogue = new();
                int random = dialogue.Next(0, 10);

                switch (random) //random dialogue
                {
                    case 0: Console.WriteLine(""); break;
                    case 1: Console.WriteLine(""); break;
                    case 2: Console.WriteLine(""); break;
                    case 3: Console.WriteLine(""); break;
                    case 4: Console.WriteLine(""); break;
                    case 5: Console.WriteLine(""); break;
                    case 6: Console.WriteLine(""); break;
                    case 7: Console.WriteLine(""); break;
                    case 8: Console.WriteLine(""); break;
                    case 9: Console.WriteLine(""); break;
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

                SaveData.WillyCount++;
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
