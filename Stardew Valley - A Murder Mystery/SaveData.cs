using Stardew_Valley___A_Murder_Mystery.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    [Serializable] public class SaveData
    {
        public void Save()
        {
            using (var SaveFileStream = File.Create("saveFile.dat"))
            {
                BinaryFormatter serializer = new();
                serializer.Serialize(SaveFileStream, this);
                SaveFileStream.Flush();
            }
        }
        //misc info
        public string PlayerName { get; set; }
        public string FarmerName { get; set; }
        public string TheMurderer { get; set; }
        public string NewMayor { get; set; }
        public bool TravellingLady { get; set; }
        public bool Homeless { get; set; }
        public bool ExploredNorth { get; set; }
        public bool ExploredSouth { get; set; }
        public bool ExploredEast { get; set; }
        public bool ExploredWest { get; set; }
        public bool PierreLied { get; set; }
        public bool StealFromPierre { get; set; }
        public bool Unlocked { get; set; }
        public int ShopGus { get; set; }
        public bool FuckYouPierre { get; set; } //gift Pierre the candy you stole from his store
        public bool Flashlight { get; set; }
        public int levelCount {get; set;}
        public bool Monster { get; set; }
        public string MonsterType { get; set; }
        public bool MineDemetrius { get; set; }
        public bool SewerKey { get; set; }
        public bool FindSewerKey { get; set; }
        public bool Blackmail { get; set; }
        public bool StayAtLewis { get; set; }
        public bool WhereWasKent { get; set; }
        public bool PTSD { get; set; }

        //Places Visited
        public string LastVisited { get; set; }
        public string LastChat { get; set; }
        public bool CrimeSceneVisited { get; set; }
        public bool Farm { get; set; }
        public bool FarmFirstVisit { get; set; }
        public bool Beach { get; set; }
        public bool FreshOffTheBus { get; set; }
        public bool BusStop { get; set; }
        public bool Mine { get; set; }
        public int MineCount { get; set; }
        public bool DoctorsSurgery { get; set; }
        public bool CommunityCentre { get; set; }
        public bool StardropSaloon { get; set; }
        public bool PelicanTown { get; set; }
        public bool TownFirstVisit { get; set; }
        public bool JodisHouse { get; set; }
        public bool EmilysHouse { get; set; }
        public bool AdventurersGuild { get; set; }
        public bool WizardsTower { get; set; }
        public bool JojaMart { get; set; }
        public bool MarniesHouse { get; set; }
        public bool HatMausHaus { get; set; }
        public bool GeneralStore { get; set; }
        public bool Cabin { get; set; }
        public bool Sewers { get; set; }
        public bool GeorgesHouse { get; set; }
        public bool Blacksmith { get; set; }
        public bool Museum { get; set; }
        public bool Robins { get; set; }
        public bool Cindersap { get; set; }
        public bool LeahsHouse { get; set; }
        public bool EvelynGeorgeAlexsHouse { get; set; }
        public bool Graveyard { get; set; }
        public bool MayorsHouse { get; set; }

        //People Met
        public int PamCount { get; set; }
        public int GusCount { get; set; }
        public int AbigailCount { get; set; }
        public int PierreCount { get; set; }
        public int CarolineCount { get; set; }
        public int HarveyCount { get; set; }
        public int PennyCount { get; set; }
        public int LinusCount { get; set; }
        public int WizardCount { get; set; }
        public int KrobusCount { get; set; }
        public int RobinCount { get; set; }
        public int DemetriusCount { get; set; }
        public int MaruCount { get; set; }
        public int SebastianCount { get; set; }
        public int GeorgeCount { get; set; }
        public int EvelynCount { get; set; }
        public int AlexCount { get; set; }
        public int ClintCount { get; set; }
        public int GuntherCount { get; set; }
        public int WillyCount { get; set; }
        public int SamCount { get; set; }
        public int JodiCount { get; set; }
        public int KentCount { get; set; }
        public int EmilyCount { get; set; }
        public int HaleyCount { get; set; }
        public int MarnieCount { get; set; }
        public int ShaneCount { get; set; }
        public int LeahCount { get; set; }
        public int ElliottCount { get; set; }
        public int FarmerCount { get; set; }
        public int MarlonCount { get; set; }
        public int MorrisCount { get; set; }

        //Friendship/Romance
        public int AbigailFriendship { get; set; }
        public int AlexFriendship { get; set; }
        public int ElliottFriendship { get; set; }
        public int EmilyFriendship { get; set; }
        public int HaleyFriendship { get; set; }
        public int HarveyFriendship { get; set; }
        public int LeahFriendship { get; set; }
        public int MaruFriendship { get; set; }
        public int PennyFriendship { get; set; }
        public int SamFriendship { get; set; }
        public int SebastianFriendship { get; set; }
        public int ShaneFriendship { get; set; }
        public bool MarnieAndMarlon { get; set; }
        public bool MarnieAndLewis { get; set; }
        public int KrobusFriendship { get; set; }


        //Items Collected
        public Dictionary<Items, int> MyInventory { get; set; } = new Dictionary<Items, int>();
        public Dictionary<Hats, int> MyHatCollection { get; set; } = new Dictionary<Hats, int>();


        //Information Learned
        public bool Brief { get; set; }
        public bool Clue { get; set; }
        //time
        public int DayCount { get; set; }

        //Investigations
        public bool podcast { get; set; }
        public bool Suspect { get; set; }
        public bool SuspectDemetrius { get; set; }
        public bool CrypticNote { get; set; } 
        public string npc1 { get; set; }
        public string npc2 { get; set; }
        public string npc3 {get; set;}
        public string npc4 { get; set; }
        public string npc5 { get; set; }
        public string npc6 { get; set; }
        public string npc7 { get; set; }
        public string npc8 { get; set; }
        public string npc9 { get; set; }
        public string npc10 { get; set; }
        public string npc11 { get; set; }
        public string npc12 { get; set; }
        public string npc13 { get; set; }
        public bool ElectionStart { get; set; }
        public bool MysterySolved { get; set; }
        public string AccusedMurderer { get; set; }
        public bool NPCaccused { get; set; }

        //increase time
        public bool Autopsy { get; set; }
        public bool autopsyChecked { get; set; }

        //Achievements
        public bool Vivisection { get; set; } //review Lewis' autopsy
        public bool Friendship { get; set; } // speak with every character in the game
        public bool HotShot { get; set; } //correctly identify the murderer
        public bool HatMaus { get; set; } //find HatMaus in the forest
        public bool AchievementHoarder { get; set; } //complete every other achievement
        public bool CollectAllTheHats { get; set; }

    }
}
