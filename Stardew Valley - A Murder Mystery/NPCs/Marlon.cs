using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Marlon : NPC
    {
        private SaveData SaveData { get; set; }

        public Marlon(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Marlon";

                if (SaveData.MarlonCount == 0) //first meeting
                {
                    Console.WriteLine("Marlon > Hey, good afternoon.");
                    SaveData.MarlonCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Marlon > Even with my bad leg, I never miss a town festival."); break;
                        case 1: Console.WriteLine("Marlon > Marnie looks lovely today..."); break;
                        case 2: Console.WriteLine("Marlon > Clint's blades get sharper every year. So do his prices..."); break;
                        case 3: Console.WriteLine("Marlon > Be careful if you go exploring in the mines. It can be dangerous in there."); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        if (SaveData.Flashlight == false)
                        {
                            Console.WriteLine("Marlon > Say, I was clearing out one of my old boxes of junk and I found this flashlight. Would you like it? It might come in handy.");
                            SaveData.Flashlight = true;
                        }
                        else
                        {
                            Console.WriteLine("Me > How are you doing, Marlon? Don't you ever get lonely up here?");
                            Console.WriteLine("Marlon > Folks like me are used to being by themselves. Mind you, I would enjoy some of Miss Marnie's company.");
                        }
                        break;
                    case "G":
                        Console.WriteLine("Me > Would you like this?");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Marlon, can I ask a few questions?");
                        Investigate();
                        break;
                    case "L": SaveData.MarlonCount++;
                        return;
                    default: break;
                }             
            }
        }

        public override void Gift()
        {
            string NPCName = "Marlon";
            var FavGift = Enums.Items.GoatCheese;
            var DislikedGift = Enums.Items.FriedCalamari;
            string LoveGift = $"Oh {SaveData.PlayerName}, this is wonderful. Thank you so much.";
            string HateGift = "This is disgusting. Please take it away.";
            string NeutralGift = "A gift? How lovely.";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            Gift giftMethod = new(SaveData);
            giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
          
        }    

        void Investigate()
        {
            bool Case1 = false;
            bool Case2 = false;      

            Console.WriteLine("Marlon > Fire away.");

            while (true)
            {
                if (Case1 && Case2) return;

                Console.WriteLine("\nW > Where were you the night Lewis was attacked?");
                Console.WriteLine("D > Did you get on well with Mayor Lewis?");
                Console.WriteLine("L > Leave\n");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "W":
                        Console.WriteLine("Marlon > I was here, Detective. The guild stays open late, 'til 10pm usually.");
                        Case1 = true;
                        break;
                    case "D":
                        Console.WriteLine("Marlon > ...Honestly, no. He wasn't a bad mayor, but he never treated Miss Marnie right, and I didn't like that.");
                        Console.WriteLine("Me > What do you mean?");
                        Console.WriteLine("Marlon > Well, Marnie and Lewis were, you know... together. ");
                        Console.WriteLine("Marlon > She didn't want to hide it, but he wouldn't tell folks and wanted to keep it a secret.");
                        Console.WriteLine("Marlon > Like he was ashamed of her. Miss Marnie deserves better than that is all, a lovely lady like her.");
                        SaveData.MarnieAndLewis = true;

                        bool J = false;
                        bool K = false;

                        while (true)
                        {                            
                            if (J && K) break;
                            Console.WriteLine("\nJ > Am I detecting a bit of jealousy here, Marlon?");
                            Console.WriteLine("K > Are you saying you killed Lewis for a chance to be with Marnie?\n");

                            switch (Console.ReadLine().Substring(0, 1).ToUpper())
                            {
                                case "J":
                                    Console.WriteLine("Marlon > I won't deny it, no. Miss Marnie is a wonderful lady and I've had a soft spot for her for many a year now.");
                                    Console.WriteLine("Marlon > She deserves a man what will treat her right.");
                                    SaveData.MarnieAndMarlon = true;
                                    J = true;
                                    break;
                                case "K":
                                    Console.WriteLine("Marlon> Now hold on. I never liked the man, that's true, but that's doesn't mean I'd do that.");
                                    Console.WriteLine("Marlon > I ain't sad about it, but it wasn't me that killed him.");
                                    K = true;
                                    break;
                                default: break;
                            }
                        }
                        Case2 = true;
                        break;                   
                    case "L": return;
                    default: break;
                }
            }
        }
    }
}
