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
            Console.WriteLine("");
            Console.WriteLine("Places you are able to visit (Type 'Go [Place]');");
            Console.WriteLine("");
            if (SaveData.AdventurersGuild == true) Console.WriteLine("Adventurer's [Guild]");
            if (SaveData.Beach == true) Console.WriteLine("[Beach]");
            if (SaveData.BusStop == true) Console.WriteLine("[Bus] Stop");
            if (SaveData.Cindersap == true) Console.WriteLine("[Cindersap] Forest");
            if (SaveData.CommunityCentre == true) Console.WriteLine("[Community] Centre");
            if (SaveData.DoctorsSurgery == true) Console.WriteLine("[Doctors] Surgery");
            if (SaveData.Farm == true) Console.WriteLine("Stardew [Farm]");
            if (SaveData.GeneralStore == true) Console.WriteLine("[Pierres] General Store");
            if (SaveData.MarniesHouse == true) Console.WriteLine("[Marnies] House");
            if (SaveData.Mine == true) Console.WriteLine("[Mine]");
            if (SaveData.PelicanTown == true) Console.WriteLine("Pelican [Town]");
            if (SaveData.StardropSaloon == true) Console.WriteLine("Stardrop [Saloon]");
        }       
    }
}
