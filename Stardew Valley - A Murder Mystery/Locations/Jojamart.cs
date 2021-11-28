using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class Jojamart : Location
    {
        private SaveData SaveData { get; set; }

        public Jojamart(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {
            Console.WriteLine("You are in the Jojamart.\n");

            switch (SaveData.DayCount)
            {
                case 0:
                    Console.WriteLine("Morris is behind the Customer Service desk. Shane is stocking shelves, and Sam is paying for a pack of Joja cola.");
                    SaveData.npc1 = "Morris";
                    SaveData.npc2 = "Shane";
                    SaveData.npc3 = "Sam";
                    break;
                case 1:
                case 3:
                    Console.WriteLine("Shane is moving a crate of groceries. Morris is behind the Customer Service desk as usual.");
                    SaveData.npc1 = "Morris";
                    SaveData.npc2 = "Shane";
                    break;
                case 2:
                    Console.WriteLine("Morris and Shane are talking together. \nSam is buying more Joja cola, while Jodi does her weekly shop.");
                    SaveData.npc1 = "Morris";
                    SaveData.npc2 = "Shane";
                    SaveData.npc3 = "Sam";
                    SaveData.npc4 = "Jodi";
                    break;
                case 4:
                    Console.WriteLine("Morris is greeting everyone at the door, wearing a large badge that says 'Mayor Morris'.\nJodi is here buying some groceries.");
                    SaveData.npc1 = "Morris";
                    SaveData.npc2 = "Jodi";
                    break;
                case 5:
                    Console.WriteLine("The store is empty apart from Morris, who is organising campaign materials.");
                    SaveData.npc1 = "Morris";
                    break;
                case 6:
                    Console.WriteLine("The Jojamart is closed. There's a sign on the door; 'Closed for Election Day'");
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
