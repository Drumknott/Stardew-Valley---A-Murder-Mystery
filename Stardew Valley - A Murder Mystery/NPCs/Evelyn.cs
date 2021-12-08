using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Evelyn : NPC
    {
        private SaveData SaveData { get; set; }

        public Evelyn(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            {
                SaveData.LastChat = "Evelyn";

                if (SaveData.EvelynCount == 0) //first meeting
                {
                    Console.WriteLine("Evelyn > Why, hello and welcome to our little community, dear! You can call me 'Granny' if you like.");
                    SaveData.EvelynCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 7);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Evelyn > Oh my! What a lovely day."); break;
                        case 1: Console.WriteLine("Evelyn > Don't mind my husband, George. He isn't very friendly to strangers. If you get to know him better he'll warm up to you. I'm sure you two could become good friends one day!"); break;
                        case 2: Console.WriteLine("Evelyn > George spends the whole day in front of that darned television set. I wish he'd go outside more. Some fresh air would do him good."); break;
                        case 3: Console.WriteLine("Evelyn > I used to love looking at the clouds, but I have trouble seeing them these days. My eyes just don't work as well as they used to."); break;
                        case 4: Console.WriteLine("Evelyn > It's nice to be so close to the ocean. The sound of the sea makes going to sleep a lot easier. As kids we hunted for seashells after the tide went out. Those were the days..."); break;
                        case 5: Console.WriteLine("Evelyn > I saw the most beautiful family of butterflies sunning themselves in the town garden yesterday."); break;
                        case 6: Console.WriteLine("Evelyn > The good Mayor put me in charge of the town's public gardens, rest his soul."); break;
                        case 7: Console.WriteLine("Evelyn > I've been working on the town flower beds for weeks, so don't step on them!"); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("Me > Hello, Evelyn. Lovely day, isn't it?");
                        break;
                    case "G":
                        Console.WriteLine("Me > I found this and thought of you.");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Me > Do you mind if I ask you a few questions?");
                        Investigate();
                        break;
                    case "L":
                        SaveData.EvelynCount++;
                        return;
                    default: break;
                }
            }               
        }

        public override void Gift()
        {
            string NPCName = "Evelyn";
            var FavGift = Enums.Items.ChocolateCake;
            var DislikedGift = Enums.Items.Clam;
            string LoveGift = "*gasp*... This is absolutely marvelous! You've made an old lady very happy.";
            string HateGift = "...it smells awful.";
            string NeutralGift = "How nice. Thank you, dear.";

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
            bool Case3 = false;

            Console.WriteLine("Evelyn > Of course you can, dear. What is it?");

            while (true)
            {
                if (Case1 && Case2 && Case3) return;

                Console.WriteLine("H > How well did you know Lewis?");
                Console.WriteLine("W > Where were you the night Lewis was attacked?");
                Console.WriteLine("D > Do you know if anyone was angry with him?");
                Console.WriteLine("L > Leave");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "H":
                        Console.WriteLine("Evelyn > Oh, I've known Lewis since he was a boy! Very well behaved child. I taught him how to look after his garden");
                        Case1 = true;
                        break;
                    case "W":
                        Console.WriteLine("Evelyn > I was at home, dear. I'm not one for late nights any more! George and I are usually in bed by nine.");
                        Case2 = true;
                        break;
                    case "D":
                        Console.WriteLine("Evelyn > Angry with him? Oh goodness, why would anyone be angry with him? He always looked out for everyone. No, certainly not.");
                        Case3 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }
    }
}
