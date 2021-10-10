using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class SaveManager
    {

        public static SaveData Load()
        {
            using (var openFileStream = File.OpenRead("saveFile.dat"))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                return (SaveData)deserializer.Deserialize(openFileStream);
            }
        }
    }
}
