﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Robin : NPC
    {
        private SaveData SaveData { get; set; }

        public Robin(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Robin";

                if (SaveData.RobinCount == 0) //first meeting
                {
                    Console.WriteLine("Robin > Have you met everyone in town yet? That sounds exhausting.");
                    SaveData.RobinCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Robin > Have I told you that I built our house from the ground up? It's definitely been the highlight of my career so far."); break;
                        case 1: Console.WriteLine("Robin > Hey, if you need any materials or blueprints, my shop is the place you're looking for! Plus, your business supports the local economy."); break;
                        case 2: Console.WriteLine($"Robin > Hey there, {SaveData.PlayerName}. I was just daydreaming about some new carpentry projects."); break;
                        case 3: Console.WriteLine("Robin > You're always welcome to visit us, even if you aren't shopping, you know. It can get pretty lonely up here in the mountains."); break;
                        case 4: Console.WriteLine("Robin > You've met my son Sebastian, right? He lives downstairs. He's a little shy, but I'm sure he'll warm up to you if you're nice to him."); break;
                        case 5: Console.WriteLine("Robin > I found an ashtray in Sebastian's room, and it smelled really weird. Should I be worried about this?"); break;
                        case 6:
                            Console.WriteLine("Robin > Sometimes I worry about Sebastian... he doesn't have many friends and doesn't really seem to care about his future very much...");
                            Console.WriteLine("I would talk to him about it but he never opens up to me."); break;
                        case 7: Console.WriteLine("Robin > Our house is in such a beautiful area, don't you think? I love the fresh air of the mountains."); break;
                        case 8:
                            Console.WriteLine("Robin > I hope Demetrius doesn't blow the house up with those science experiments of his.");
                            Console.WriteLine("I'm not even sure what he's working on. I think it has something to do with plants."); break;
                        case 9:
                            Console.WriteLine("Robin > My husband almost set the house on fire last night with his science experiment.");
                            Console.WriteLine("One of his beakers exploded and sent a fireball into the rafters! Thank Yoba I used fire-resistant lacquer when I built the place."); break;
                        case 10: Console.WriteLine($"Robin > Sorry if it smells weird in here, {SaveData.PlayerName}. It's my husband's bizarre science project..."); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("Me > What's up, Robin?");
                        break;
                    case "G":
                        Console.WriteLine("Hey, this is for you.");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Can I interuppt you for a few minutes?");
                        Investigate();
                        break;
                    case "L":
                        SaveData.RobinCount++;
                        return;
                    default: break;
                }               
            }
        }

        public override void Gift()
        {
            string NPCName = "Robin";
            var FavGift = Enums.Items.GoatCheese;
            var DislikedGift = Enums.Items.Holly;
            string LoveGift = "This is for me? Wow, I absolutely love it!!";
            string HateGift = "What the...? This is terrible!";
            string NeutralGift = "Thank you. This might come in handy.";

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

            Console.WriteLine("");

            while (true)
            {
                if (Case1 && Case2 && Case3) return;

                Console.WriteLine("\nW > Where were you on Friday night?");
                Console.WriteLine("D > Did you like Lewis?");
                if (SaveData.SuspectDemetrius) Console.WriteLine("H > Was Demetrius home that night?");
                Console.WriteLine("L > Leave\n");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "W":
                        Console.WriteLine("Robin > I was at the saloon, along with everyone else. Demetrius usually goes too, but he said he had something to do in the lab.");
                        Console.WriteLine("Robin looks annoyed about this.");
                        Case1 = true;
                        break;
                    case "D":
                        Console.WriteLine("Robin > Oh sure. He was nice. Always came to me when there was work that needed doing for the town, for festivals and things like that.");
                        Case2 = true;
                        break;
                    case "H" when (SaveData.SuspectDemetrius):
                        Console.WriteLine("Robin > I mean, he said he was busy in the lab, but honestly I have no idea. Maru was home, she might know?");
                        Console.WriteLine("Me > I'm sorry, have I upset you...?");
                        Console.WriteLine("Robin sighs.");
                        Console.WriteLine("Robin > It's not you Detective. Demetrius just hasn't been spending much time with me lately, and it's starting to get to me.");
                        Console.WriteLine("Robin > I've tried talking to him about it but he insists everything is fine. I'm... I'm worried he's having an affair.");
                        Case3 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }
    }
}
