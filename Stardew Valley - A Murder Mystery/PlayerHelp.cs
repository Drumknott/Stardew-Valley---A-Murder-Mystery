using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    public class PlayerHelp
    {
        public void Help()
        {
            Console.WriteLine("To play, type your commands and hit Enter.");
            Console.WriteLine("Available commands are;");
            Console.WriteLine("Go (Location) > Go to a known location (Locations have one word names i.e. 'Saloon' for Stardrop Saloon or 'Marnies' for Marnie's House");
            Console.WriteLine("Forage > Search the location you're currently in");
            Console.WriteLine("Chat (Person) > Speak with a person in your location");
            //Console.WriteLine("Gift > Give a gift to the person you're talking to");
            Console.WriteLine("Check Inventory");
            Console.WriteLine("Check Casefile");
            Console.WriteLine("Save > Save the game (You may only have one save file)");
            Console.WriteLine("Help > review commands");
            Console.WriteLine("");
            Console.WriteLine("Enter > Continue");
            Console.ReadKey();
        }
    }
}
