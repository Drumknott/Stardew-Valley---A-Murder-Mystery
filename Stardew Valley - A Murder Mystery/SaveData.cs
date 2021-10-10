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
        public int JodieCount { get; set; }
        public int KentCount { get; set; }
        public int EmilyCount { get; set; }
        public int HayleyCount { get; set; }
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
        public int HayleyFriendship { get; set; }
        public int HarveyFriendship { get; set; }
        public int LeahFriendship { get; set; }
        public int MaruFriendship { get; set; }
        public int PennyFriendship { get; set; }
        public int SamFriendship { get; set; }
        public int SebastianFriendship { get; set; }
        public int ShaneFriendship { get; set; }
        public bool MarnieAndMarlon { get; set; }
        public bool MarnieAndLewis { get; set; }


        //Items Collected
        public Dictionary<Items, int> MyInventory { get; set; } = new Dictionary<Items, int>();
        //public int Amethyst { get; set; } //Abi loves, Clint loves
        //public int Horseradish { get; set; } // Abi hates
        //public int LewisStatue { get; set; }
        //public int CompleteBreakfast {get; set; } // Alex loves
        //public int Holly {get; set; } // Alex Hates, Clint hates, Demetrius hates, Kent hates, Robin hates
        //public int CrabCakes {get; set; } //Elliot loves
        //public int Amaranth {get; set; } //Elliot hates
        //public int Coffee { get; set; } //Harvey loves
        //public int Coral {get; set; } // Harvey hates
        //public int MapleBar {get; set; } //Sam loves
        //public int Coal {get; set; } //Sam hates
        //public int FrozenTear {get; set; } //Seb loves
        //public int Clay {get; set; } //Seb hates, George hates, Marnie hates
        //public int Cloth {get; set; } //Emily loves
        //public int FishTaco {get; set; } //Emily hates, Caroline loves
        //public int Coconut {get; set; } //Hayley hates, Linus loves
        //public int PrismaticShard {get; set; } //Hayley hates
        //public int GoatCheese { get; set; } //Leah loves, Robin loves
        //public int Bread {get; set; } //Leah hates
        //public int BatteryPack {get; set; } //Maru loves
        //public int Honey { get; set; } //Maru hates
        //public int Diamond { get; set; } //Penny loves, Gus loves
        //public int Beer {get; set; } //Penny hates, Pam loves, Shane Loves
        //public int Quartz {get; set; } //Caroline hates, Shane hates
        //public int BeanHotpot {get; set; } //Demetrius loves
        //public int Emerald {get; set; } //Dwarf loves, Emily loves
        //public int Seaweed {get; set; } //Dwarf hates, Krobus hates, Linus hates
        //public int ChocolateCake {get; set; } //Evelyn loves, Jodi loves
        //public int Clam {get; set; } //Evelyn hates
        //public int Leek {get; set; } //George loves, Willy hates
        //public int Coleslaw {get; set; } //Gus hates
        //public int Daffodil {get; set; } //Jodi hates
        //public int Risotto {get; set; } //Kent loves
        //public int VoidEgg {get; set; } //Krobus loves
        //public int FarmersLunch {get; set; } //Marnie loves
        //public int Octopus {get; set; } //Pam hates, Willy loves
        //public int FriedCalamari {get; set; } //Pierre loves
        //public int Corn {get; set; } //Pierre hates
        //public int VoidEssence {get; set; } //Wizard loves
        //public int RedMushroom {get; set; } //Wizard hates
        //public int JojaCola { get; set; }


        //Information Learned
        public bool Brief { get; set; }
        public bool Clue { get; set; }
        //time
        public int DayCount { get; set; } 

        //Investigations
        public int AbigailInvestigated { get; set; }

    }
}
