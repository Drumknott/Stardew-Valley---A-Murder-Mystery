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
        
        public void IncreaseDayCount()
        {

            Console.WriteLine("");
            Console.WriteLine("It's been a busy day. You should go and get some rest.");
            Console.WriteLine("");
            Console.WriteLine("Enter > Continue");
            Console.WriteLine("");
            Console.ReadKey();
            SaveData.DayCount++;
            if (SaveData.DayCount == 1)
            {
                Console.WriteLine("DAY 2");
            }
            if (SaveData.DayCount == 2)
            {
                Console.WriteLine("DAY 3");
            }
            if (SaveData.DayCount == 3)
            {
                Console.WriteLine("DAY 4");
            }
            if (SaveData.DayCount == 4)
            {
                Console.WriteLine("DAY 5");
            }
            if (SaveData.DayCount == 5)
            {
                Console.WriteLine("DAY 6");
            }
            if (SaveData.DayCount == 6)
            {
                Console.WriteLine("DAY 7: Election Day");
            }
            Console.WriteLine("");
            Console.WriteLine("Enter > Continue");
            Console.WriteLine("");
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
    }
}
