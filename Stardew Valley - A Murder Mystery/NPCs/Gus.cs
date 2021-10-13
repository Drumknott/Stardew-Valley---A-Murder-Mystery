using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Gus : NPC
    {
        private SaveData SaveData { get; set; }

        public Gus(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {            
            SaveData.LastChat = "Gus";

            if (SaveData.GusCount == 0) //first meeting
            {
                Console.WriteLine("Gus > Hi there, welcome to the Stardrop Saloon!");
                SaveData.GusCount++;
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
                Console.WriteLine("I was hoping to buy something from you Gus"); //buy stuff

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
                    case "buy":
                        Console.WriteLine("");
                        Buy();
                        break;
                    default: break;
                }

                SaveData.GusCount++;
            }
        }

        public override void Gift()
        {
            
        }

        void Investigate()
        {

        }

        void Buy()
        {
            //why oh why would I introduce money into a game like this???
        }
    }
}
