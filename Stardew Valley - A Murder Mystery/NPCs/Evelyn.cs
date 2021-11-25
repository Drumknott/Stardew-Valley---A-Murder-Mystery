﻿using System;
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

                var dialogue1 = Console.ReadLine();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("");
                        break;
                    case "G":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("");
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

        }
    }
}
