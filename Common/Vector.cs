using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Tools
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }

        public static double Length(Vector V)
        {
            
                return Math.Sqrt(Math.Pow(V.X, 2) + Math.Pow(V.Y, 2));
            
        }


        public static Vector FromCoordinates(Coordinates begin, Coordinates end)
        {
            Vector V = new Vector();
            V.X = end.X - begin.Y;
            V.Y = end.Y - begin.Y;
            return V;
        }
    }
}
