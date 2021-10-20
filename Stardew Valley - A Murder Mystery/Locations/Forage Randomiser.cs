using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Forage_Randomiser
    {
        private SaveData SaveData { get; set; }

        public Forage_Randomiser (SaveData saveData)
        {
            SaveData = saveData;
        }
        
        public Enums.Items ForageRandomiser()
        {                     
            Random forage = new();
            int random = forage.Next(0, 39);

            var randomForage = (Enums.Items)random;
            return randomForage;
        }
    }
}
