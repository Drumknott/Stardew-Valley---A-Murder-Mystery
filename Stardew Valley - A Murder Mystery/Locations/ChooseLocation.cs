using Stardew_Valley___A_Murder_Mystery.Enums;
using Stardew_Valley___A_Murder_Mystery.Locations;
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
            var parsedLocation = (Enums.Locations)Enum.Parse(typeof(Enums.Locations), chosenLocation);

            Location location;
            switch (parsedLocation)
            {
                case Enums.Locations.Guild when saveData.AdventurersGuild == true: location = new AdventurersGuild(saveData); break;
                case Enums.Locations.Bus when saveData.BusStop == true: location = new BusStop(saveData); break;
                case Enums.Locations.Beach when saveData.Beach == true: location = new Beach(saveData); break;
                case Enums.Locations.Community when saveData.CommunityCentre == true: location = new CommunityCentre(saveData); break;
                case Enums.Locations.Evelyns when saveData.EvelynGeorgeAlexsHouse == true: location = new EvelynGeorgeAlexsHouse(saveData); break;
                case Enums.Locations.Farm when saveData.Farm == true: location = new Farm(saveData); break;
                case Enums.Locations.Georges when saveData.EvelynGeorgeAlexsHouse == true: location = new EvelynGeorgeAlexsHouse(saveData); break;
                case Enums.Locations.Mine when saveData.Mine == true: location = new Mine(saveData); break;
                case Enums.Locations.Saloon when saveData.StardropSaloon == true: location = new StardropSaloon(saveData); break;
                case Enums.Locations.Doctors when saveData.DoctorsSurgery == true: location = new DoctorsSurgery(saveData); break;
                case Enums.Locations.Town when saveData.PelicanTown == true: location = new PelicanTown(saveData); break;
                case Enums.Locations.Pierres when saveData.GeneralStore == true: location = new GeneralStore(saveData); break;
                case Enums.Locations.Marnies when saveData.MarniesHouse == true: location = new Marnies(saveData); break;
                case Enums.Locations.Abigails when saveData.GeneralStore == true: location = new GeneralStore(saveData); break;
                case Enums.Locations.Carolines when saveData.GeneralStore == true: location = new GeneralStore(saveData); break;
                case Enums.Locations.Blacksmith when saveData.Blacksmith == true: location = new Blacksmith(saveData); break;
                case Enums.Locations.Cabin when saveData.Cabin == true: location = new Cabin(saveData); break;
                case Enums.Locations.Cindersap when saveData.Cindersap == true: location = new CindersapForest(saveData); break;
                case Enums.Locations.Joja when saveData.JojaMart == true: location = new Jojamart(saveData); break;
                case Enums.Locations.Graveyard when saveData.Graveyard == true: location = new Graveyard(saveData); break;
                case Enums.Locations.Tower when saveData.WizardsTower == true: location = new WizardsTower(saveData); break;
                case Enums.Locations.Mayors when saveData.MayorsHouse == true: location = new MayorsHouse(saveData); break;
                case Enums.Locations.Hat when saveData.HatMausHaus == true: location = new HatMausHaus(saveData); break;
                case Enums.Locations.Leahs when saveData.LeahsHouse == true: location = new LeahsHouse(saveData); break;
                case Enums.Locations.North when saveData.ExploredNorth == true: location = new NorthOfTown(saveData); break;
                case Enums.Locations.Emilys when saveData.EmilysHouse == true: location = new HaleyEmilysHouse(saveData); break;
                case Enums.Locations.Haleys when saveData.EmilysHouse == true: location = new HaleyEmilysHouse(saveData); break;
                case Enums.Locations.Sewers when saveData.Sewers == true: location = new Sewers(saveData); break;
                case Enums.Locations.Museum when saveData.Museum == true: location = new Museum(saveData); break;
                case Enums.Locations.Georges when saveData.GeorgesHouse == true: location = new EvelynGeorgeAlexsHouse(saveData); break;
                case Enums.Locations.Evelyns when saveData.GeorgesHouse == true: location = new EvelynGeorgeAlexsHouse(saveData); break;
                case Enums.Locations.Alexs when saveData.GeorgesHouse == true: location = new EvelynGeorgeAlexsHouse(saveData); break;
                case Enums.Locations.Jodis when saveData.JodisHouse == true: location = new JodiKentSamsHouse(saveData); break;
                case Enums.Locations.Kents when saveData.JodisHouse == true: location = new JodiKentSamsHouse(saveData); break;
                case Enums.Locations.Sams when saveData.JodisHouse == true: location = new JodiKentSamsHouse(saveData); break;
                case Enums.Locations.Robins when saveData.Robins == true: location = new RobinDemetriusSebastianMarusHouse(saveData); break;
                case Enums.Locations.Demetrius when saveData.Robins == true: location = new RobinDemetriusSebastianMarusHouse(saveData); break;
                case Enums.Locations.Sebastians when saveData.Robins == true: location = new RobinDemetriusSebastianMarusHouse(saveData); break;
                case Enums.Locations.Marus when saveData.Robins == true: location = new RobinDemetriusSebastianMarusHouse(saveData); break;

                default:
                    throw new Exception("Oops, something went wrong. Try that again.");
            }

            saveData.LastVisited = chosenLocation;
            return location;
        }
    }    
}

