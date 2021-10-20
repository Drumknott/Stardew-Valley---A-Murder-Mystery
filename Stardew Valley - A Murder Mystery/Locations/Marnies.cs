using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Marnies : Location
    {
        private SaveData SaveData { get; set; }
        bool marnieHere { get; set; }
        bool shaneHere { get; set; }

        public Marnies(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Enter()
        {
            Console.WriteLine("You're in Marnie's.");
            if (SaveData.DayCount == 0)
            {
                Console.WriteLine("Marnie is bustling behind the counter of her farm store.");
                marnieHere = true;
            }
            if (SaveData.DayCount == 0)
            {
                Console.WriteLine("Through the doorway you can see Shane in the kitchen.");
                shaneHere = true;
            }
            Console.WriteLine("Who do you want to talk to?");
            if (marnieHere == true) Console.WriteLine("M > Marnie");
            if (shaneHere == true) Console.WriteLine("S > Shane");
            Console.WriteLine("L > Leave");

            var talk = Console.ReadLine();
            switch (talk)
            {
                case "M":
                    Marnie marnie = new(SaveData);
                    marnie.Chat();
                    break;
                case "S":
                    Shane shane = new(SaveData);
                    shane.Chat();
                    break;
                default: break;
            }
            
        }

        public override void Forage()
        {
            Console.WriteLine("You can't forage in here.");
        }        
    }
}
