﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    [Serializable ] public class SaveData
    {
        //using (var SaveFileStream = File.Create("saveFile.dat"))
        //{
        //    BinaryFormatter serializer = new BinaryFormatter();
        //    serializer.Serialize(SaveFileStream, saveData);
        //    SaveFileStream.Flush();
        //}
        //public void Save()
        //{
        //    using (var SaveFileStream = File.Create("saveFile.dat"))
        //    {
        //        BinaryFormatter serializer = new BinaryFormatter();
        //        serializer.Serialize(SaveFileStream, this);
        //        SaveFileStream.Flush();
        //    }
        //}

        public string PlayerName { get; set; }
        public string FarmerName { get; set; }

        //Places Visited
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
        public bool Quarry { get; set; }
        public bool TrainTracks { get; set; }
        public bool AdventurersGuild { get; set; }
        public bool WizardsTower { get; set; }
        public bool JojaMart { get; set; }
        public bool MarniesHouse { get; set; }
        public bool HatMausHaus { get; set; }

        //People Met
        public int PamCount { get; set; }
        public int GusCount { get; set; }
        public int AbigailCount {get; set;}
        public int PierreCount {get; set;}
        public int CarolineCount {get; set;}
        public int HarveyCount {get; set;}
        public int PennyCount {get; set;}
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

        //Items Collected

        //Information Learned

        //time
        public bool Day1Complete { get; set; } 

    }
}
