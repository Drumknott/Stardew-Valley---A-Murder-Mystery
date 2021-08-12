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
                Console.WriteLine("");
                Console.WriteLine("CaseFile");
                Console.WriteLine("");
                Console.WriteLine("911 call from town resident Marnie reporting the discovery of a dead body, reportedly that of the town Mayor Lewis.");
                Console.WriteLine("The body is being kept at the local Doctor's Surgery. Awaiting further investigation.");
            }

            Console.WriteLine("Enter > Return");
            Console.ReadKey();
        }
    }
}
