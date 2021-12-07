using Stardew_Valley___A_Murder_Mystery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    public class ElectionDay
    {
        private SaveData SaveData { get; set; }

        public ElectionDay(SaveData saveData)
        {
            SaveData = saveData;
        }
        
        public void Election()
        {
            if (SaveData.ElectionStart != true)
            {
                Console.WriteLine("There's a large crowd gathered in the town square - it looks like pretty much everyone is here.");
                Console.WriteLine("The square has been decorated with flags, garlands and flowers.A small stage has been erected to the side of the saloon,");
                Console.WriteLine("with a microphone, large speakers and a giant screen that's currently displaying 'Pelican Town Mayoral Election'.");
                Console.WriteLine("A few voting booths have been set up to one side, and townsfolk are taking turns to go in, mark their ballots,");
                Console.WriteLine("then dropping their votes into a box outside. A large man with a purple hat that you don't recognise is overseeing the process.");
                Console.WriteLine("Pierre, Kent and Morris are all here, chatting with other townsfolk and shaking hands. Pierre and Kent seem nervous,");
                Console.WriteLine("but Morris seems as smug as ever. \n");
                Console.WriteLine("The man with the purple hat steps onto the stage and signals for everyone to pay attention.");
                Console.WriteLine("Governor > Hello, fine people of Pelican Town! Firstly, let me express my condolences to you all for the loss of Mayor Lewis.");
                Console.WriteLine("Governor > I know he was much beloved, and he will be sorely missed by all of us. However, as Governor it falls to me to organise his");
                Console.WriteLine("Governor > replacement, and I am proud to oversee this Mayoral Election.Voting is open for another hour,");
                Console.WriteLine("Governor > after which the votes will be counted and your new Mayor will be elected.Thank you!\n");
                SaveData.ElectionStart = true;
            }

            Console.WriteLine("A group of townsfolk nearby spot you, and Robin calls out.");
            Console.WriteLine("Robin > Hi Detective! How are you doing?");

            while (true)
            {
                if (SaveData.NPCaccused == true) break;

                Console.WriteLine("\nC > Chat with Townsfolk");
                Console.WriteLine("A > Accuse the Murderer");
                Console.WriteLine("L > Leave");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "C":
                        Console.WriteLine("Who do you want to talk to?");
                        string NPC = Console.ReadLine();
                        ChatWithNPC(NPC);
                        break;
                    case "A":
                        AccuseTheMurderer();
                        break;
                    case "L":
                        return;
                    default: break;
                }
            }

            Epilogue epilogue = new(SaveData);
            epilogue.AnnounceNewMayor(SaveData.AccusedMurderer);
        }

        void AccuseTheMurderer()
        {
            Epilogue epilogue = new(SaveData);

            Console.WriteLine("\nEveryone has gathered around you now.");
            Console.WriteLine("Gus > How's your investigation going, Detective?");
            Console.WriteLine("Sam > Do you know who did it?");
            Console.WriteLine("Leah > It's been a week!");
            Console.WriteLine("Abigail > Come on, tell us!\n");
            Console.WriteLine("You let out a long sigh. You'd better be right about this.");
            Console.WriteLine("Me > Ok, ok. As you all know I've been on this case all week. Someone, one of you here, murdered Mayor Lewis.");

            while (true)
            {
                if (SaveData.MysterySolved == true) return;

                Console.WriteLine("Me > The murderer is...");
                SaveData.AccusedMurderer = Console.ReadLine();
                string[] Townsfolk = { "Abigail", "Alex", "Caroline", "Clint", "Demetrius", "Elliott", "Emily", "Evelyn", "Farmer", SaveData.FarmerName, "George", "Gus", "Harvey", "Haley", "Jodi", "Kent", "Leah", "Linus", "Marlon", "Marnie", "Maru", "Morris", "Pam", "Penny", "Pierre", "Robin", "Sam", "Sebastian", "Shane", "Willy", "Wizard" };

                if (!Townsfolk.Contains(SaveData.AccusedMurderer))
                {
                    Console.WriteLine("Oops - either you spelt it wrong or that person isn't an option. Try again.");
                }
                else
                {
                    SaveData.NPCaccused = true;
                    break;
                }
            }

            if (SaveData.AccusedMurderer == SaveData.TheMurderer)
            {
                SaveData.HotShot = true;
                SaveData.MysterySolved = true;

                switch (SaveData.AccusedMurderer)
                {
                    case "Pierre":
                        epilogue.PierreIsTheMurderer();
                        break;
                    case "Marnie":
                        epilogue.MarnieIsTheMurderer();
                        break;
                    case "Kent":
                        epilogue.KentIsTheMurderer();
                        break;
                }                
            }
            else
            {
                epilogue.PlayerGuessedWrong(SaveData.AccusedMurderer);
            }
            
            
        }

        void ChatWithNPC(string NPC)
        {
            if (NPC == "Krobus")
            {
                Console.WriteLine("Krobus isn't here.");
                return;
            }
            else if (NPC == "Governor")
            {
                Console.WriteLine($"Governor > Ah, you must be Detective {SaveData.PlayerName}. I do hope you solve this case soon.");
            }
            else
            {
                ChooseNPC chooseNPC = new();
                var chatNPC = chooseNPC.ChooseNPCMethod(NPC, SaveData);
                chatNPC.Chat();
            }
        }
    }
}
