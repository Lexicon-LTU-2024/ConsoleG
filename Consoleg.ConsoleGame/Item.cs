using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleg.ConsoleGame
{
    internal class Item : IDrawable
    {
        private readonly string _name;
        public ConsoleColor Color { get; }
        public string Symbol { get; }

        public Item(string symbol, ConsoleColor color, string name)
        {
            Symbol = symbol;
            Color = color;
            _name = name;
        }

        public override string ToString() => _name;
    }
}
