using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stardew_Valley___A_Murder_Mystery.Enums;

namespace Stardew_Valley___A_Murder_Mystery
{
    public class TravellingLady
    {
        private SaveData SaveData { get; set; }

        public TravellingLady(SaveData saveData)
        {
            SaveData = saveData;
        }

       

        public void Chat()
        {
            Console.WriteLine("Travelling Merchant > Hello there! Can I interest you in anything?\n");

            //write array of products for sale. Wants gems in exchange
        }
    }
}
