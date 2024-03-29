﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Maru : NPC
    {
        private SaveData SaveData { get; set; }

        public Maru(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Maru";

                if (SaveData.MaruCount == 0) //first meeting
                {
                    Console.WriteLine("Maru > Oh! Aren't you the Detective? I'm Maru. I've been looking forward to meeting you!"); 
                    Console.WriteLine("You know, with a small town like this, a new face can really alter the community dynamic. It's exciting!");
                    SaveData.MaruCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 10);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Maru > Whenever I'm struggling with a technical problem, I always take a walk.It's surprising how much a change of scenery can help."); break;
                        case 1: Console.WriteLine("Maru > Have you met my mother? She's the town's carpenter."); break;
                        case 2: Console.WriteLine("Maru > On Tuesdays and Thursdays I work at Harvey's clinic.He says he likes having me around in case his medical equipment goes haywire!"); break;
                        case 3: Console.WriteLine("Maru > I plan on spending a lot of time with my telescope this summer."); break;
                        case 4: Console.WriteLine("Maru > Do you know my Dad, Demetrius? He's a scientist. I have a lot of fun helping him out in the laboratory."); break;
                        case 5: Console.WriteLine("Maru > Hey, sorry if I seem cranky... I'm a little sore from work yesterday. I had to sort patient records for four hours straight!"); break;
                        case 6: Console.WriteLine("Maru > Sometimes my head gets so cluttered with nonsense I can hardly think. Does that ever happen to you? Getting some fresh air usually helps."); break;
                        case 7: Console.WriteLine("Maru > My mother is a carpenter and my dad is a scientist. I guess it makes sense that I'm into building gadgets."); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "chat":
                        Console.WriteLine("Me > What's happening, Maru?");
                        SaveData.MaruFriendship++;
                        break;
                    case "gift":
                        Console.WriteLine("Me > Would you find this useful, Maru?");
                        Gift();
                        break;
                    case "investigate":
                        Console.WriteLine("Me > Do you mind if I ask a few questions as part of my investigation?");
                        Investigate();
                        break;
                    case "L": SaveData.MaruCount++;
                        return;
                    default: break;
                }                
            }
        }
        public override void Gift()
        {
            string NPCName = "Maru";
            var FavGift = Enums.Items.BatteryPack;
            var DislikedGift = Enums.Items.Holly;
            string LoveGift = $"Is that...? Oh wow, {SaveData.PlayerName}! This is spectacular!";
            string HateGift = "Yuck! You thought I would like this?";
            string NeutralGift = "Thanks.";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            Gift giftMethod = new(SaveData);
            int friendshipChange = giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
            SaveData.MaruFriendship += friendshipChange;
        }

        void Investigate()
        {
            bool Case1 = false;
            bool Case2 = false;
            bool Case3 = false;

            Console.WriteLine("Maru > Not at all. Go for it!");

            while (true)
            {
                if (Case1 && Case2 && Case3) return;

                Console.WriteLine("W > Where were you on Friday night?");
                Console.WriteLine("H > How did you get on with Mayor Lewis?");
                if (SaveData.SuspectDemetrius) Console.WriteLine("D > Was Demetrius home last Friday night?");
                Console.WriteLine("L > Leave");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "w":
                        if (SaveData.SuspectDemetrius)
                        {
                            Console.WriteLine("Maru > I had a late night in the lab. I'm working on a project right now that's pretty time sensitive.");
                        }
                        else
                        {
                            Console.WriteLine("Maru > I was just chilling at home. Fridays I like to catch up on my tv shows.");
                        }
                        Case1 = true;
                        break;
                    case "H":
                        Console.WriteLine("Maru > Oh, fine I guess. I didn't really know him that well. I saw him gardening sometimes, he seemed nice.");
                        Case2 = true;
                        break;
                    case "D" when (SaveData.SuspectDemetrius):
                        Console.WriteLine("Maru > Oh, I'm not sure. He wasn't in the lab, but he was probably home.");
                        Case3 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }
    }
}
