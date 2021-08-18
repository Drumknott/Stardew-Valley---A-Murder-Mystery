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
                Console.WriteLine("");
                Console.WriteLine("You pass a wooden sign that says 'Stardew Farm'. It has a name written underneath, but it's hard to read.");
                Console.WriteLine("You lean in closer. It's the name of the farmer, but their name is obscured by dirt. What does it say?");
                Console.WriteLine("Farmer ____________");
                SaveData.FarmerName = Console.ReadLine();
                Console.WriteLine("As you carry on along the path you see a pretty farmhouse with a barn, silo and a greenhouse behind it");
                Console.WriteLine("A farmer is feeding chickens in a small yard, and waves when they see you.");
                Farmer farmer = new(SaveData);
                farmer.Chat();
                SaveData.FarmFirstVisit = true;
            }

            Console.WriteLine("");
        }

        public override void Forage()
        {
            Random forage = new();
            int random = forage.Next(0, 2);
            switch (random)
            {
                case 0:
                    Console.WriteLine("You find some wild Horseradish growing outside the Cabin.");
                    SaveData.MyInventory.TryGetValue(Enums.Items.Horseradish, out var horseradishCount);
                    horseradishCount++;
                    SaveData.MyInventory[Enums.Items.Horseradish] = horseradishCount;
                    break;
                case 1:
                    Console.WriteLine("There are some leeks growing by the duck pond.");
                    SaveData.MyInventory.TryGetValue(Enums.Items.Leek, out var leekCount);
                    leekCount++;
                    SaveData.MyInventory[Enums.Items.Leek] = leekCount;
                    break;


            }
        }
    }
}
