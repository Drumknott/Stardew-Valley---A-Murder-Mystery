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
        
        public void IncreaseDayCount()
        {
            
            Console.WriteLine("");
            Console.WriteLine("It's been a busy day. You should go and get some rest.");
            Console.WriteLine("");
            Console.WriteLine("Enter > Continue");
            Console.WriteLine("");
            Console.ReadKey();
            SaveData.DayCount++;
            if (SaveData.DayCount == 1)
            {
                Console.WriteLine("DAY 2");
            }
            if (SaveData.DayCount == 2)
            {
                Console.WriteLine("DAY 3");
            }
            if (SaveData.DayCount == 3)
            {
                Console.WriteLine("DAY 4");
            }
            if (SaveData.DayCount == 4)
            {
                Console.WriteLine("DAY 5");
            }
            if (SaveData.DayCount == 5)
            {
                Console.WriteLine("DAY 6");
            }
            if (SaveData.DayCount == 6)
            {
                Console.WriteLine("DAY 7: Election Day");
            }
            Console.WriteLine("");
            Console.WriteLine("Enter > Continue");
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
