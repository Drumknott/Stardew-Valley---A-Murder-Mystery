using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class AvailablePlaces
    {
        private SaveData SaveData { get; set; }

        public AvailablePlaces(SaveData saveData)
        {
            SaveData = saveData;
        }
        public void ViewLocations()
        {            
            Console.WriteLine("\nPlaces you are able to visit (Type 'Go [Place]');\n");
            if (SaveData.AdventurersGuild == true) Console.WriteLine("Adventurer's [Guild]");
            if (SaveData.Beach == true) Console.WriteLine("[Beach]");
            if (SaveData.Blacksmith == true) Console.WriteLine("[Blacksmith]");
            if (SaveData.BusStop == true) Console.WriteLine("[Bus] Stop");
            if (SaveData.Cabin == true) Console.WriteLine("[Cabin]");
            if (SaveData.Cindersap == true) Console.WriteLine("[Cindersap] Forest");
            if (SaveData.CommunityCentre == true) Console.WriteLine("[Community] Centre");
            if (SaveData.DoctorsSurgery == true) Console.WriteLine("[Doctors] Surgery");
            if (SaveData.EmilysHouse == true) Console.WriteLine("[Emilys] House (also [Haleys])");
            if (SaveData.EvelynGeorgeAlexsHouse == true) Console.WriteLine("[Georges] House (also [Evelyns] or [Alexs])");
            if (SaveData.Farm == true) Console.WriteLine("Stardew [Farm]");
            if (SaveData.GeneralStore == true) Console.WriteLine("[Pierres] General Store (also [Abigails] or [Carolines])");
            if (SaveData.Graveyard == true) Console.WriteLine("[Graveyard]");
            if (SaveData.JodisHouse) Console.WriteLine("[Jodis] House (also [Kents] or [Sams])");
            if (SaveData.JojaMart == true) Console.WriteLine("[Joja] Mart");
            if (SaveData.LeahsHouse) Console.WriteLine("[Leahs] House");
            if (SaveData.MarniesHouse == true) Console.WriteLine("[Marnies] Ranch");
            if (SaveData.MayorsHouse) Console.WriteLine("[Mayors] House");
            if (SaveData.Mine == true) Console.WriteLine("[Mine]");
            if (SaveData.Museum) Console.WriteLine("[Museum]");
            if (SaveData.ExploredNorth == true) Console.WriteLine("[North] of town");
            if (SaveData.PelicanTown == true) Console.WriteLine("Pelican [Town]");
            if (SaveData.Robins) Console.WriteLine("[Robins] House (also [Demetrius], [Sebastians] or [Marus])");
            if (SaveData.Sewers) Console.WriteLine("[Sewers]");
            if (SaveData.StardropSaloon == true) Console.WriteLine("Stardrop [Saloon]");
            if (SaveData.WizardsTower == true) Console.WriteLine("Wizards [Tower]");
            if (SaveData.HatMausHaus == true) Console.WriteLine("Hat Mouse's [Haus]");


        }         
    }
}
