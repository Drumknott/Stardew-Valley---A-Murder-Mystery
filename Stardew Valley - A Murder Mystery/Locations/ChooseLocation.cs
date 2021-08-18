using Stardew_Valley___A_Murder_Mystery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class ChooseLocation
    {
        public Location ChooseLocationMethod(string chosenLocation, SaveData saveData)
        {
            //while (true)
            //{
            //    if (saveData.Farm == true) Console.WriteLine("F > Stardew Farm");
            //    if (saveData.Beach == true) Console.WriteLine("B > Beach");
            //    if (saveData.Mine == true) Console.WriteLine("M > Mine");
            //    if (saveData.CommunityCentre == true) Console.WriteLine("C > Community Centre");
            //    if (saveData.StardropSaloon == true) Console.WriteLine("S > Stardrop Saloon");
            //    if (saveData.DoctorsSurgery == true) Console.WriteLine("D > Doctor's Surgery");
            //    if (saveData.PelicanTown == true) Console.WriteLine("T > Pelican Town");
            //    if (saveData.GeneralStore == true) Console.WriteLine("P > Pierre's General Store");
            //    if (saveData.MarniesHouse == true) Console.Write("A > Marnie's House");
            //    if (saveData.BusStop == true) Console.WriteLine("U > Bus Stop");

            //    Console.WriteLine("");
            //    Console.WriteLine("or");
            //    Console.WriteLine("L > Look Around/Forage/Search Area");
            //    Console.WriteLine("I > Check Inventory");
            //    Console.WriteLine("N > Check Notes");
            //    //Console.WriteLine("V > Save Game");

            //    var ChosenLocation = Console.ReadLine().Substring(0, 1).ToUpper();


            var parsedLocation = (Locations)Enum.Parse(typeof(Locations), chosenLocation);

            Location location;
            switch (parsedLocation)
            {
                case Locations.Farm when saveData.Farm == true: location = new Farm(saveData); break;
                case Locations.Beach when saveData.Beach == true: location = new Beach(saveData); break;
                case Locations.Mine when saveData.Mine == true: location = new Mine(saveData); break;
                case Locations.Community when saveData.CommunityCentre == true: location = new CommunityCentre(saveData); break;
                case Locations.Saloon when saveData.StardropSaloon == true: location = new StardropSaloon(saveData); break;
                case Locations.Doctors when saveData.DoctorsSurgery == true: location = new DoctorsSurgery(saveData); break;
                case Locations.Town when saveData.PelicanTown == true: location = new PelicanTown(saveData); break;
                case Locations.Pierres when saveData.GeneralStore == true: location = new GeneralStore(saveData); break;
                case Locations.Marnies when saveData.MarniesHouse == true: location = new Marnies(saveData); break;
                case Locations.Bus when saveData.BusStop == true: location = new BusStop(saveData); break;
                case Locations.Guild when saveData.AdventurersGuild == true: location = new AdventurersGuild(saveData); break;

               
                default:
                    throw new Exception("Oops, something went wrong. Try that again.");
            }

            saveData.LastVisited = chosenLocation;
            return location;
        }
    }    
}

