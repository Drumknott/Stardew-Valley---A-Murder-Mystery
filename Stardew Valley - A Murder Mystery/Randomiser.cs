using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    public class Randomiser
    {
        private SaveData SaveData { get; set; }

        public Randomiser(SaveData saveData)
        {
            SaveData = saveData;
        }
        public void RandomMurderer()
        {
            Random Murderer = new();
            int random = Murderer.Next(0, 2);

            switch (random)
            {
                case 0: SaveData.TheMurderer = "Pierre"; break;
                case 1: SaveData.TheMurderer = "Marnie"; break;
                case 2: SaveData.TheMurderer = "Kent"; break;
            }
            RandomNewMayor();
        }

        void RandomNewMayor()
        {
            Random NewMayor = new();
            int random = NewMayor.Next(0, 2);

            switch (random)
            {
                case 0: SaveData.NewMayor = "Pierre"; break;
                case 1: SaveData.NewMayor = "Morris"; break;
                case 2: SaveData.NewMayor = "Kent"; break;
            }

            if (SaveData.NewMayor == SaveData.TheMurderer)
            {
                RandomNewMayor();
            }
        }
    }
}
