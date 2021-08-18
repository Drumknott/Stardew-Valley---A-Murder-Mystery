using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Farmer : NPC
    {
        private SaveData SaveData { get; set; }

        public Farmer(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Chat()
        {
            if (SaveData.FarmerCount == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Farmer "+SaveData.FarmerName+" > Hi! Are you the Detective from the City? I'm "+SaveData.FarmerName+".");
                Console.WriteLine("Farmer "+SaveData.FarmerName+" > I've got a cabin ready for you to stay in while you're here. Normally visitors stay at the Stardrop Saloon,");
                Console.WriteLine("\tbut Gus is having the place done up so there isn't any space. I hope that's ok?");
                Console.WriteLine("");
                Console.WriteLine("Y > Yeah that sounds great");
                Console.WriteLine("N > I'm staying on a farm!?");
                Console.WriteLine("I > ...is there another option?");
                SaveData.FarmerCount++;
                var Dialogue1 = Console.ReadLine().Substring(0, 1).ToUpper();
                switch (Dialogue1)
                {
                    case "Y":
                        Console.WriteLine("You > That sounds great, I love the countryside!");
                        Console.WriteLine("Farmer "+SaveData.FarmerName+" > Great! It's just over here");
                        Console.WriteLine(SaveData.FarmerName+" leads you across the farm to a small cabin by a pond. It's nicely furnished with a comfy bed, dresser and a TV.");
                        Console.WriteLine("A perfect place from which to conduct your investigation.");
                        SaveData.Cabin = true;
                        Console.WriteLine("Finally, Farmer "+SaveData.FarmerName+" hands you a package wrapped in foil.");
                        Console.WriteLine("Farmer "+SaveData.FarmerName+" > I thought you might be hungry, so I made you this. Enjoy!");
                        Console.WriteLine("It's a Farmer's Lunch. Smells great!");
                        SaveData.MyInventory.TryGetValue(Enums.Items.FarmersLunch, out var farmerslunchCount);
                        farmerslunchCount++;
                        SaveData.MyInventory[Enums.Items.Leek] = farmerslunchCount;
                        break;                       
                    case "N": 
                        Console.WriteLine("You > Um, I thought I'd be staying in town. I'm not really a country person...");
                        Console.WriteLine("Farmer "+SaveData.FarmerName+" > Oh, well I guess you could ask around the town? I don't know if anyone has a spare room though...");
                        Console.WriteLine("\tHere are the keys though, just in case. You know, if you change your mind.");
                        SaveData.Cabin = true;
                        break;
                    case "I": 
                        Console.WriteLine("You > I don't mean to be rude, but is there another option? I'm not a very... farmy... person");
                        Console.WriteLine("Farmer "+SaveData.FarmerName+" > Um, maybe check with Gus at the Saloon? He might have a room cleared by now, I don't know.");
                        SaveData.Homeless = true;
                        break;
                }                
            }

            if (SaveData.FarmerCount == 1)
            {

            }
        }

        public override void Gift()
        {

        }
    }
}
