using BotFactory.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class HAL : WorkingUnit, IWorkingUnit, ITestingUnit
    {
        
        public HAL() :
            base("HAL",0.5,7)
        {
            
            
        }
    }
}
