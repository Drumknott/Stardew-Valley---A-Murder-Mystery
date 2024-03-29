﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.NPCs
{
    class Demetrius : NPC
    {
        private SaveData SaveData { get; set; }

        public Demetrius(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            while (true)
            {

                SaveData.LastChat = "Demetrius";

                if (SaveData.DemetriusCount == 0) //first meeting
                {
                    Console.WriteLine("Demetrius > Greetings! I'm Demetrius, local scientist and father. Thanks for introducing yourself!");
                    Console.WriteLine("Demetrius > I'm studying the local plants and animals from my home laboratory. Have you met my daughter Maru? She's interested to meet you.");
                    SaveData.DemetriusCount++;
                }

                else
                {
                    Random dialogue = new();
                    int random = dialogue.Next(0, 6);

                    switch (random) //random dialogue
                    {
                        case 0: Console.WriteLine("Demetrius > Maru helps me out in the lab sometimes... She's a good kid."); break;
                        case 1: Console.WriteLine("Demetrius > This valley has a very vibrant and diverse ecosystem. That's one reason I was excited to move here."); break;
                        case 2: Console.WriteLine("Demetrius > There's probably a lot of interesting plants on the farm, huh? Maybe I'll stop by some day and check it out."); break;
                        case 3: Console.WriteLine("Demetrius > Robin has a hot temper. It's better to stay on her good side. Don't tell her I said that."); break;
                        case 4: Console.WriteLine("Demetrius > Let's see... If compounds in the rhizosphere contain sufficient levels of Carbon-13, then... Oh! Sorry. I was pondering some data and I didn't notice you there. Do you need anything?"); break;
                        case 5: Console.WriteLine("Demetrius > It's good to take a break from work every now and then. I guess that's kind of difficult when you're a Detective, though."); break;
                        case 6: Console.WriteLine("Demetrius > Thanks for stopping by. I need to think about something other than legumes for a while. So, what have you been doing lately? That sounds interesting."); break;
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
                            Console.WriteLine("Demetrius > I like to go foraging for mushrooms in the mines sometimes. Here, I've got a spare flashlight if you ever fancy giving it a go.");
                            Console.WriteLine("Gained Flashlight");
                            SaveData.Flashlight = true;
                        }
                        else
                        {
                            Console.WriteLine("Me > How are things, Demetrius?");
                            Console.WriteLine("Demetrius > Good thank you, Detective. I always have plenty of research to keep me busy.");
                        }
                        break;
                    case "G":
                        Console.WriteLine("Me > Is this of any use to you?");
                        Gift();
                        break;
                    case "I":
                        Console.WriteLine("Me > Hi Demetrius. Could I ask you a few questions as part of my investigation?");
                        Investigate();
                        Console.WriteLine("Me > Thanks, Demetrius. I think that answers all my questions for now.");
                        break;
                    case "L": SaveData.DemetriusCount++;
                        return;
                    default: break;
                }
            }
        }

        public override void Gift()
        {
            string NPCName = "Demetrius";
            var FavGift = Enums.Items.BeanHotpot;
            var DislikedGift = Enums.Items.Quartz;
            string LoveGift = "You're giving this to me? This is amazing!";
            string HateGift = "This is disgusting.";
            string NeutralGift = "Thank you! This is a very interesting specimen.";

            Console.WriteLine($"What gift would you like to give {NPCName}?\n");
            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            Gift giftMethod = new(SaveData);
            giftMethod.GiftMethod(NPCName, FavGift, DislikedGift, gift, LoveGift, HateGift, NeutralGift);
        }

        bool caseW;
        bool caseM;
        bool caseS;
        bool caseD;      

        void Investigate() //if Pierre's the murderer, Demetrius is an accomplice
        {
            Console.WriteLine("Demetrius > Of course you can Detective. What can I help you with?");

            while (caseW == false && caseM == false && caseS == false && caseD == false)
            {
                Console.WriteLine("\nW > Where were you on Friday night?");
                Console.WriteLine("M > Was Mayor Lewis well liked around town? Do you know if anyone had a problem with him?");
                if (SaveData.MineDemetrius == true) Console.WriteLine("S > When I spoke to you in the mines you said you go there a lot. Would you say you know them better than most people in town?");
                if (SaveData.MyInventory[Enums.Items.LewisStatue] >0) Console.WriteLine("D > Have you ever seen this statue before, Demetrius?");
                if (SaveData.SuspectDemetrius == true) Console.WriteLine("U > Linus says he saw you go into the mines on Friday night, about midnight. Can you tell me about that?");
                Console.WriteLine("L > Leave\n");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "W":
                        Console.WriteLine("Demetrius > I had a late night in my lab. I've been looking at the mineral content of various mushroom growths, and-");
                        Console.WriteLine("Me > Ok, ok. No need to go into detail. Wow, you really love mushrooms, huh?");
                        Console.WriteLine("Demetrius > They're just fascinating, aren't they!?");
                        caseW = true;
                        break;
                    case "M":
                        Console.WriteLine("Demetrius > He and I disagreed on a few things - I thought we should be doing more to sustain the local ecosystems, but he was all about expanding.");
                        Console.WriteLine("Demetrius > It was never something we fell out over though.");
                        caseM = true;
                        break;
                    case "S":
                        Console.WriteLine("Demetrius > I know the surface levels fairly well, yes. If you're looking for a true expert though I'd recommend Marlon or maybe Linus.");
                        caseS = true;
                        break;
                    case "D" when (SaveData.MyInventory[Enums.Items.LewisStatue] > 0):
                        if (SaveData.TheMurderer == "Pierre")
                        {
                            Console.WriteLine("Demetrius looks nervous.\nDemetrius > No, er... no. Never seen it before. What are those markings, it that rust...?");
                            Console.WriteLine("Me > You're the scientist, Demetrius. Does that look like rust?");
                            Console.WriteLine("Demetrius > ...No.\nMe > What does it look like?\nDemetrius > Blood. You think this is the murder weapon!?");
                            Console.WriteLine("Me > Did I say that? I just asked if you've ever seen it before...");
                            Console.WriteLine("Demetrius > *sigh*\nMe > Out with it. When have you seen this statue?");
                            Console.WriteLine("Demetrius > I... I hid it. I threw it into the mine on Friday night. I didn't kill Lewis though, I swear!");
                            Console.WriteLine("Me > Well you'd better have a good explanation. Who did? How did you end up with the statue? And why did you hide it?");
                            Console.WriteLine("Demetrius > ...Pierre asked me to hide it. He blackmailed me.");
                            SaveData.Blackmail = true;
                        }
                        else
                        {
                            Console.WriteLine("Demetrius > Let's have a look. Hmm, no. This must have been expensive though, the gold content is very high. What does it weigh? I can calculate the exact-");
                            Console.WriteLine("Me > No, thank you Demetrius. I think you've answered my question there.");
                        }
                        caseD = true;
                        break;
                    case "U":
                        Console.WriteLine("Demetrius > I, uh, certain mushrooms only bloom at night, so I-");
                        Console.WriteLine("Me > Demetrius. Come on.");
                        Console.WriteLine("I was helping a friend. That's all I'll say.");
                        break;
                    case "L":                       
                        break;
                    default: break;
                }                
            }
        }
    }
}
