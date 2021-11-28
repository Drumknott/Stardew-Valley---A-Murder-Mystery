using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class DayManager
    {
        private SaveData SaveData { get; set; }

        public DayManager(SaveData saveData)
        {
            SaveData = saveData;
        }

        bool passedOut = false;
        
        public void IncreaseDayCount()
        {
            if (passedOut == true)
            {
                Console.WriteLine("You wake to find Linus crouching over you.\nLinus > Phew! Close one Detective. You need to be more careful down there.\nLinus > You should go and get some rest.\n");
                passedOut = false;
            }
            else
            {
                Console.WriteLine("It's been a busy day. You should get some rest.");
                if (SaveData.LastVisited == "Cabin") Console.WriteLine("You lie down in your bed, and before you know it you're drifting off to sleep...");
            }
           
            Console.WriteLine("Enter > Continue\n");            
            Console.ReadKey();
            SaveData.DayCount++;
            
            switch (SaveData.DayCount)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("*********\n* DAY 2 *\n*********\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("*********\n* DAY 3 *\n*********\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("*********\n* DAY 4 *\n*********\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("*********\n* DAY 5 *\n*********\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("*********\n* DAY 6 *\n*********\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("***********************\n* DAY 7: ELECTION DAY *\n***********************\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            
            Console.WriteLine("Enter > Continue\n");
            Console.ReadKey();
        }
        public void CheckDayCount()
        {
            if (SaveData.Autopsy == true && SaveData.autopsyChecked != true)
            {
                IncreaseDayCount();
                SaveData.autopsyChecked = true;
            }
        }

        public void PassedOut()
        {
            passedOut = true;
            IncreaseDayCount();
            return;
        }
    }
}
