using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleg.ConsoleGame.Extensions
{
    internal static class MapExtensions
    {
        public static IDrawable? CreatureAtExtension(this List<Creature> creatures, Cell cell)
        {
            //IDrawable? result = null;

            //foreach (Creature creature in creatures)
            //{
            //    if (creature.Cell == cell)
            //    {
            //        result = creature;
            //        break;
            //    }
            //}

            //return result;

            return creatures.FirstOrDefault(c => c.Cell == cell);

        }
    }
}
