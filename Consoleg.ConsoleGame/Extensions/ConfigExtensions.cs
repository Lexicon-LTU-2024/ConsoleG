using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleg.ConsoleGame.Extensions
{
    internal static class ConfigExtensions
    {
        public static int GetMapSizeFor(this IConfiguration config, string key)
        {
            var section = config.GetSection("game:mapsettings");
            return int.TryParse(section[key], out int result) ? result : 0;
        }
    }
    
    public static class ConfigExtensions2
    {
        public static IGetMapSizeFor Implementation { private get; set; } = new GetMapSize();
        public static int GetMapSizeFor2(this IConfiguration config, string key)
        {
            return Implementation.GetMapSizeFor(config, key);
        }
    }

    public interface IGetMapSizeFor
    {
        int GetMapSizeFor(IConfiguration config, string key);
    }

    public class GetMapSize : IGetMapSizeFor
    {
        public int GetMapSizeFor(IConfiguration config, string key)
        {
            var section = config.GetSection("game:mapsettings");
            return int.TryParse(section[key], out int result) ? result : 0;
        }
    }
}
