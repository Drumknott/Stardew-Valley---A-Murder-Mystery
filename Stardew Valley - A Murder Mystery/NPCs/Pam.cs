using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    public class Pam : NPC
    {
        private SaveData SaveData { get; set; }

        public Pam(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            SaveData.LastChat = "Pam";

            if (SaveData.PamCount == 0) //first meeting
            {
                //change colour
                Console.WriteLine("Y > Yep, that's me");
                Console.WriteLine("H > How do you know about that?");
                Console.WriteLine("N > Nope, don't know what you mean");
                Console.WriteLine("D > Have you been drinking!?");
                SaveData.PamCount++;

                var Dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (Dialogue1)
                {
                    case "Y": 
                        Console.WriteLine("Me > Yep, that's me. It's, uh, nice to meet you Pam.");
                        Console.WriteLine("Pam > And the same to you, Detecitve...?");
                        SaveData.PlayerName = Console.ReadLine();
                        Console.WriteLine("Pam > Very nice to meet you, Detective "+SaveData.PlayerName);
                        break;
                    case "H": 
                        Console.WriteLine("Me > How do you know about that?");
                        Console.WriteLine("Pam > Oh honey, everybody knows! It's hard to keep secrets around here!");
                        Console.WriteLine("Pam > Say, what's your name?");
                        SaveData.PlayerName = Console.ReadLine();
                        Console.WriteLine("Pam > Well it's nice to meet you, Detective "+SaveData.PlayerName);
                        break;
                    case "N": 
                        Console.WriteLine("Me > Nope, don't know what you mean.");
                        Console.WriteLine("Pam laughs.");
                        Console.WriteLine("Pam > Nice try, but you won't be able to keep secrets around here for long!");
                        Console.WriteLine("Pam > Say, what's your name?");
                        SaveData.PlayerName = Console.ReadLine();
                        Console.WriteLine("Pam > Well it's nice to meet you, Detective " + SaveData.PlayerName);
                        break;
                    case "D": 
                        Console.WriteLine("Me > Have you been drinking!?");
                        Console.WriteLine("Pam looks awkward.");
                        Console.WriteLine("Pam > Oh, er, no! Haha, no. I've been driving! Anyway, I have to get going. It was nice to meet you Detective...?");
                        SaveData.PlayerName = Console.ReadLine();
                        Console.WriteLine("Pam > Well, Welcome to Pelican Town Detective " + SaveData.PlayerName,"!");
                        break;
                    default: break;
                }
                
            }
            
            else
            {
                Random dialogue = new();
                int random = dialogue.Next(0, 10);

                switch (random) //random dialogue
                {
                    case 0: Console.WriteLine("0"); break;
                    case 1: Console.WriteLine("1"); break;
                    case 2: Console.WriteLine("2"); break;
                    case 3: Console.WriteLine("3"); break;
                    case 4: Console.WriteLine("4"); break;
                    case 5: Console.WriteLine("5"); break;
                    case 6: Console.WriteLine("6"); break;
                    case 7: Console.WriteLine("7"); break;
                    case 8: Console.WriteLine("8"); break;
                    case 9: Console.WriteLine("9"); break;
                    default: break;
                }
                //player dialogue options
                Console.WriteLine("a"); //chat
                Console.WriteLine("b"); //gift
                Console.WriteLine("c"); //investigate

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

                SaveData.PamCount++;
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
