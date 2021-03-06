﻿using BotFactory.Common;
using BotFactory.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public abstract class BuildableUnit: IBuildableUnit
    {
        public double BuildTime { get; set; }
        public string Model { get; set; }
        public StatusChangedEventHandler UnitStatusChanged { get; set; }
        
        public BuildableUnit()
        {
            BuildTime = 5;
        }
        public BuildableUnit(double buildTime = 5.0f)
        {
            BuildTime = buildTime;
        }
    }
}
