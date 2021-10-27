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

        public void CheckAchievements()
        {
            if (SaveData.Vivisection == true)
            {
                Console.WriteLine("Achievement Unlocked: Vivisection");               
            }
            if (SaveData.Friendship == true)
            {
                Console.WriteLine("Achievement Unlocked: Friendship");
            }
            if (SaveData.HotShot == true)
            {
                Console.WriteLine("Achievement Unlocked: Hot Shot Detective");
            }
            if (SaveData.HatMausHaus == true && SaveData.HatMaus != true)
            {
                SaveData.HatMaus = true;
                Console.WriteLine("Achievement Unlocked: Friend of Hat Mouse");
            }
            if (SaveData.FuckYouPierre == true)
            {
                Console.WriteLine("Achievement Unlocked: Fuck You Pierre");
            }

            if (SaveData.Vivisection == true && SaveData.Friendship == true && SaveData.HotShot == true && SaveData.HatMaus == true && SaveData.FuckYouPierre == true)
            {
                SaveData.AchievementHoarder = true;
                Console.WriteLine("Achievement Unlocked: Unlocked all Achievements");
            }

            if (SaveData.Vivisection == true || SaveData.Friendship == true || SaveData.HotShot == true || SaveData.HatMaus == true || SaveData.FuckYouPierre == true)
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

            if (SaveData.Vivisection == true)
            {
                Console.WriteLine("Vivisection: Watched Mayor Lewis' autopsy.");
            }
            if (SaveData.Friendship == true)
            {
                Console.WriteLine("Friendship: spoke to every villager in Stardew Valley");
            }
            if (SaveData.HotShot == true)
            {
                Console.WriteLine("Hot Shot Detective: correctly identified Lewis' murderer");
            }
            if (SaveData.HatMaus == true)
            {
                Console.WriteLine("Friend of Hat Mouse: found and spoke with Hat Mouse in Cindersap Forest");
            }
            if (SaveData.FuckYouPierre == true)
            {
                Console.WriteLine("Fuck You Pierre: stole a maple bar from Pierre and then gifted it back to him");
                Console.WriteLine("(It's ok. He's a jerk, he deserves it)");
            }

            if (SaveData.AchievementHoarder == true)
            {
                Console.WriteLine("Achievement Hoarder: unlocked all other achievements");
            }
        }
            
    }
}
