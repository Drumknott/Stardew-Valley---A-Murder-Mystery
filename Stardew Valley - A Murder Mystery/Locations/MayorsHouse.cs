using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class MayorsHouse : Location
    {
        private SaveData SaveData { get; set; }

        public MayorsHouse(SaveData saveData)
        {
            SaveData = saveData;
        }
        bool FirstVisit;
        public override void Enter()
        {
            if (FirstVisit != true)
            {
                Console.WriteLine("Surprisingly, you find that the door to the Mayor's house is unlocked. You go inside.");
                Console.WriteLine("Inside you see a large open plan kitchen/dining room, with a door that presumably leads to the bedroom.\n");
                FirstVisit = true;
            }

            while (true)
            {
                Console.WriteLine("You are in Mayor Lewis' house.\n");
                Console.WriteLine("E > Examine the scene");
                Console.WriteLine("F > Forage");
                Console.WriteLine("L > Leave");

                switch (Console.ReadLine().Substring(0, 1).ToUpper())
                {
                    case "E":
                        Examine();
                        break;
                    case "F":
                        Forage();
                        break;
                    case "L":
                        return;
                    default: break;
                }
            }
        }

        void Examine()
        {
            Console.WriteLine("In the middle of the floor is a pool of blood where Lewis was clearly lying.");
            Console.WriteLine("The locals did what they thought was best but this crime scene has been contaminated beyond belief. No photos, no chalk outline, no fingerprints...");
            if (SaveData.DemetriusCount == 0) Console.WriteLine("You're sure that scientist Demetrius would be happy to help, but for all you know he might be a suspect.");
            Console.WriteLine("You're going to have to solve this one without forensics.\n");
            Console.WriteLine("You look around the room. The house looks like it's kept neat, like the flowerbeds outside.");
            Console.WriteLine("Something catches your eye; an empty shelf on the wall. A circle of dust hints that something sat on this shelf until recently.");
            Console.WriteLine("Finding this missing item might be a clue as to what happened here.");
            SaveData.CrimeSceneVisited = true;
        }

        public override void Forage()
        {           
            Console.WriteLine("You start looking through drawers and cupboards for any clues that might help you solve this mystery.");

            if (SaveData.CrypticNote == false)
            {
                Console.WriteLine("In the top drawer of the kitchen cupboard you see a hand written note:\n");
                Console.WriteLine("Lewis, I know you're having reservations about selling the Community Centre. Please let me reassure you, it will be used for the good of the community.");
                Console.WriteLine("As a token of our goodwill, I have enclosed a little gift for you. I hope you make the right decision. -M\n");
                Console.WriteLine("Under the note there's a wad of cash held together with an elastic band.");
                Console.WriteLine("Cryptic Note added to casefile.");
                SaveData.CrypticNote = true;
            }

            if (SaveData.SewerKey == false)
            {
                Console.WriteLine("Next to the money you see an old looking key with no markings. You take it.");
                SaveData.SewerKey = true;
                if (SaveData.FindSewerKey == true)
                {
                    Console.WriteLine("This might be the key for the sewers.");
                }
            }
        }
    }
}
