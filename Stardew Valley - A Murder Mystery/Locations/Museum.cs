﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery.Locations
{
    class Museum : Location
    {
        private SaveData SaveData { get; set; }

        public Museum(SaveData saveData)
        {
            SaveData = saveData;
        }

        public override void Enter()
        {

        }

        public override void Forage()
        {

        }
    }
}