using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class ExploreNorth : Location
    {
        private SaveData SaveData { get; set; }

        public ExploreNorth(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            Console.WriteLine("Further up the path past the Community Centre you come to a house with a workshop at the side and a telescope on the roof.");
            SaveData.Robins = true;
            Console.WriteLine("To the west is a path that leads to Stardew Farm.");
            Console.WriteLine("To the East is a large lake. On the north shore of the lake you can see a large cave entrance, and a building next to it.");
            Console.WriteLine("On the other side of the lake a bridge leads to a quarry.");
            SaveData.Mine = true;
            SaveData.AdventurersGuild = true;
            SaveData.Quarry = true;
            Console.WriteLine("[Mine] added to location list");
            Console.WriteLine("Adventurer's [Guild] added to location list");
            Console.WriteLine("[Quarry] added to location list");                       
        }

        public override void Forage()
        {

        }
    }
}
