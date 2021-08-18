﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class BusStop : Location
    {
        private SaveData SaveData { get; set; }

        public BusStop(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {          
            if (SaveData.FreshOffTheBus == false)
            {
                SaveData.PamCount += 1;
                Console.WriteLine("Pam points.");
                Console.WriteLine("Pam > If you head left there that road will take you into town, or right will take you to Stardew Farm.");
                Console.WriteLine("Pam > Good luck, Detective "+SaveData.PlayerName, ".");
                Console.WriteLine("Pam locks the bus and hurries off.");
                Console.WriteLine("");
                
                SaveData.FreshOffTheBus = true;
                SaveData.BusStop = true;
                SaveData.Farm = true;
                SaveData.PelicanTown = true;
                Console.WriteLine("[BusStop] added to location list");
                Console.WriteLine("[Farm] added to Location list");
                Console.WriteLine("Pelican [Town] added to location list");
            }
        }

        public override void Forage()
        {        
            Console.WriteLine("You find a Red Mushroom hiding under a bush."); 
            SaveData.MyInventory.TryGetValue(Enums.Items.RedMushroom, out var mushroomCount);
            mushroomCount++;
            SaveData.MyInventory[Enums.Items.RedMushroom] = mushroomCount;            
        }
    }
}
