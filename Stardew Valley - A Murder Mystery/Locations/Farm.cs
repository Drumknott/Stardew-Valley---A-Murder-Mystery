using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Farm : Location
    {
        private SaveData SaveData { get; set; }

        public Farm (SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            if (SaveData.FarmFirstVisit == false)
            {
                Console.WriteLine("You pass a wooden sign that says 'Stardew Farm'. It has a name written underneath, but it's hard to read.");
                Console.WriteLine("You lean in closer. It's the name of the farmer, but their name is obscured by dirt. What does it say?");
                Console.WriteLine("Farmer ____________");
                SaveData.FarmerName = Console.ReadLine();
                SaveData.FarmFirstVisit = true;
            }

            Console.WriteLine("");
        }            
    }
}
