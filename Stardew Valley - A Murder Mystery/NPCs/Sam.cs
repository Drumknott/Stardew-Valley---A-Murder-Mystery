﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Sam : NPC
    {
        private SaveData SaveData { get; set; }

        public Sam(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            { 
                SaveData.LastChat = "Sam";

                if (SaveData.SamCount == 0) //first meeting
                {
                    Console.WriteLine("Sam > Hey, I’m Sam. Good to meet you.");
                    SaveData.SamCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 8);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Sam > Ugh, I stepped in something gross earlier. And I just bought these shoes."); break;
                        case 1:
                            Console.WriteLine("Sam > My Dad was a soldier, fighting against the Gotoro Empire. That's why he's been away.");
                            Console.WriteLine("He's back now though. I'm glad, I've heard some terrible things about the Gotoro Empire...");
                            break;
                        case 2: Console.WriteLine("Sam > Hmm. I just remembered that I was supposed to do something... But I forgot. This happens to me all the time."); break;
                        case 3: Console.WriteLine("Sam > Hey, how's it going? Last night I practiced guitar for 4 hours straight. My fingers hurt like crazy.Bye, I've got something to do."); break;
                        case 4: Console.WriteLine("Sam > Oh, it's a nice day, isn't it?"); break;
                        case 5: Console.WriteLine("Sam > Hey, how's it going? I'm hungry. See you later.”"); break;
                        case 6:
                            Console.WriteLine("Sam > Oh! I just remembered I'm supposed to call my Grandma. Okay, I'm going to put this rubber band on my wrist so I don't forget.");
                            Console.WriteLine("I have to make little reminders for myself or else I'll totally forget to do things.");
                            break;
                        case 7: Console.WriteLine("Sam > Hey... something smells good, like pizza."); break;
                        case 8: Console.WriteLine("Sam > Did you watch the game last night? Or wait, do you even have a TV set...?"); break;
                        default: break;
                    }
                }

                ChooseNPC chat = new();
                chat.ChatOptions();

                var dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();

                switch (dialogue1)
                {
                    case "C":
                        Console.WriteLine("");
                        SaveData.SamFriendship++;
                        break;
                    case "G":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("");
                        Investigate();
                        break;
                    case "L": SaveData.SamCount++; 
                        return;
                    default: break;
                }             
            }
        }

        public override void Gift()
        {
            string NPCName = "Sam";
            var FavGift = Enums.Items.MapleBar;
            var DislikedGift = Enums.Items.Coal;
            string LoveGift = "Aw, yea! This is my absolute favorite!";
            string HateGift = "You really don't get it, huh?";
            string NeutralGift = "You got that for me? Thanks";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            Gift giftMethod = new(SaveData);
            int friendshipChange = giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
            SaveData.SamFriendship += friendshipChange;
        }

        void Investigate()
        {
            //where was kent

            bool Case1 = false;
            bool Case2 = false;
            bool Case3 = false;
            bool Case4 = false;

            Console.WriteLine("");

            while (true)
            {
                if (Case1 && Case2 && Case3 && Case4) return;

                Console.WriteLine("\nW > Where were you on Friday night?");
                Console.WriteLine("D > Did you like Mayor Lewis?");
                if (SaveData.WhereWasKent) Console.WriteLine("S > Was Kent at the saloon that night?");
                if (SaveData.podcast) Console.WriteLine("P > Sebastian says you're helping him with a murder podcast?");
                Console.WriteLine("L > Leave\n");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "W":
                        Console.WriteLine("Sam > I was hanging at the saloon with Seb and Abby. Got a few rounds of Junimo Kart in. It was a good night!");
                        Console.WriteLine("Sam > Oh, well, I mean it was a good night for me, not-");
                        Console.WriteLine("Sam > It's ok Sam, I know what you meant.");
                        Case1 = true;
                        break;
                    case "D":
                        Console.WriteLine("Sam > I mean, I didn't really know him that well? I saw him at town festivals and stuff, but that was about it.");
                        Console.WriteLine("Sam > Other than that I only know what my dad used to say about him.");
                        Console.WriteLine("Me > Like what?");
                        Console.WriteLine("Sam > Like, he was a useless waste of space and we need a new mayor who will actually do stuff.");
                        Console.WriteLine("Sam > I guess he's going to get his wish...");
                        Case2 = true;
                        break;
                    case "S" when (SaveData.WhereWasKent):
                        if (SaveData.TheMurderer == "Kent") Console.WriteLine("Sam > No, I thought he was home with Mom.");                       
                        else Console.WriteLine("Sam > Yeah he was chatting to Willy I think.");
                        Case3 = true;
                        break;
                    case "P" when (SaveData.podcast):
                        Console.WriteLine("Sam > Yeah, it's going to be really cool! I'm doing all the music, audio effects and production.");
                        Console.WriteLine("Sam > You should give it a listen, it#s great.");
                        Case4 = true;
                        break;
                    case "L": return;
                    default: break;
                }
            }
        }
    }
}
