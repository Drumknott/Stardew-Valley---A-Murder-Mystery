using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class TemplateLocation : Location
    {
        private SaveData SaveData { get; set; }

        public TemplateLocation(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            Console.WriteLine("You are in \n");

            switch (SaveData.DayCount)
            {
                case 0: break;
                case 1: break;
                case 2: break;
                case 3: break;
                case 4: break;
                case 5: break;
                case 6: break;
                default: break;
            }
        }

        public override void Forage()
        {

        }
    }
}
