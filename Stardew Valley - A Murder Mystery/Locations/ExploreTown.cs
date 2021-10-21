using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class ExploreTown : Location
    {
        private SaveData SaveData { get; set; }

        public ExploreTown(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            Console.WriteLine("");
            Console.WriteLine("You are in the town square. To the north, you can see a Doctor's Surgery next to a general store called Pierre's.");
            SaveData.DoctorsSurgery = true;
            SaveData.GeneralStore = true;
            Console.WriteLine("A path next to Pierre's leads further north. To the east is a tavern, a small graveyard and a couple of houses and a trailer.");
            Console.WriteLine("Beyond the tavern is a bridge leading further east.");
            SaveData.StardropSaloon = true;
            Console.WriteLine("To the south are some more houses and a path that looks like it heads towards the beach.");
            Console.WriteLine("A path in the south west leads towards the forest.");
            Console.WriteLine("");
            Console.WriteLine("[Doctors] Surgery added to location list");
            Console.WriteLine("[Pierres] General Store added to location list");
            Console.WriteLine("Stardrop [Saloon] added to location list");

            while (SaveData.TownFirstVisit == false)
            {
                if (SaveData.ExploredNorth == true && SaveData.ExploredSouth == true && SaveData.ExploredEast == true && SaveData.ExploredWest == true)
                {
                    SaveData.TownFirstVisit = true;
                    break;
                }
                Console.WriteLine("Where would you like to explore?");

                if (SaveData.ExploredNorth == false) Console.WriteLine("N > North");
                if (SaveData.ExploredSouth == false) Console.WriteLine("S > South");
                if (SaveData.ExploredEast == false) Console.WriteLine("E > East");
                if (SaveData.ExploredWest == false) Console.WriteLine("W > South West");
                Console.WriteLine("V > Visit one of the town buildings");

                var Choice = Console.ReadLine().Substring(0, 1).ToUpper();
                if (Choice == "V") break;

                switch (Choice)
                {
                    case "N":
                        Console.WriteLine("North of the town square is an old building that looks like it's been abandoned: the Community Centre.");
                        Console.WriteLine("Next to the Community Centre is a small playground. The path continues further north.");
                        SaveData.CommunityCentre = true;
                        Console.WriteLine("");
                        Console.WriteLine("[Community] Centre added to location list");
                        Console.WriteLine("");
                        Console.WriteLine("N > Explore further up the path.");
                        Console.WriteLine("R > Return to the town square.");

                        var UserInput = Console.ReadLine();
                        if (UserInput == "N")
                        {
                            ExploreNorth exploreNorth = new(SaveData);
                            exploreNorth.Enter();
                            SaveData.ExploredNorth = true;
                            break;
                        }
                        else
                        {
                            SaveData.ExploredNorth = true;
                            break;
                        }
                        
                    case "S":
                        Console.WriteLine("As you head south you pass over a stone bridge. Past that, you find yourself on a sandy beach. There's a small Cabin here,");
                        Console.WriteLine("and a fishing pier with a small hut built on it.");
                        Console.WriteLine("");
                        Beach enter = new(SaveData);
                        enter.Enter();
                        SaveData.ExploredSouth = true;
                        break;
                    case "E":
                        Console.WriteLine("Over the small bridge to the east is a small museum/library, with a blacksmith shop behind it. ");
                        Console.WriteLine("A short way to the north you ca see a Joja Mart.");
                        SaveData.JojaMart = true;
                        SaveData.Blacksmith = true;
                        SaveData.Museum = true;
                        Console.WriteLine("");
                        Console.WriteLine("[Museum] added to location list");
                        Console.WriteLine("[Blacksmith] added to location list");
                        Console.WriteLine("[Joja] Mart added to location list");
                        SaveData.ExploredEast = true;
                        break;
                    case "W":
                        Console.WriteLine("You head to the west, past a couple of houses and then along a forest path.");
                        Console.WriteLine("On your right you see a Farmstead. On your left, a small cottage with a nice garden. Ahead of you is a forest, with a tower in the distance.");
                        SaveData.MarniesHouse = true;
                        SaveData.LeahsHouse = true;
                        Console.WriteLine("[Marnies] added to location list");
                        Console.WriteLine("[Leahs] added to location list");
                        Console.WriteLine("[Cindersap] Forest added to location list");
                        CindersapForest travel = new(SaveData);
                        travel.Enter();
                        SaveData.ExploredWest = true;
                        break;
                    default: break;
                }
            }
        }

        public override void Forage()
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
                case 1: Console.WriteLine("You spot a " + randomItem + " half buried in the flowerbed."); break;
                case 2: Console.WriteLine("After searching for a few minutes you find a " + randomItem); break;
                default: break;
            }
        }
    }
}
