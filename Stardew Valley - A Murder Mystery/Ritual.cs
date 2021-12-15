using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    public class Ritual
    {
        private SaveData SaveData { get; set; }

        public Ritual(SaveData saveData)
        {
            SaveData = saveData;
        }
        public void SecretRitual()
        {
            SaveData.npc1 = "Willy";
            SaveData.npc2 = "Wizard";

            Console.WriteLine("Behind you, the sky is blue and you can see birds flying; in front of you, black clouds gather and spin ominously above the lake. \nYou see flashes of lightning from within the clouds. What's going on!?");
            Console.WriteLine("Over the wind you think you can just make out voices from up ahead.\n");
            Console.WriteLine("What do you want to do?\n");
            Console.WriteLine("I > Investigate");
            Console.WriteLine("H > Get the hell out of here");

            switch (Console.ReadLine().Substring(0, 1).ToUpper())
            {
                case "I":
                    Console.WriteLine("\nSlowly, reservedly, you head closer. The wind picks up, but you can still make out voices ahead of you. ");
                    Console.WriteLine("They sound like they're... chanting?");
                    Console.WriteLine("You come out into a clearing at the south side of the lake. Above you, the black clouds swell and twist menacingly.");
                    Console.WriteLine("In the middle of the clearing, Willy and the Wizard are standing either side of a circle of candles that seem somehow immune to the wind.");
                    Console.WriteLine("They're chanting something, but stop as soon as they see you.");
                    Console.WriteLine("Willy > I know what this looks like, Detective, but it's not what you think. Mr. Rasmodius here, he has ways of knowing things.");
                    Console.WriteLine("Willy > And we was thinking we could help you with your investigation...");
                    Console.WriteLine("The wind continues to rage all around us.");
                    Console.WriteLine("Me > What are you trying to say, Willy?");
                    Console.WriteLine("The Wizard > The easiest way to find a murderer, Detective, is to ask the victim who killed them.\n");
                    Console.WriteLine("N > This is nonsense");
                    Console.WriteLine("L > I'm listening");
                    switch(Console.ReadLine().Substring(0, 1).ToUpper())
                    {
                        case "N":
                            Console.WriteLine("The Wizard > As you wish. We'll leave you to solve this yourself.");
                            Console.WriteLine("Within seconds, the black clouds vanish and the wind drops to a gentle breeze.");
                            Console.WriteLine("The Wizard > Good luck with your case, Detective. Good day.");
                            break;
                        case "L":
                            Console.WriteLine("The Wizard nods, and he and Willy continue their chanting. The circle of candles glows brighter and brighter,");
                            Console.WriteLine("and a shape begins to appear in the middle of the circle - it looks like Lewis.");
                            Console.WriteLine("The Wizard > Lewis! Who was it that took your life?");
                            Console.WriteLine("The shape looks at the Wizard, and seems to sigh. It tries to speak, but you can't hear it over the wind.");
                            Console.WriteLine("The Wizard calls out again, and this time you can faintly hear the words 'It was my fault...' before the candles simultaniously snuff out and the shape of Lewis vanishes.");
                            Console.WriteLine("Within seconds, the black clouds vanish and the wind drops to a gentle breeze.");
                            Console.WriteLine("The Wizard sighs.");
                            Console.WriteLine("Willy > Poor Lewis. I hope he finds peace.");
                            Console.WriteLine("The Wizard > I'm sorry, Detective, I believed this would be of more help. It looks like you have to solve this case yourself.");
                            break;
                        default: break;
                    }
                    break;
                case "H":
                    Console.WriteLine("\nSomething about this feels wrong. You turn on your heel and head back towards the safety of town.");
                    break;
                default: break;
            }
            SaveData.Ritual = true;
        }
    }
}
