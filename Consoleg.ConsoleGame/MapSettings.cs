using Consoleg.ConsoleGame.Extensions;
using Microsoft.Extensions.Configuration;
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

    public interface IMapService
    {
        (int width, int height) GetMap();
    }

    public class MapService : IMapService
    {
        private readonly IConfiguration configuration;

        public MapService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public (int width, int height) GetMap()
        {
            return (width: configuration.GetMapSizeFor("x"), height: configuration.GetMapSizeFor("y"));
        }
    }

}
