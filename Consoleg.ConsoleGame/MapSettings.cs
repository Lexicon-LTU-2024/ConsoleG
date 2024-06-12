using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleg.ConsoleGame
{
    internal interface IMapSettings
    {
        int X { get; set; }
        int Y { get; set; }
    }

    internal class MapSettings : IMapSettings
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    

}
