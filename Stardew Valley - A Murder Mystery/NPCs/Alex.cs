﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Alex : NPC
    {
        private SaveData SaveData { get; set; }

        public Alex(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {
            SaveData.LastChat = "Alex";

            Random dialogue = new();
            int random = dialogue.Next(0, 9);

            switch (random) // generic chat
            {
                case 0: Console.WriteLine("Alex > Did you know I was an all - star quarterback in high school? It's true. See this little star on my jacket here? That proves it."); break;
                case 1: Console.WriteLine("Alex > The air's starting to warm up... I'm feeling pumped."); break;
                case 2: Console.WriteLine("Alex > My arms are really sore, but that's the sign of progress for a guy like me. I must've done a thousand push - ups yesterday."); break;
                case 3: Console.WriteLine("Alex > Hey.What, you wanna talk to me? I'm busy."); break;
                case 4: Console.WriteLine("Alex > Hey, "+SaveData.PlayerName+".That's right, I remember your name."); break;
                case 5: Console.WriteLine("Alex > Hey, "+ SaveData.PlayerName +".How's your day going?"); break;
                case 6: Console.WriteLine("Alex > Hey, "+ SaveData.PlayerName +".I'm glad you stopped by. I'm not ashamed to say that I love my Grandma! Now Grandpa, on the other hand... Just kidding."); break;
                default: break;
            }

        }

        public override void Gift()
        {
            Console.WriteLine("What gift would you like to give Alex?");
            Console.WriteLine("");

            Inventory inventory = new(SaveData);
            inventory.InventoryList();

            var gift = Console.ReadLine();
            {
                if (gift == "Complete Breakfast" && Enums.Items.CompleteBreakfast > 0)
                {
                    Console.WriteLine("Alex > "); // Alex loves
                    SaveData.AlexFriendship += 2;

                    SaveData.MyInventory.TryGetValue(Enums.Items.CompleteBreakfast, out var completebreakfastCount);
                    completebreakfastCount--;
                    SaveData.MyInventory[Enums.Items.CompleteBreakfast] = completebreakfastCount;
                }

                if (gift == "Holly" && Enums.Items.Holly >0)
                {
                    Console.WriteLine("Alex > "); //Alex hates
                    SaveData.AlexFriendship--;

                    SaveData.MyInventory.TryGetValue(Enums.Items.Holly, out var hollyCount);
                    hollyCount--;
                    SaveData.MyInventory[Enums.Items.Holly] = hollyCount;
                }
            }
        }

        void Investigate()
        {

        }
    }
}
