﻿using Stardew_Valley___A_Murder_Mystery.Enums;
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

