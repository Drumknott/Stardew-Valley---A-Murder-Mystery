using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class SettingValues
    {
        private SaveData SaveData { get; set; }

        public SettingValues(SaveData saveData)
        {
            SaveData = saveData;
        }
        public void SetValues()
        {
            SaveData.PamCount = 0;
            SaveData.GusCount = 0;
            SaveData.AbigailCount = 0;
            SaveData.PierreCount = 0;
            SaveData.CarolineCount = 0;
            SaveData.HarveyCount = 0;
            SaveData.PennyCount = 0;
            SaveData.LinusCount = 0;
            SaveData.WizardCount = 0;
            SaveData.KrobusCount = 0;
            SaveData.RobinCount = 0;
            SaveData.DemetriusCount = 0;
            SaveData.MaruCount = 0;
            SaveData.SebastianCount = 0;
            SaveData.GeorgeCount = 0;
            SaveData.EvelynCount = 0;
            SaveData.AlexCount = 0;
            SaveData.ClintCount = 0;
            SaveData.MorrisCount = 0;
            SaveData.WillyCount = 0;
            SaveData.SamCount = 0;
            SaveData.JodiCount = 0;
            SaveData.KentCount = 0;
            SaveData.EmilyCount = 0;
            SaveData.HaleyCount = 0;
            SaveData.MarnieCount = 0;
            SaveData.ShaneCount = 0;
            SaveData.LeahCount = 0;
            SaveData.ElliotCount = 0;
            SaveData.FarmerCount = 0;
            SaveData.MarlonCount = 0;

            SaveData.AbigailFriendship = 0;
            SaveData.AlexFriendship = 0;
            SaveData.ElliotFriendship = 0;
            SaveData.EmilyFriendship = 0;
            SaveData.HaleyFriendship = 0;
            SaveData.HarveyFriendship = 0;
            SaveData.LeahFriendship = 0;
            SaveData.MaruFriendship = 0;
            SaveData.PennyFriendship = 0;
            SaveData.SamFriendship = 0;
            SaveData.SebastianFriendship = 0;
            SaveData.ShaneFriendship = 0;
            SaveData.KrobusFriendship = 0;

            SaveData.ShopGus = 0;
            SaveData.MineCount = 0;
            

        }
    }
}
