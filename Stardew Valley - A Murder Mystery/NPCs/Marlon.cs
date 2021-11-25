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

                var dialogue1 = Console.ReadLine();

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
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("");
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

        }
    }
}
