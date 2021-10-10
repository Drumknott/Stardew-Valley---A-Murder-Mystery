using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Marnie : NPC
    {
        private SaveData SaveData { get; set; }

        public Marnie(SaveData saveData)
        {
            SaveData = saveData;
        }

        bool caseP { get; set; }

        public override void Chat()
        {
            SaveData.LastChat = "Marnie";

            if (SaveData.MarnieCount == 0)
            {
                Console.WriteLine("Ah, Pam told me you just arrived. I'm Marnie! I sell livestock and animal care products at my ranch. You should swing by some time.");
                SaveData.MarnieCount++;
            }

            else
            {
                Random dialogue = new();
                int random = dialogue.Next(0, 10);

                switch (random) // Marnie random dialogue
                {
                    case 0: Console.WriteLine("Marnie > I love animals, Detective "+SaveData.PlayerName+". If you treat yours well I'm sure we'll become good friends!"); break;
                    case 1: Console.WriteLine("Marnie > Animals are so innocent, so sweet. And If I don't look after them, who will? I just hope my chickens aren't too upset when I take their eggs."); break;
                    case 2: Console.WriteLine("Marnie > You've been here a while, now... how's your investigating going?"); break;
                    case 3: Console.WriteLine("Marnie > My nephew Shane has been staying at my place the last few months.He helps me out with the chickens, so I'm not complaining."); break;
                    case 4: Console.WriteLine("Marnie > You can use a scythe to cut feed from grass.Or you can buy it from me, of course! I could use the cash... Adios."); break;
                    case 5: Console.WriteLine("Marnie > You can catch me at the saloon most nights. Animals are great company, but I need to spend some time with people, too."); break;
                    case 6: Console.WriteLine("Marnie > I would be so lonely if Shane ever moved out."); break;
                    case 7: Console.WriteLine("Marnie > Hey there, it's good to see ya! Feel free to visit us any time you please."); break;
                    case 8: Console.WriteLine("Marnie > Have you been to that strange tower west of my house? One time I heard this terrible, otherworldly noise coming from there. I would avoid that place if I were you..."); break;
                    case 9: Console.WriteLine("Marnie quickly wipes away a tear and tries to pretend she wasn't crying.");
                        Console.WriteLine("Marnie > Oh, Hi Detective. What can I do for you?");
                        break;
                    default: break;            
                }

                //player dialogue options - chat gift investigate
                Console.WriteLine("H > Hi Marnie, just wanted to see how you're doing.");
                Console.WriteLine("G > Hey, I thought you might like this?");
                Console.WriteLine("L > Hi Marnie. I was wondering if I could ask you a few questions about Mayor Lewis?");

                var dialogue1 = Console.ReadLine();

                switch (dialogue1)
                {
                    case "H": Console.WriteLine("Hi Marnie. How are you?");
                        if (SaveData.MarnieAndMarlon == true)
                        {
                            //happy Marnie
                            Console.WriteLine("Marnie smiles.");
                            Console.WriteLine("Marnie > Oh I'm great, thank you for asking Detective.");
                        }
                        else
                        {
                            Console.WriteLine("Marnie looks uncomfortable.");
                            Console.WriteLine("Marnie > Oh you know, getting on with things. The animals always need me!");
                        }
                        break;
                    case "G": Console.WriteLine("Marnie, I thought you might like this?");
                        Gift();
                        break;
                    case "L": Console.WriteLine("Hi Marnie. I'm here on official business I'm afraid. Can I ask you a few questions about Mayor Lewis?");
                        Console.WriteLine("Marnie > Oh, um, yes I suppose.");
                        Investigate();
                        break;
                    default: break;
                }
            }  
        }

        public override void Gift()
        {

        }

        void Investigate()
        {
            while (true)
            {
                Console.WriteLine("P > You called the Police?");
                Console.WriteLine("");
                if (SaveData.MarnieAndLewis == true)
                {
                    Console.WriteLine("I > Is it true you were having a relationship with Lewis?");
                }
                Console.WriteLine("L > Leave");

                var answer = Console.ReadLine();

                if (answer == "L") break;
                if (caseP == true) break;

                else switch (answer)
                {
                    case "P":
                        Console.WriteLine("Firstly, according to my case notes it was you who discovered Lewis' body and called the police. Can you tell me about the events of that evening?");
                        caseP = true;
                        break;
                    case "I":
                        Console.WriteLine("Is it true that you and Lewis were in a relationship? Why was it a secret?");
                        break;
                    default: break;
                }
            }
        }
    }
}
