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
        public bool DoctorsSurgery { get; set; }
        public bool CommunityCentre { get; set; }
        public bool StardropSaloon { get; set; }
        public bool PelicanTown { get; set; }
        public bool TownFirstVisit { get; set; }
        public bool Quarry { get; set; }
        public bool TrainTracks { get; set; }
        public bool AdventurersGuild { get; set; }
        public bool WizardsTower { get; set; }
        public bool JojaMart { get; set; }
        public bool MarniesHouse { get; set; }
        public bool HatMausHaus { get; set; }
        public bool GeneralStore { get; set; }
        public bool Cabin { get; set; }
        public bool WillysShack { get; set; }
        public bool ElliottsCabin { get; set; }
        public bool Blacksmith { get; set; }
        public bool Museum { get; set; }
        public bool Robins { get; set; }
        public bool Cindersap { get; set; }
        public bool LeahsHouse { get; set; }

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
        public int ElliotCount { get; set; }
        public int FarmerCount { get; set; }
        public int MarlonCount { get; set; }

        //Friendship/Romance
        public int AbigailFriendship { get; set; }
        public int AlexFriendship { get; set; }
        public int ElliotFriendship { get; set; }
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

        
        //Information Learned
        public bool Brief { get; set; }
        public bool Clue { get; set; }
        //time
        public int DayCount { get; set; } 

        //Investigations
        public int AbigailInvestigated { get; set; }

    }
}
