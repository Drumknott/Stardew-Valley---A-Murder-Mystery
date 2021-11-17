using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class CaseFile
    {
        private SaveData SaveData { get; set; }

        public CaseFile(SaveData saveData)
        {
            SaveData = saveData;
        }

        public void Notes()
        {
            if (SaveData.Brief == true)
            {
                Console.WriteLine("\nCaseFile");
                Console.WriteLine("\n911 call from town resident Marnie reporting the discovery of a dead body, reportedly that of the town Mayor Lewis.");
                Console.WriteLine("The body is being kept at the local Doctor's Surgery. Awaiting further investigation.");
            }

            if (SaveData.Suspect == true)
            {
                Console.WriteLine($"\nLinus saw {SaveData.TheMurderer} go into the mine in the middle of the night. What were they doing there?");
            }
            if (SaveData.SuspectDemetrius == true)
            {
                Console.WriteLine($"\nLinus saw Demetrius go into the mine in the middle of the night. What were they doing there?");
            }
            if (SaveData.MyInventory[Enums.Items.LewisStatue] == 1)
            {
                Console.WriteLine("You found a bloodstained statue of Lewis that someone had tried to hide in the mine. Could it be the murder weapon?");
            }

            Console.WriteLine("\nEnter > Return");
            Console.ReadKey();
        }
    }
}
