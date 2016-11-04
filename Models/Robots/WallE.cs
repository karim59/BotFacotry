using BotFactory.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class WallE : WorkingUnit, IWorkingUnit, ITestingUnit
    {
        public WallE() : base("WallE",2,4)
        {
            
            
        }
    }
}
