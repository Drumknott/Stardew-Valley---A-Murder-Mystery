﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class PlayerHelp
    {
        private SaveData SaveData { get; set; }

        public PlayerHelp(SaveData saveData)
        {
            SaveData = saveData;
        }
        public void Help()
        {
            Console.WriteLine("To play, type your commands and hit Enter.");
            Console.WriteLine("Available commands are;");
            Console.WriteLine("");
            Console.WriteLine("Go [Location] > Go to a known location (Locations have one word names i.e. 'Saloon' for Stardrop Saloon or 'Marnies' for Marnie's House.");
            Console.WriteLine("\tLocations will become available to travel to once you have discovered them.");
            Console.WriteLine("Forage > Search the location you're currently in");
            Console.WriteLine("Chat [Person] > Speak with a person in your location");           
            Console.WriteLine("Check Inventory > View your items");
            Console.WriteLine("Check Casefile > Review the clues you've collected");
            Console.WriteLine("Check Locations > See which locations you can visit");
            Console.WriteLine("Save > Save the game (You may only have one save file)");
            if (SaveData.Unlocked == true)
            {
                Console.WriteLine("Check Achievements > See which achievements you've unlocked");
            }
            if (SaveData.CollectAllTheHats == true)
            {
                Console.WriteLine("Check [HatCollection] > See which hats you've collected!");
            }
            Console.WriteLine("Help > review commands");
            Console.WriteLine("");
            Console.WriteLine("Enter > Continue");
            Console.ReadKey();
        }
    }
}
