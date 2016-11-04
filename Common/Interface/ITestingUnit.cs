using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Interface
{

    public interface ITestingUnit : IReportingUnit
    {
        
        Coordinates CurrentPos { get; set; }
        double Speed { get; set; }
        string Name { get; set; }
        Task<bool> Move(Coordinates current, Coordinates target);

        Coordinates ParkingPos { get; set; }
        Coordinates WorkingPos { get; set; }
        bool IsWorking { get; set; }
        Task<bool> WorkBegins();
        Task<bool> WorkEnds();

    }
}
