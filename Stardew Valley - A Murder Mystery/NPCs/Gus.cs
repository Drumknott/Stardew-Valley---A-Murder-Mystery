﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Gus : NPC
    {
        private SaveData SaveData { get; set; }

        public Gus(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {            
            SaveData.LastChat = "Gus";

            if (SaveData.GusCount == 0) //first meeting
            {
                Console.WriteLine("Gus > Well hello there! I'm Gus, chef and owner of the Stardrop Saloon. Stop in if you need any refreshments. I've always got hot coffee and cold beer at the ready.");
                SaveData.GusCount++;
            }

            else
            {
                Random dialogue = new();
                int random = dialogue.Next(0, 6);

                switch (random) //random dialogue
                {
                    case 0: Console.WriteLine("Gus > Yeah, I know a lot about the people living here. That's one of the benefits of being a bartender. Sometimes I hear too much..."); break;
                    case 1: Console.WriteLine("Gus > I sell different dishes each week, so make sure and check in every now and then! You might taste something spectacular. Just let me know if you have any allergies. Okay, see you around."); break;
                    case 2: Console.WriteLine("Gus > Emily's been working here for a while now. I don't know what I'd do without her! I would hate to have to clean all those pots by myself."); break;
                    case 3: Console.WriteLine("Gus > Pam and Clint come into the saloon almost every night. I'd probably go out of business if they stopped coming. So make sure you don't drive them away!"); break;
                    case 4: Console.WriteLine("Gus > Hi there, "+SaveData.PlayerName+". If you're ever thirsty, the Saloon is the place the be."); break;
                    case 5: Console.WriteLine("Gus > Business has been pretty steady thanks to my regular customers."); break;
                    case 6: Console.WriteLine("Gus > I don't actually drink very much myself. I'm mainly doing this to make a living. Although I do enjoy a taste of the Stardew Valley vintage from time to time."); break;
                    default: break;
                }
                //player dialogue options
                Console.WriteLine(""); //chat
                Console.WriteLine(""); //gift
                Console.WriteLine(""); //investigate
                Console.WriteLine("S > I was hoping to buy something from you Gus"); //buy stuff

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
                    case "buy":
                        Console.WriteLine("");
                        Buy();
                        break;
                    default: break;
                }

                SaveData.GusCount++;
            }
        }

        public override void Gift()
        {
            
        }

        void Investigate()
        {

        }

        void Buy()
        {
            //why oh why would I introduce money into a game like this???
        }
    }
}
