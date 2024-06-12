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
}
