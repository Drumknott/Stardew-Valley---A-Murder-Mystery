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
                Console.WriteLine("Y > Yep, that's me");
                Console.WriteLine("H > How do you know about that?");
                Console.WriteLine("N > Nope, don't know what you mean");
                Console.WriteLine("D > Have you been drinking!?");
                SaveData.PamCount++;

                var Dialogue1 = Console.ReadLine();


                Dialogue1 = Dialogue1.Substring(0, 1).ToUpper();

                switch (Dialogue1)
                {
                    case "Y": 
                        Console.WriteLine("Me > Yep, that's me. It's, uh, nice to meet you Pam.");
                        Console.WriteLine("Pam > And the same to you, Detective...?");
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
                while (true)
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Pam > You know, I'd eat healthier food if I could afford it."); break;
                        case 1: Console.WriteLine("Pam > Hey, you! Don't be snoopin' around the trailer when I'm out. Got it? Sorry, but I gotta be cautious with strangers."); break;
                        case 2: Console.WriteLine("Pam > I was reading the newspaper this morning but then I got depressed. It's a rotten world, kid."); 
                            Console.WriteLine("Keep your head screwed on right and you'll make it through in one piece..."); 
                            Console.WriteLine("That's what my Pappy always used to say. Heh heh heh."); break;
                        case 3: Console.WriteLine("Pam > My house ain't pretty but at least it's by the river."); break;
                        case 4: Console.WriteLine("Pam > Hey. Penny's my baby girl. Be nice to her or leave her alone, got it?"); break;
                        case 5: Console.WriteLine("Pam > Penny says I spend too much time at the saloon..."); break;
                        case 6: Console.WriteLine("Pam > You know, I've been thinking... I wish I had a hobby. Something to do other than hanging around at that saloon every night."); 
                            Console.WriteLine("You got any ideas? ...Ehh. Maybe I'll play checkers against myself."); break;
                        case 7: Console.WriteLine("Pam > Each day's just the same as the last... If only I'd been born rich..."); break;
                        case 8: Console.WriteLine("Pam > Make sure your boots are clean before you go stompin' around in my house. It's annoying to clean a mess. You should know that by now."); break;
                        case 9: Console.WriteLine("Pam > I wish a team of elves would come during the night and tidy up my house. Hahahaha."); break;
                        case 10: Console.WriteLine("Pam > I could sure go for some parsnips."); break;
                        case 11: Console.WriteLine("Pam > If my legs weren't so stiff I'd visit the mountains every now and then."); break;
                        default: break;
                    }
                    //player dialogue options
                    Console.WriteLine("a"); //chat
                    Console.WriteLine("b"); //gift
                    Console.WriteLine("c"); //investigate
                    Console.WriteLine("L > Leave");

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
                        case "L": SaveData.PamCount++;
                            return;
                        default: break;
                    }                    
                }
            }
        }      
        
        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give Pam?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            if (gift.Length == 0)
            {
                return;
            }

            else if (gift == "Beer" && Enums.Items.Amethyst > 0)
            {
                Console.WriteLine("Pam > Hey, hey! Now this is really something! Thanks a million, kid."); // NPC loves
                Console.WriteLine(gift + " removed from Inventory.");
                
                SaveData.MyInventory.TryGetValue(Enums.Items.Beer, out var beerCount);
                beerCount--;
                SaveData.MyInventory[Enums.Items.Beer] = beerCount;
            }

            else if (gift == "hate" && Enums.Items.Horseradish > 0)
            {
                Console.WriteLine("Pam > Now this is just absolutely despicable.(Is this some kind of mean joke?)"); //NPC hates
                Console.WriteLine(gift + " removed from Inventory.");
                
                SaveData.MyInventory.TryGetValue(Enums.Items.Octopus, out var octopusCount);
                octopusCount--;
                SaveData.MyInventory[Enums.Items.Octopus] = octopusCount;
            }
            else //neutral
            {
                Console.WriteLine("Pam > Thanks, kid");
                Console.WriteLine(gift + " removed from Inventory.");
            }
        }

        void Investigate()
        {

        }
    }
}
