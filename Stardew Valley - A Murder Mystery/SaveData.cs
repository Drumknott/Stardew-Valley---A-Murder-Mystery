using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    public class SaveData
    {
        public string PlayerName { get; set; }

        //Places Visited
        public bool CrimeSceneVisited { get; set; }
        public bool Farm { get; set; }
        
        //People Met
        public int PamCount { get; set; }

        //Items Collected

        //Information Learned

        //time
        public bool Day1Complete { get; set; } 

    }
}
