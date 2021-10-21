using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Achievements
    {
        private SaveData SaveData { get; set; }

        public Achievements(SaveData saveData)
        {
            SaveData = saveData;
        }

        //Achievements
        public bool Vivisection { get; set; } //review Lewis' autopsy
        public bool Friendship { get; set; } // speak with every character in the game
        public bool HotShot { get; set; } //correctly identify the murderer
        public bool HatMaus { get; set; } //find HatMaus in the forest
        public bool AchievementHoarder { get; set; } //complete every other achievement
        public bool FuckYouPierre { get; set; } //gift Pierre the candy you stole from his store
       

        public void CheckAchievements()
        {
            

            if (Vivisection == true)
            {
                Console.WriteLine("Achievement Unlocked: Vivisection");
            }
            if (Friendship == true)
            {
                Console.WriteLine("Achievement Unlocked: Friendship");
            }
            if (HotShot == true)
            {
                Console.WriteLine("Achievement Unlocked: Hot Shot Detective");
            }
            if (SaveData.HatMausHaus == true && HatMaus != true)
            {
                HatMaus = true;
                Console.WriteLine("Achievement Unlocked: Friend of Hat Mouse");
            }
            if (Vivisection == true && Friendship == true && HotShot == true && HatMaus == true && FuckYouPierre == true)
            {
                AchievementHoarder = true;
                Console.WriteLine("Achievement Unlocked: Unlocked all Achievements");
            }

            if (Vivisection == true || Friendship == true || HotShot == true || HatMaus == true || FuckYouPierre == true)
            {
                SaveData.Unlocked = true;
                Console.WriteLine("");
                Console.WriteLine("Congratulations, you have unlocked your first achievement!");
                Console.WriteLine("You can view your achievements by using the command 'Check Achievements'");
                Console.WriteLine("");
            }
        }

        public void ViewAchievements()
        {
            Console.WriteLine("Unlocked Achievements;");
            Console.WriteLine("");

            if (Vivisection == true)
            {
                Console.WriteLine("Vivisection: Watched Mayor Lewis' autopsy.");
            }
            if (Friendship == true)
            {
                Console.WriteLine("Friendship: spoke to every villager in Stardew Valley");
            }
            if (HotShot == true)
            {
                Console.WriteLine("Hot Shot Detective: correctly identified Lewis' murderer");
            }
            if (HatMaus == true)
            {
                Console.WriteLine("Friend of Hat Mouse: found and spoke with Hat Mouse in Cindersap Forest");
            }
            if (AchievementHoarder == true)
            {
                Console.WriteLine("Achievement Hoarder: unlocked all other achievements");
            }
        }
            
    }
}
