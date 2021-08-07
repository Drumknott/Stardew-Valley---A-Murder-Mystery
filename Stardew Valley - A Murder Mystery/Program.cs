using System;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("N > NEW GAME");
            Console.WriteLine("L > LOAD GAME");
            var Start = Console.ReadLine();

            if (Start == "L")
            {
                //load game

                //public static SaveData Load()
                //{
                //    using (var openFileStream = File.OpenRead("saveFile.dat"))
                //    {
                //        BinaryFormatter serializer = new BinaryFormatter();
                //        return (SaveData)deserializer.Deserialize(openFileStream);
                //    }
                //}
            }

            Console.WriteLine("Welcome to STARDEW VALLEY - A MURDER MYSTERY");
            Console.WriteLine("");
            Console.WriteLine("Are you ready to begin? Y/N");
            var Begin = Console.ReadLine();

            if (Begin == "N")
            {
                Console.WriteLine("No problem. Come back when you're ready to play.");
                //exit application
            }

            SaveData saveData = new SaveData();

            Intro Opening = new Intro();
            Opening.Opening();

            Pam newNPC = new Pam(saveData);
            newNPC.Chat();                 
                                
                        
            Console.WriteLine("DAY 1");
            while (true)
            {
                if (saveData.Day1Complete == true) break;

                BusStop busStop = new BusStop(saveData);
                busStop.Enter();

                ChooseLocation Location = new ChooseLocation();
                var ChosenLocation = Location.ChooseLocationMethod(saveData);
                ChosenLocation.Enter();
            }

            Console.WriteLine("DAY 2");
            while (true)
            {

            }

            Console.WriteLine("Day 3");
            Console.WriteLine("DAY 4");
            
            Console.WriteLine("Day 5");
            //travelling lady
        }
    }   
}
