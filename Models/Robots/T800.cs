using BotFactory.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class T800 : WorkingUnit, IWorkingUnit, ITestingUnit
    {
        public T800() : base("T800",3,10)
        {
            
            
        }
    }
}
