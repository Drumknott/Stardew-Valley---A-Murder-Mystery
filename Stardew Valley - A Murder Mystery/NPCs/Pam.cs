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
            if (SaveData.PamCount == 0)
            {
                //change colour
                Console.WriteLine("Y> Yep, that's me");
                Console.WriteLine("H> How do you know about that?");
                Console.WriteLine("N> Nope, don't know what you mean");
                Console.WriteLine("D> Have you been drinking!?");

                var Dialogue1 = Console.ReadLine();

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
        }      
        
        public override void Gift()
        {

        }
    }
}
