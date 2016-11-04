using BotFactory.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class R2D2 : WorkingUnit, IWorkingUnit, ITestingUnit
    {
        public R2D2() : base("R2D2", 1.5, 5.5)
        {


        }
    }
}
