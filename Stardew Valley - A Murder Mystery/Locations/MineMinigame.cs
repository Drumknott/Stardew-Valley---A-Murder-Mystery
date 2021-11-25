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
                SaveData.MyInventory[Enums.Items.LewisStatue] = 0;

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
                    else if (SaveData.MineDemetrius == false && SaveData.levelCount >3)
                    {
                        DemetriusEncounter();
                    }

                    Console.WriteLine($"\nMine Level {SaveData.levelCount}");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("F > Forage");
                    if (SaveData.Monster == false) Console.WriteLine("D > Go Deeper");
                    if (SaveData.Monster == true) Console.WriteLine("M > Fight the monster");
                    Console.WriteLine("L > Leave the mine\n");

                    switch (Console.ReadLine())
                    {
                        case "F":
                            if (SaveData.Monster == true)
                            {
                                Console.WriteLine("Are you sure? Maybe you should make sure you're safe first.");
                                break;
                            }
                            else if (SaveData.levelCount > 4 && SaveData.MyInventory[Enums.Items.LewisStatue] == 0)
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
                            if (SaveData.levelCount == 5)
                            {
                                Console.WriteLine("You see something glinting in the torchlight.\n");
                            }
                            break;
                        case "M":
                            Random combat = new();
                            int description = combat.Next(0, 2);
                            switch (description)
                            {
                                case 0:
                                    Console.WriteLine($"You swing the flashlight at the {SaveData.MonsterType} and you feel it connect. The creature vanishes into the darkness.\nYou're safe for now.");
                                    SaveData.Monster = false;
                                    break;
                                case 1:
                                    Console.WriteLine($"You can make out the opening down to the next level of the mine between you and the {SaveData.MonsterType}");
                                    Console.WriteLine($"You dive for the ladder and escape before the {SaveData.MonsterType} can get you.");
                                    DescentDescription();
                                    SaveData.levelCount++;
                                    SaveData.Monster = false;
                                    break;
                                case 2:
                                    Console.WriteLine("You flail at the creature but without success. You feel it latch onto you, and everything goes dark...");
                                    DayManager time = new(SaveData);
                                    time.PassedOut();
                                    return;
                                default: break;
                            }
                                break;
                        case "L":
                            Console.WriteLine("You escape up the ladder as fast as you can. It's such a relief to see outside again.");
                            return;
                        default: break;
                    }
                }
            }
        }

        private void DemetriusEncounter()
        {
            Console.WriteLine("You turn to suddenly find yourself face to face with Demetrius, and nearly drop your flashlight as you jump.");
            Console.WriteLine("Demetrius > Detective! Fancy meeting you here! Are you mushroom hunting too?");
            Console.WriteLine("F > You frightened me!\nM > ...Mushrooms?\nH > I'm hunting monsters\n");

            switch (Console.ReadLine())
            {
                case "F":
                    Console.WriteLine("Me > Oh my god Demetrius you scared me half to death. I... wasn't expecting you to be down here.");
                    Console.WriteLine($"Demetrius > Not many do come down here, but it's a great place to find mushrooms. \nFarmer {SaveData.FarmerName} has a little cave on the farm that grows good ones too, if you're interested.");
                    break;
                case "M":
                    Console.WriteLine("Me > Mushrooms?\nDemetrius > Oh yes, they love dark, damp places. I find some pretty rare species down here sometimes.");
                    break;
                case "H":
                    Console.WriteLine("Me > Did you hear that... squelching... noise a little while ago?");
                    Console.WriteLine("Demetrius > Oh, it was probably just mud. Old Marlon loves to talk about monsters down here, but I've never seen any!");
                    break;
                default: break;
            }
            SaveData.MineDemetrius = true;
            Console.WriteLine("Me > Well, good luck with your mushroom hunting, Demetrius. I'll see you later.");
        }

        private void DescentDescription()
        {
            Random travel = new();
            int description = travel.Next(0, 5);
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
                    if (SaveData.levelCount > 2)
                    {
                        SaveData.Monster = true;
                    }
                    SaveData.MonsterType = "bat";
                    break;
                case 5:
                    Console.WriteLine("\nA sickly green slime pulsates gently. You can see the remains of the last person it met floating gently inside it's gelatinous body.\n");
                    if (SaveData.levelCount > 3)
                    {
                        SaveData.Monster = true;
                    }
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
