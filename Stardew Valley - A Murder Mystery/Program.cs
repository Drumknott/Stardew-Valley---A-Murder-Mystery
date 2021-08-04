using System;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Program
    {
        static void Main(string[] args)
        {
            //intro. are you ready to begin y/n game will take x hours to play etc. if yes;

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

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }   
}
