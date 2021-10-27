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
                            Console.WriteLine("Sam > My Dad is a soldier, fighting against the Gotoro Empire. That's why he's not here.");
                            Console.WriteLine("He'll come back someday. I've heard some terrible things about the Gotoro Empire...");
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

                Console.WriteLine("");
                Console.WriteLine(""); //chat
                Console.WriteLine(""); //gift
                Console.WriteLine(""); //investigate
                Console.WriteLine("L > Leave");

                var dialogue1 = Console.ReadLine();

                switch (dialogue1)
                {
                    case "chat":
                        Console.WriteLine("");
                        SaveData.SamFriendship++;
                        break;
                    case "gift":
                        Console.WriteLine("");
                        Gift();
                        break;
                    case "investigate":
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
            Console.WriteLine("What gift would you like to give Sam?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            if (gift.Length == 0)
            {
                return;
            }

            else if (gift == "MapleBar" && Enums.Items.MapleBar > 0)
            {
                Console.WriteLine("Sam > Aw, yea! This is my absolute favorite!"); // NPC loves
                Console.WriteLine(gift + " removed from Inventory.");
                SaveData.SamFriendship += 2;

                SaveData.MyInventory.TryGetValue(Enums.Items.MapleBar, out var mapleBarCount);
                mapleBarCount--;
                SaveData.MyInventory[Enums.Items.MapleBar] = mapleBarCount;
            }

            else if (gift == "Coal" && Enums.Items.Coal > 0)
            {
                Console.WriteLine("Sam > You really don't get it, huh?"); //NPC hates
                Console.WriteLine(gift + " removed from Inventory.");
                SaveData.SamFriendship--;

                SaveData.MyInventory.TryGetValue(Enums.Items.Coal, out var coalCount);
                coalCount--;
                SaveData.MyInventory[Enums.Items.Coal] = coalCount;
            }
            else //neutral
            {
                Console.WriteLine("Sam > You got that for me? Thanks!");
                Console.WriteLine(gift + " removed from Inventory.");
            }
        }

        void Investigate()
        {

        }
    }
}
