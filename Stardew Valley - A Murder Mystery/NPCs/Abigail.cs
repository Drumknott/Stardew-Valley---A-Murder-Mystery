using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Abigail : NPC
    {
        private SaveData SaveData { get; set; }

        public Abigail(SaveData saveData)
        {
            SaveData = saveData;
        }
        public override void Chat()
        {

            if (SaveData.AbigailCount == 0)
            {
                //first meeting with Abigail
                Console.WriteLine("");
                SaveData.AbigailCount += 1;
            }
        }

        public override void Gift()
        {         
            var gift = Console.ReadLine();
            {               
                if (gift == "Amethyst") SaveData.Amethyst -= 1;
                    Console.WriteLine("Abigail > Hey, how’d you know I was hungry? This looks delicious!"); // Abi loves
                    SaveData.AbigailFriendship += 1;                    
                
                if (SaveData.Horseradish > 0) SaveData.Horseradish -= 1;
                    Console.WriteLine("Abigail > What am I supposed to do with this ?"); //Abi hates
                    SaveData.AbigailFriendship -= 1;

                //else if [neutral gift]
                    
            }

            Console.WriteLine("Abigail > You brought me a present ? Thanks."); //Abi neutral
            

        }

    }
}
