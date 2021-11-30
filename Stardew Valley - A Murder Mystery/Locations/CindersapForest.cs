using Stardew_Valley___A_Murder_Mystery.Enums;
using Stardew_Valley___A_Murder_Mystery.Locations;
using Stardew_Valley___A_Murder_Mystery.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class CindersapForest : Location
    {
        private SaveData SaveData { get; set; }
        private List<Items> ForagableItems = new[] { Items.Amaranth, Items.BatteryPack, Items.BeanHotpot, Items.Beer, Items.Bread, Items.ChocolateCake, Items.Clay, Items.Cloth, Items.Coffee, Items.Coleslaw, Items.CompleteBreakfast, Items.Corn, Items.CrabCakes, Items.Daffodil, Items.FarmersLunch, Items.FishTaco, Items.FriedCalamari, Items.GoatCheese, Items.Holly, Items.Honey, Items.Horseradish, Items.JojaCola, Items.Leek, Items.MapleBar, Items.RedMushroom, Items.Risotto, Items.VoidEgg }.ToList();

        public CindersapForest(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            Console.WriteLine("You are in Cindersap Forest.\n");

            switch (SaveData.DayCount)
            {
                case 0:
                    Console.WriteLine("Haley is taking photos down by the river");
                    SaveData.npc1 = "Haley";
                    break;
                case 1:
                    Console.WriteLine("The forest is lovely and peaceful. You don't see anyone here.");
                    break;
                case 2:
                case 3:
                    Console.WriteLine("Leah is outside her house, drawing in a sketchbook.");
                    SaveData.npc1 = "Leah";
                    break;
                case 4:
                case 6:
                    Console.WriteLine("There's a travelling lady waving at you from a cute little caravan. It's pulled by a... pig?");
                    SaveData.npc1 = "TravellingLady";
                    break;
                case 5:
                    Console.WriteLine("Willy and the Wizard are up to THINGS"); // totally sus dark ritual to yoba
                    SaveData.npc1 = "Willy";
                    SaveData.npc2 = "Wizard";
                    break;
                default: break;
            }          
        }

        public void Explore()
        {
            Console.WriteLine("\nE > Explore the Forest");
            if (SaveData.npc1 == "TravellingLady") Console.WriteLine("T > Speak to the travelling lady");
            Console.WriteLine("G > Go back");

            switch (Console.ReadLine().Substring(0, 1).ToUpper())
            {
                case "E":
                    ExploreCindersap();
                    break;
                case "T" when (SaveData.npc1 == "TravellingLady"):
                    TravellingLady travellingLady = new(SaveData);
                    travellingLady.Chat();
                    break;
                case "G":
                    return;
                default: break;
            }
        }

        public override void Forage()
        {
            var random = new Random();
            var Index = random.Next(0, ForagableItems.Count - 1);
            var randomItem = ForagableItems[Index];

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
            Console.WriteLine("This really is a lovely forest. Do you want to explore it further?\n");
            Explore();            
        }

        private static void RandomForageDialogue(Enums.Items randomItem)
        {
            Random dialogue = new();
            int random = dialogue.Next(0, 2);

            switch (random)
            {
                case 0: Console.WriteLine("You have found a " + randomItem); break;
                case 1: Console.WriteLine("You spot a " + randomItem + " half hidden under a bush."); break;
                case 2: Console.WriteLine("After searching for a few minutes you find a " + randomItem +" behind a tree."); break;
                default: break;
            }
        }

        void ExploreCindersap()
        {
            WizardsTower wizardsTower = new WizardsTower(SaveData);
            HatMausHaus hatMausHaus = new HatMausHaus(SaveData);

            Console.WriteLine("The forest is beautiful. There's a slight breeze, and you can hear birds singing all around.");
            Console.WriteLine("There's a lake with a fishing pier to the west, with that mysterious tower further behind it.");
            Console.WriteLine("A river winds its way south, with a path alongside it.\n");
            Console.WriteLine("Where would you like to go?\n");
            Console.WriteLine("W > West\nS > South\nG > Go back");

            switch (Console.ReadLine().Substring(0, 1).ToUpper())
            {
                case "W":
                    Console.WriteLine("You wander around the lake and find yourself heading towards the tower.");
                    Console.WriteLine("There's smoke coming from the chimney - someone must be home. Tentatively you knock on the door and go in.\n");
                    wizardsTower.Enter();
                    break;
                case "S":
                    Console.WriteLine("You stroll along the riverbank for a while. After a few minutes you come to a wooden bridge, which you decide to cross.");
                    Console.WriteLine("Other the other side you can see what looks like an abandoned house hiden by some trees.");
                    Console.WriteLine("You decide to go in for a closer look.\n");
                    hatMausHaus.Enter();
                    break;
                case "G":
                    return;
                default: break;
            }
        }       
    }
}
