using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class MineMinigame
    {
        private SaveData SaveData { get; set; }

        public MineMinigame(SaveData saveData)
        {
            SaveData = saveData;
        }
        
        public void ExploreTheMine()
        {
            if (SaveData.Flashlight == false)
            {
                Console.WriteLine("It's pitch black in that mineshaft. You'd better find some sort of light before you go down there.");
                return;
            }
            else
            {
                Console.WriteLine("You climb carefully down the ladder. It's still dark, but at least you can see well enough to stop yourself from falling over.");
                SaveData.levelCount = 0;
                SaveData.Monster = false;
                
                while (true)
                {
                    if (SaveData.Monster == true)
                    {
                        Console.WriteLine($"The {SaveData.MonsterType} attacks you!");
                        Random combat = new();
                        int description = combat.Next(0, 2);
                        switch (description)
                        {
                            case 0:
                                Console.WriteLine("You manage to dodge out of the way, but it's a close thing.\n");
                                break;
                            case 1:
                                Console.WriteLine($"The {SaveData.MonsterType} latches onto your hand and wont let go! Before you know it everything's going dark...");
                                //passed out method (increase the DayCount)
                                DayManager time = new(SaveData);
                                time.PassedOut();
                                return;
                            case 2:
                                Console.WriteLine($"You bring your flashlight down on the {SaveData.MonsterType}'s head, and it backs away.\nYou're safe for now.");
                                SaveData.Monster = false;
                                break;
                            default: break;
                        }
                    }
                    //else if Demetrius == true, encounter

                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("F > Forage");
                    if (SaveData.Monster == false) Console.WriteLine("D > Go Deeper");
                    if (SaveData.Monster == true) Console.WriteLine("M > Fight the monster");
                    Console.WriteLine("L > Leave the mine");

                    switch (Console.ReadLine())
                    {
                        case "F":
                            if (SaveData.Monster == true)
                            {
                                Console.WriteLine("Are you sure? Maybe you should make sure you're safe first.");
                                break;
                            }
                            else if (SaveData.levelCount > 7 && Enums.Items.LewisStatue == 0)
                            {
                                Console.WriteLine("You fish in the dirt and your fingers find something cold, hard, heavy... and sticky. You hold it up to the light.");
                                Console.WriteLine("It's a statue of Mayor Lewis. It's about a foot tall, and seems to be made of solid gold. It's covered in dried blood.\n");
                                SaveData.MyInventory[Enums.Items.LewisStatue] = 1;
                                Console.WriteLine("Solid Gold Lewis Statue added to Inventory");
                                Console.WriteLine("Evidence added to Casefile\n");
                            }
                            else
                            {
                                Forage();
                            }
                            break;
                        case "D":
                            DescentDescription();
                            SaveData.levelCount++;
                            if (SaveData.levelCount == 8)
                            {
                                Console.WriteLine("You see something glinting in the torchlight.\n");
                            }
                            break;
                        case "M":
                            Console.WriteLine("");
                            break;
                        case "L":
                            Console.WriteLine("You escape up the ladder as fast as you can. It's such a relief to see outside again.");
                            return;
                        default: break;
                    }
                }
            }
        }

        private void DescentDescription()
        {
            Random travel = new();
            int description = travel.Next(0, 3);
            switch (description)
            {
                case 0:
                    Console.WriteLine("\nYou hear something shuffling in the darkness beyond your torchlight\n.");                    
                    break;
                case 1:
                    Console.WriteLine("\nAs you reach the bottom of the ladder you see footprints. Someone has been here recently.\n");
                    break;
                case 2:
                    Console.WriteLine("\nIt occurs to you, not for the first time, that this might be a bad idea.\n");
                    break;
                case 4:
                    Console.WriteLine("\nA giant bat swoops overhead.\n");
                    SaveData.Monster = true;
                    SaveData.MonsterType = "bat";
                    break;
                case 5:
                    Console.WriteLine("\nA sickly green slime pulsates gently. You can see the remains of the last person it met floating gently inside it's gelatinous body.\n");
                    SaveData.Monster = true;
                    SaveData.MonsterType = "slime";
                    break;
                default: break;
            }
        }

        public void Forage()
        {
            Forage_Randomiser randomiser = new(SaveData);
            var randomItem = randomiser.ForageRandomiser();

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

        private static void RandomForageDialogue(Enums.Items randomItem)
        {
            Random dialogue = new();
            int random = dialogue.Next(0, 2);

            switch (random)
            {
                case 0: Console.WriteLine("You have found a " + randomItem); break;
                case 1: Console.WriteLine("You spot a " + randomItem + " half buried in the dirt."); break;
                case 2: Console.WriteLine("After searching for a few minutes you find a " + randomItem); break;
                default: break;
            }
        }
    }
}
