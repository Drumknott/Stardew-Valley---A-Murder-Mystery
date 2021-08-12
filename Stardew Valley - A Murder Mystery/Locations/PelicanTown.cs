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
                Console.WriteLine(" You are in the town square. To the north, you can see a Doctor's Surgery next to a general store called Pierre's.");
                SaveData.DoctorsSurgery = true;
                SaveData.GeneralStore = true;
                Console.WriteLine("A path next to Pieree's leads further north. To the east is a tavern, a small graveyard and a couple of houses and a trailer.");
                Console.WriteLine("To the south are some more houses and a path that looks like it heads towards the beach.");

                SaveData.TownFirstVisit = true;
            }

            Console.WriteLine("You are in the twon square.");
        }
    }
}
