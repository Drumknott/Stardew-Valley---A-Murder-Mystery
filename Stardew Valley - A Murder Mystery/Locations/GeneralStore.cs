using Stardew_Valley___A_Murder_Mystery.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class GeneralStore : Location
    {
        private SaveData SaveData { get; set; }

        public GeneralStore(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            SaveData.LastVisited = "Pierres";

            Console.WriteLine("You are in Pierre's General Store.\n");

            switch (SaveData.DayCount)
            {
                case 0: // Day 1
                    Console.WriteLine("Pierre is behind the counter. Marnie and Leah are browsing the shelves.");
                    Console.WriteLine("To the side of the counter a doorway leads back to Pierre's house.");
                    SaveData.npc1 = "Pierre";
                    SaveData.npc2 = "Marnie";
                    SaveData.npc3 = "Leah";
                    SaveData.npc4 = "Abigail";
                    //Abby is home
                    break;
                case 1: //Day 2
                    //aerobics day
                    Console.WriteLine("Pierre is minding the shop, but there are no customers today.");
                    SaveData.npc1 = "Pierre";
                    Console.WriteLine("The door to the back room is open, and you can hear voices and laughter from inside.\n");                    
                    Console.WriteLine("I > Investigate the back room");
                    Console.WriteLine("S > Stay in the store");
                    var investigate = Console.ReadLine().Substring(0, 1).ToUpper();

                    if (investigate == "I")
                    {
                        //aerobics class
                        SaveData.npc1 = "Caroline";
                        SaveData.npc2 = "Robin";
                        SaveData.npc3 = "Jodi";
                        SaveData.npc4 = "Emily";
                        SaveData.npc5 = "Marnie";
                    }
                    break;
                case 2:
                case 3:
                    Console.WriteLine("Pierre greets you from behind the counter.");
                    SaveData.npc1 = "Pierre";
                    break;                
                case 4:
                    Console.WriteLine("Harvey is here waiting to buy something but there's no sign of Pierre.");
                    SaveData.npc1 = "Harvey";
                    break;
                case 5:
                    Console.WriteLine("Pierre is stocking the shelves while Gus does his weekly shop.");
                    SaveData.npc1 = "Pierre";
                    SaveData.npc2 = "Gus";
                    break;
                case 6:
                    Console.WriteLine("There's no one here, but you can here the noise of the crowd outside.");
                    break;
                default: break;        
            }
        }

        public override void Forage()
        {
            if (SaveData.StealFromPierre != true)
            {
                Console.WriteLine("When Pierre's not looking, you swipe a candy bar off one of the shelves."); //lol

                SaveData.MyInventory.TryGetValue(Enums.Items.MapleBar, out var mapleBarCount);
                mapleBarCount++;
                SaveData.MyInventory[Enums.Items.MapleBar] = mapleBarCount;

                Console.WriteLine("Maple Bar added to Inventory");
                SaveData.StealFromPierre = true;
            }
            else if (SaveData.DayCount == 6)
            {
                Forage_Randomiser randomiser = new(SaveData);
                var randomItem = randomiser.ForageRandomiser();

                Console.WriteLine("There's no one minding the store. You know you shouldn't, but...");
                RandomForageDialogue(randomItem);

                if (SaveData.MyInventory.TryGetValue(randomItem, out var randomItemCount))
                {
                    randomItemCount++;
                }
                else
                {
                    randomItemCount = 1;
                }
                SaveData.MyInventory[randomItem] = randomItemCount;
                Console.WriteLine(randomItem + " added to Inventory");
            }
            else
            {
                Console.WriteLine("Pierre watches you closely.");
                Console.WriteLine("Pierre > Can I help you, Detective?");
                Console.WriteLine("Maybe you shouldn't steal anything else in here.");
            }
        }

        private static void RandomForageDialogue(Enums.Items randomItem)
        {
            Random dialogue = new();
            int random = dialogue.Next(0, 2);

            switch (random)
            {
                case 0: Console.WriteLine("You have found a " + randomItem); break;
                case 1: Console.WriteLine("You spot a " + randomItem + " on one of the shelves."); break;
                case 2: Console.WriteLine("After searching for a few minutes you find a " + randomItem); break;
                default: break;
            }
        }
    }
}
