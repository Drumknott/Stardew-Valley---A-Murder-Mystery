using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class PelicanTown : Location
    {
        private SaveData SaveData { get; set; }

        public PelicanTown(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            if (SaveData.TownFirstVisit == false)
            {
                ExploreTown exploreTown = new(SaveData);
                exploreTown.Enter();               
            }

            if (SaveData.DayCount >0)
            {
                Console.WriteLine("You are in the town square. Posters have been put up on every available surface: VOTE KENT TO SERVE THE COMMUNITY.");
                Console.WriteLine("Over these, rival posters have been stuck haphazardly: Vote Pierre, Joja OUT! And lastly, covering an entire wall of the Stardrop Saloon,");
                Console.WriteLine("is one giant billboard in Joja blue: For Modern Progress vote for Mayor Morris");
                Console.WriteLine("These people don't waste any time.");
            }                       
        }

        public override void Forage()
        {

        }
    }
}
