using System;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Program
    {
        static void Main(string[] args)
        {
            //intro. are you ready to begin y/n game will take x hours to play etc. if yes;

            SaveData saveData = new SaveData();

            Console.WriteLine("What's your name?");
            string PlayerName = Console.ReadLine();
            saveData.PlayerName = PlayerName;
            //intro. read case file. get off bus. stay at guest house on Farm


            NPC newNPC = new NPC();
            newNPC.ChatwithPam();
           
            

            
            Console.WriteLine("DAY 1");
            while (true)
            {
                if (saveData.Day1Complete == true) break;

                ChooseLocation Location = new ChooseLocation();
                var ChosenLocation = Location.ChooseLocationMethod(saveData);
                ChosenLocation.Enter();
            }

            Console.WriteLine("DAY 2");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }   
}
