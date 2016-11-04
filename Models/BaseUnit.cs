using BotFactory.Common.Interface;
using BotFactory.Common.Tools;
using BotFactory.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class BaseUnit : ReportingUnit, IBaseUnit
    {
        public double Speed { get; set; }
        public string Name { get; set; }
        public Coordinates CurrentPos { get; set; }

        
        
 

        
        public BaseUnit(string name, double Speed = 1,double buildTime=7) : base(buildTime)
        {
            Name = name;
            this.Speed = Speed;
            
        }

    
        public async Task<Boolean> Move(Coordinates currentPos, Coordinates targetPos)
        {

            Thread.Sleep(10000);
           // await Task.Delay((int)Speed*10000);

            CurrentPos = targetPos;

            return true;
        }

       
    }
}
